using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using Backend.Api.Models;
using Backend.BusinessLogic.DTO.Request;
using Backend.BusinessLogic;
using Backend.Api.Services;
using Backend.Api.Helpers;
using System.Security.Claims;
using System.Configuration;

namespace Backend.Api.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private IUserService Servicio { get; set; }
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        private ILog Log { get; set; }
        public LoginController(IUserService _serv, ILog _log, ITokenService _tokenService, IPasswordHasher _passwordHasher)
        {
            this.Servicio = _serv;
            this.Log = _log;
            this._tokenService = _tokenService;
            this._passwordHasher = _passwordHasher;
        }

        [HttpPost]
        public IHttpActionResult Login(LoginRequest loginModel)
        {
            var user = this.Servicio.GetByEmail(loginModel.Email);

            if (user == null || !_passwordHasher.VerifyIdentityV3Hash(loginModel.Password, user.Password))
            {
                return BadRequest();
            }

            var usersClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var jwtToken = _tokenService.GenerateAccessToken(usersClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            var expires = int.Parse(ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"]) * 60;

            this.Servicio.UpdateRefreshToken(user.Id, refreshToken);

            return Ok(new
            {
                token = jwtToken,
                refreshToken = refreshToken
            });
           
        }    
    }
}

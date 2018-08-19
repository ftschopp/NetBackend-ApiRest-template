using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using Backend.Api.Models;
using Backend.BusinessLogic.DTO.Request;
using Backend.BusinessLogic;
using System.Threading.Tasks;
using Backend.Api.Services;

namespace Backend.Api.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/token")]
    public class TokenController : ApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        public TokenController(ITokenService tokenService, UserService userSerivce)
        {
            _tokenService = tokenService;

            _userService = userSerivce;
        }

        [HttpPost]
        public IHttpActionResult Refresh(TokenModel token)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(token.Token);
            var email = principal.Identity.Name; //this is mapped to the Name claim by default

            var user = _userService.GetByEmail(email);

            if (!_userService.IsValidUser(user.Email, token.RefreshToken))
            {
                return BadRequest();
            }

            var newJwtToken = _tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            _userService.UpdateRefreshToken(user.Id, newRefreshToken);
            
            return Ok(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }

        //[HttpPost, Authorize]
        //public IHttpActionResult Revoke()
        //{
        //    var email = User.Identity.Name;

        //    var user = _userService.GetByEmail(email);
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }

        //    _userService.RevokeRefreshToken(user.Id);

        //    return Ok();
        //}
    }
}

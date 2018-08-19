using Backend.Api.Helpers;
using Backend.Api.Models;
using Backend.Api.Services;
using Backend.BusinessLogic;
using Backend.BusinessLogic.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace Backend.Api.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private IUserService Servicio { get; set; }
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        private ILog Log { get; set; }
        public UsersController(IUserService _serv, ILog _log, ITokenService _tokenService, IPasswordHasher _passwordHasher)
        {
            this.Servicio = _serv;
            this.Log = _log;
            this._tokenService = _tokenService;
            this._passwordHasher = _passwordHasher;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            this.Log.Info("Prueba en api");
            var rta = this.Servicio.GetAll();

            return Ok(rta);
        }

        [HttpPost]
        public IHttpActionResult Create(CreateUserRequestDTO dto)
        {
            dto.Password = _passwordHasher.GenerateIdentityV3Hash(dto.Password);

            this.Servicio.Create(dto);

            return Ok();
        }
    }
}
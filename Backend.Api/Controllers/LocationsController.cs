using Backend.Api.Helpers;
using Backend.Api.Models;
using Backend.BusinessLogic.DTO.Request;
using Backend.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Backend.Api.Controllers
{
    [RoutePrefix("api/locations")]
    public class LocationsController : ApiController
    {
        private ILocationService Servicio { get; set; }
        private ILog Log { get; set; }
        public LocationsController(ILocationService _serv, ILog _log)
        {
            this.Servicio = _serv;
            this.Log = _log;          
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {            
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Create(CreateLocationRequestDTO dto)
        {
            //this layer must validate dto
            this.Servicio.Create(dto);
            return Ok(dto);
        }
    }
}
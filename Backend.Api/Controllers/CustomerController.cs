using Backend.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Backend.Api.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        [HttpGet, Authorize]
        public IHttpActionResult GetAll()
        {
            List<CustomerModel> list = new List<CustomerModel>();

            list.Add(new CustomerModel(Guid.NewGuid(), "Fernando", 31));
            list.Add(new CustomerModel(Guid.NewGuid(), "Maria", 61));
            list.Add(new CustomerModel(Guid.NewGuid(), "Jose", 20));

            return Ok(list);
        }
    }
}
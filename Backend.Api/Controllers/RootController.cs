using System.Web.Http;

namespace Backend.Api.Controllers
{
    /// <summary>
    /// customer controller class for testing security token 
    /// </summary>    
    [RoutePrefix("/")]
    public class RootController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok("isRunning");
        }        
    }
}

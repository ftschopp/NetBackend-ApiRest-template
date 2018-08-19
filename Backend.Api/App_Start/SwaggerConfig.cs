using System.Web.Http;
using WebActivatorEx;
using Backend.Api;
using Swashbuckle.Application;
using Backend.Api.App_Start;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Backend.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Backend.Api");
                        c.OperationFilter<AddAuthorizationHeaderParameterOperationFilter>();
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}

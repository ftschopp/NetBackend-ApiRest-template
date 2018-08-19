using System;
using System.Net.Http.Headers;
using System.Web.Http;
using Backend.Api.Controllers;
using Backend.Api.App_Start;

namespace Backend.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            // Configuración de rutas y servicios de API
            config.MapHttpAttributeRoutes();
            
            config.MessageHandlers.Add(new TokenValidationHandler());
                        
            config.Routes.MapHttpRoute(
                name: "Index",
                routeTemplate: "",                
                defaults: new { controller = "Root", action = "Index" }
            );

            config.Routes.MapHttpRoute(
                name: "Api",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new LogRequestAndResponseHandler());
        }
    }
}

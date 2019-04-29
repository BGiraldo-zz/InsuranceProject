using Insurance.Domain.AggregatesModel.ClientAggregate;
using Insurance.Domain.AggregatesModel.PolicyAggregate;
using Insurance.Domain.AggregatesModel.PolicyDetailAggregate;
using Insurance.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.WebApi;

namespace Insurance.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Unity configuration
            var container = new UnityContainer();
            container.RegisterType<IClientRepository, ClientRepository>();
            container.RegisterType<IPolicyRepository, PolicyRepository>();
            container.RegisterType<IPolicyDetailRepository, PolicyDetailRepository>();
            config.DependencyResolver = new UnityDependencyResolver(container);

            //this
            config.DependencyResolver = new UnityDependencyResolver(container);

            // CORS
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

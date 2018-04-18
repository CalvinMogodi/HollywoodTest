using HollywoodTest.API.App_Start;
using HollywoodTest.Business.Interface;
using HollywoodTest.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace HollywoodTest.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Dependency injection
            var container = new UnityContainer();
            container.RegisterType<IEventRepository, EventRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEventDetailRepository, EventDetailRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITournamentRepository, TournamentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IErrorLogRepository, ErrorLogRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}

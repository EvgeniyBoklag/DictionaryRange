using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebApiTestApplication.Filters;
using WebApiTestApplication.Services;

namespace WebApiTestApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional}
                );
            
            // register custom exception filter
            config.Filters.Add(new WordsRangeExceptionFilter());

            // setup autofac dependency container.
            SetupResolver(config);
        }

        private static void SetupResolver(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            ConfigurationManager.AppSettings["wordsDictionary:FilePath"]);
            builder.Register(c => new WordsRangeService(path)).As<IWordsRangeService>().SingleInstance();

            builder.RegisterAssemblyTypes(
                Assembly.GetExecutingAssembly())
                .Where(t =>
                    !t.IsAbstract && typeof (ApiController).IsAssignableFrom(t)).InstancePerLifetimeScope();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
        }
    }
}
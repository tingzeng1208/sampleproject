﻿using System.Web.Http;
using System.Web.Http.Filters;
using BusinessEntities;
using Common;
using Core;
using Core.Factories;
using Core.Services.Users;
using Data;
using Data.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using WebApi_new.App_Start;

namespace WebApi_new
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();
            var lifestyle = Lifestyle.Scoped;
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            var assembly = typeof(WebApiConfig).Assembly;
            InitializeAssemblyInstancesService.Initialize(container, lifestyle, assembly);

            DataConfiguration.Initialize(container, lifestyle);
            CoreConfiguration.Initialize(container, lifestyle);



            container.RegisterWebApiControllers(config);

            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = config.DependencyResolver;

            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            settings.DateParseHandling = DateParseHandling.DateTime;
            settings.DefaultValueHandling = DefaultValueHandling.Include;
            settings.Converters.Add(new StringEnumConverter());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                                       "DefaultApi",
                                       "api/{controller}/{id}",
                                       new { id = RouteParameter.Optional }
                                      );

            config.Filters.AddRange(new IFilter[]
                                    {
                                        new ContextInitializeAttribute()
                                    });
        }
    }
}
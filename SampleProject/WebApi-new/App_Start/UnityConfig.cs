using BusinessEntities;
using Core.Factories;
using Core.Services.Users;
using Data.Repositories;
using System;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Lifetime;

namespace WebApi_new
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            //container.RegisterType<ICreateUserService, CreateUserService>(new ContainerControlledLifetimeManager());
            //container.RegisterType<IUpdateUserService, UpdateUserService>(); // if used
            //container.RegisterType<IUserRepository, UserRepository>();
            //container.RegisterType<IIdObjectFactory<User>, IdObjectFactory<User>>();// assumes this exists
            //DataConfiguration.Initialize(container, new HierarchicalLifetimeManager(), createIndexes: true);


            //IDocumentStore store = new DocumentStore { ConnectionStringName = "http://localhost:8080" }; // Replace with your connection details
            //store.Initialize();

            //// In your DI container configuration (e.g., Simple Injector):
            //container.RegisterPerWebRequest<IDocumentSession>(() => store.OpenSession());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
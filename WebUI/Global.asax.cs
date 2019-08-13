using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BLL.Services;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Web;
using Castle.MicroKernel;
using GlobalWindsor;
using Castle.MicroKernel.Registration;
using System.Reflection;
using Castle.MicroKernel.SubSystems.Configuration;
using BLL.Interfaces;
using DAL.Abstraction;
using DAL.EntityFramework;
using System.Data.Entity;

namespace WebUI
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            this._kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }

            return (IController)_kernel.Resolve(controllerType);
        }
    }

    //public static class IocContainer
    //{
    //    private static IWindsorContainer _container;

    //    public static void Setup()
    //    {
    //        _container = new WindsorContainer().Install(FromAssembly.This());

    //        WindsorControllerFactory controllerFactory = new WindsorControllerFactory(_container.Kernel);
    //        ControllerBuilder.Current.SetControllerFactory(controllerFactory);
    //    }
    //}

    public class ControllersInstaller : IWindsorInstaller
    {
        private readonly Assembly _assembly;

        public ControllersInstaller(Assembly assembly)
        {
            _assembly = assembly;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Component
            //.For<DbContext>().ImplementedBy<CoffeeShopDbContext>());
            //container.Register(Component.For(typeof(IProductRepository)).ImplementedBy(typeof(ProductRepository)));
            //container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>());
            //container.Register(Component.For<IFactoryRepository>().ImplementedBy<FactoryRepository>()
            //        .DependsOn(Dependency.OnValue(typeof(IWindsorContainer), container)));
            //container.Register(Component.For<IProductManager>().ImplementedBy<ProductManager>());
            container.Register(Classes
                .FromAssembly(_assembly)
                .BasedOn<Controller>().LifestyleTransient());


        }
    }

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MapperConfigurator.Configure();


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = Windsor.Container;
            Windsor.Initialize();

            GlobalContainer.Initialize(new ControllersInstaller(Assembly.GetExecutingAssembly()));
            var controllerFactory = new WindsorControllerFactory(GlobalContainer.Container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}

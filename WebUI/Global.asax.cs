using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BLL.Services;
using GlobalWindsor;
using System.Reflection;
using Ioc.Installers;
using WebUI.Windsor;
using System.Web.Http;
using WebUI.App_Start;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configure(WebApiConfig.Register);
            MapperConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // вот тут 
            GlobalContainer.Initialize(new DatabasesInstaller());
            GlobalContainer.Initialize(new RepositoriesInstaller());
            GlobalContainer.Initialize(new ServicesInstaller());

            GlobalContainer.Initialize(new ControllersInstaller(Assembly.GetExecutingAssembly()));
            var controllerFactory = new WindsorControllerFactory(GlobalContainer.Container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

        }
    }
}

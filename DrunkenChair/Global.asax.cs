using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using System.Reflection;
using System.ComponentModel.Composition.Hosting;

namespace Niklasson.DrunkenChair
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
         
            //var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            //var composition = new CompositionContainer(catalog, true);
            //IControllerFactory mefControllerFactory = new CharacterConstructionControllerFactory(composition);
            //ControllerBuilder.Current.SetControllerFactory(mefControllerFactory);
        }

        protected void Application_EndRequest()
        {//here breakpoint
            // under debug mode you can find the exceptions at code: this.Context.AllErrors
        }
    }
}

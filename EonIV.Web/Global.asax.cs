using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Niklasson.DrunkenChair;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Web.CustomBinders;

namespace Niklasson.EonIV.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(CharacterModifierNode), new CharacterModifierNodeModelBinder());
            ModelBinders.Binders.Add(typeof(IRuleBookEvent), new IRuleBookEventModelBinder());
        }

        protected void Application_EndRequest()
        {
            //breakpoint here
            // under debug mode you can find the exceptions at code: this.Context.AllErrors
        }
    }
}

using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Niklasson.EonIV.Web;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Web.CustomBinders;

namespace Niklasson.EonIV.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(CharacterModifierNode), new CharacterModifierNodeModelBinder());
            ModelBinders.Binders.Add(typeof(IRuleBookEvent), new IRuleBookEventModelBinder());


            //Database.SetInitializer(new DropCreateDatabaseAlways<EonIVCharacterGenerationDbContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EonIVCharacterGenerationDbContext>());
        }

        protected void Application_EndRequest()
        {
            //breakpoint here
            // under debug mode you can find the exceptions at code: this.Context.AllErrors
        }
    }
}

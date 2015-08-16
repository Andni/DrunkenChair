using System;
using System.Web.Mvc;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.Web.CustomBinders
{
    public class IRuleBookEventModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            var type = typeof(RuleBookEvent);
            var model = Activator.CreateInstance(type);
            bindingContext.ModelMetadata = System.Web.Mvc.ModelMetadataProviders.Current.GetMetadataForType(() => model, type);

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}
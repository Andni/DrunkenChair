using System;
using System.Web.Mvc;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.Web.CustomBinders
{
    public class CharacterModifierNodeModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var typeValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".ConcreteModelType");
            var typeString = (string) typeValue.ConvertTo(typeof (string));
            Type type;
            try
            {
                type = Type.GetType(typeString + ", EonIV.Models", true);
            }
            catch (TypeLoadException e)
            {
                type = Type.GetType(typeString + ", EntityFrameworkDynamicProxies-EonIV.Models", true);
            }

            if (!typeof(CharacterModifierNode).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(type + " is not a subclass of" + typeof(CharacterModifierNode).ToString() + ", unable to bind model.");
            }

            var model = Activator.CreateInstance(type);
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, type);

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}
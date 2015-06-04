using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Niklasson.DrunkenChair.DatabaseTables;

namespace Niklasson.DrunkenChair.CustomBinders
{
    public class CharacterModifierModelMinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var typeValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".ConcreteModelType");
            var type = Type.GetType((string) typeValue.ConvertTo(typeof(string)), true);
            if(!typeof(EonIVCharacterModifier).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(typeValue + " is not a subclass of" + typeof(EonIVCharacterModifier).ToString() + ", unable to bind model.");
            }

            var model = Activator.CreateInstance(type);
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, type);

 	        return base.BindModel(controllerContext, bindingContext);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Models;
using Niklasson.DrunkenChair.Character.Helpers;

namespace Niklasson.DrunkenChair.DatabaseTables
{
    public class AttributeModification : EonIVCharacterModifier
    {
        public int ID { get; set; }
        public Niklasson.DrunkenChair.Character.Attribute Attribute { get; set; }
        public int Value { get; set; }
        
        public void AddDie(int dies = 1)
        {
            Value += dies * EonIVValue.valuePerD6;
        }

        public void SubtractDie(int dies = 1)
        {
            Value -= dies * EonIVValue.valuePerD6;
        }

        public override string ToString()
        {
            var sign = Value > 0 ? "+" : "-";
            return AttributeHelper.GetAttributeTranslation(Attribute) + " " + 
                sign + Value.ToString();
        }
    }
}
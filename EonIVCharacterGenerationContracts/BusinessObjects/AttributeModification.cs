using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.EonIV.CharacterGeneration.Contracts;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public class AttributeModification : CharacterModifier
    {
        public int ID { get; set; }
        public Attribute Attribute { get; set; }
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
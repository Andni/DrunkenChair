using System.ComponentModel.DataAnnotations.Schema;
using Niklasson.EonIV.Models.BusinessObjects.Helpers;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class AttributeModification : CharacterModifier
    {
        public Attribute Attribute { get; set; }

        [Column("AttributeValue")]
        public int Value { get; set; }

        public override string ConcreteModelType
        {
            get { return typeof (AttributeModification).ToString(); }
        }

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
using System.ComponentModel.DataAnnotations;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Perk : CharacterModifier
    {
        public override string ConcreteModelType
        {
            get { return typeof (Perk).ToString(); }
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Perk : CharacterModifier
    {
        [Required]
        public string Description { get; set; }

        public override string ConcreteModelType
        {
            get { return typeof (Perk).ToString(); }
        }
    }
}
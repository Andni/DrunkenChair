using System.ComponentModel.DataAnnotations;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Perk : CharacterModifier
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
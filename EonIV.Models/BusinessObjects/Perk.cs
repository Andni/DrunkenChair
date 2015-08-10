using System.ComponentModel.DataAnnotations;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Perk : CharacterModifier
    {
        [Required]
        public string Description { get; set; }
    }
}
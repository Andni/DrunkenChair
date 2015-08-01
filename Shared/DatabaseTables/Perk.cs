using System.ComponentModel.DataAnnotations;

namespace Shared.DatabaseTables
{
    public class Perk : EonIVCharacterModifier
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
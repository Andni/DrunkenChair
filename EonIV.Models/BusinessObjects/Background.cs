using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Background
    {
        public int Number { get; set; }
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public EventTableRolls EventRolls { get; set; } = new EventTableRolls();


        public int? ModificationContainerId { get; set; }

        [ForeignKey("ModificationContainerId")]
        public virtual CharacterModifierContainer Modifications { get; set; } = new CharacterModifierContainer();
        
        public static implicit operator string(Background b)
        {
            return b.ToString();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
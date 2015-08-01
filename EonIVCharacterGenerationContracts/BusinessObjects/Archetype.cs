using System.ComponentModel.DataAnnotations;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Archetype
    {
        public Archetype()
        {
            EventRolls = new EventTableRolls();
        }

        [Key]
        public string Name { get; set; }
        [Display(Name = "Events")]
        public EventTableRolls EventRolls { get; set; }

        public static implicit operator string(Archetype a)
        {
            return a.ToString();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}


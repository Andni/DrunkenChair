using System.ComponentModel.DataAnnotations;

namespace Shared.DatabaseTables
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


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Niklasson.DrunkenChair.DatabaseTables;


namespace Niklasson.DrunkenChair.Character
{
    [ComplexType]
    public class CharacterBasics
    {
        [Display(Name = "Bakgrund")]
        public Background Background{ get; set; }

        [Display(Name = "Arketyp")]
        public Archetype Archetype { get; set; }

        [Display(Name = "Folkslag")]
        public Race Race { get; set; }

        [Display(Name = "Miljö")]
        public Environment Environment { get; set; }

        public EventTableRolls GetEventRolls()
        {
            return Background.EventRolls + Archetype.EventRolls
                + Environment.EventRolls + Race.EventRolls;
        }
    }
}
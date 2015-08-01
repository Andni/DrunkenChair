using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    [ComplexType]
    public class CharacterBasics : ICharacterBasics
    {
        public CharacterBasics()
        {
            Archetype = new Archetype();
            Background = new Background();
            Environment = new Environment();
            Race = new Race();
        }

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

        public CharacterBasicChoices ToBasicChoices()
        {
            return new CharacterBasicChoices()
            {
                SelectedArchetype = Archetype,
                SelectedBackground = Background,
                SelectedEnvironment = Environment,
                SelectedRace = Race
            };
        }
    }
}
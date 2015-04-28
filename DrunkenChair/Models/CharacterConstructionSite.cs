using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Character;
using Niklasson.DrunkenChair.DatabaseTables;

namespace Niklasson.DrunkenChair.Model
{
    public class CharacterConstructionSite
    {
        //first step
        public CharacterBasics BasicsDetails { get; set; }

        //second step
        public CharacterBaseAttributeSet BonusDiceDistribution { get; set; }
        
        //third step
        public CharacterEvents RolledEvents { get; set; }

        public EonIvCharacter Character
        {
            get
            {
                return GetCharacterPreview();
            }
        }
        
        
        public EonIVCharacterScaffolding Scaffolding { get; set; }

        public CharacterSkills SkillSet = new CharacterSkills();

        public EventTableRolls GetEventRolls()
        {
            return BasicsDetails.GetEventRolls();
        }

        public EonIvCharacter GetCharacterPreview()
        {
            var c = new EonIvCharacter()
            {
                Archetype = BasicsDetails.Archetype ?? new Archetype(),
                Background = BasicsDetails.Background ?? new Background(),
                Environment = BasicsDetails.Environment ?? new Environment(),
                Race = BasicsDetails.Race ?? new Race(),
                Skills = SkillSet
            };

            CharacterBaseAttributeSet attributes = BonusDiceDistribution ?? new CharacterBaseAttributeSet();
            if(BasicsDetails.Race != null)
            {
                attributes += BasicsDetails.Race.StartingAttributes;
            }
            c.Attributes = new CharacterAttributeSet(attributes);

            return c;
        }

        public CharacterConstructionSite()
        {
            BasicsDetails = new CharacterBasics();
            Scaffolding = new EonIVCharacterScaffolding();
        }
    }
}
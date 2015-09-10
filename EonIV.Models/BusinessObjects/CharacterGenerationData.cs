using System.Linq;
using System.Collections.Generic;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterGenerationData
    {
        private CharacterData character;

        public CharacterGenerationData(CharacterData character)
        {
            this.character = character;
        }

        public EventTableRolls EventRolls
        {
            get
            {
                return character.Basics.GetEventRolls();
            }
        }

        public CharacterBaseAttributeSet BonusDiceDistribution { get; set; }

        public Skillpoints Skillpoints {
            get
            {
                var e = character.Events.GetModifiers();

                List<CategorySkillPoints> eventSkillpoints = new List<CategorySkillPoints>();
                if (e != null)
                {
                    eventSkillpoints = e.Where(x => x is CategorySkillPoints).Cast<CategorySkillPoints>().ToList();
                }
                return character.Basics.Archetype.Skillpoints + character.Basics.Environment.Skillpoints
                    + eventSkillpoints;
            }
        }
    }
}

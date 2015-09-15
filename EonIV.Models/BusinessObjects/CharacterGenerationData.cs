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
                return character.GetEventRolls();
            }
        }

        public CharacterBaseAttributeSet BonusDiceDistribution { get; set; }

        public Skillpoints Skillpoints {
            get
            {
                return character.GetSkillpoints();
            }
        }
    }
}

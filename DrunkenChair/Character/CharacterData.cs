using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Models;

namespace Niklasson.DrunkenChair.Character
{
    public class CharacterData
    {

        public CharacterBasics Basics { get; set; }
        public CharacterAttributeSet Attributes { get; set; }
        public CharacterEvents Events { get; set; }

        public CharacterSkills SkillSet { get; set; }

        public CharacterData()
        {
            Basics = new CharacterBasics();
            Attributes = new CharacterAttributeSet();
            Events = new CharacterEvents();
            SkillSet = new CharacterSkills();
        }

        public EonIvCharacterSheet ToCharacterSheet()
        {
            return new EonIvCharacterSheet()
            {
                Archetype = Basics.Archetype,
                Background = Basics.Background,
                Environment = Basics.Environment,
                Race = Basics.Race,

                Attributes = this.Attributes
            };
        }
    }
}
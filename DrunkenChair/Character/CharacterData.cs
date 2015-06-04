using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Models;

namespace Niklasson.DrunkenChair.Character
{
    public class CharacterData
    {
        private CharacterMetaData scaffolding;
        private CharacterBaseAttributeSet attributeBonusDices = new CharacterBaseAttributeSet();

        public CharacterData()
        {
            scaffolding = new CharacterMetaData(this);
            Basics = new CharacterBasics();
            RolledEvents = new RolledEvents();
            SkillSet = new CharacterSkills();
        }

        public CharacterBasics Basics { get; set; }
        public RolledEvents RolledEvents { get; set; }

        public CharacterMetaData Scaffolding
        {
            get
            {
                return scaffolding;
            }
        }

        public CharacterAttributeSet Attributes
        {
            get
            {
                CharacterBaseAttributeSet baseAttributes = new CharacterBaseAttributeSet();
                if(Basics.Race != null)
                {
                    baseAttributes += Basics.Race.StartingAttributes;
                }
                if(attributeBonusDices != null)
                {
                    baseAttributes += attributeBonusDices;
                }
                 CharacterAttributeSet res = new CharacterAttributeSet(baseAttributes);
                return res;
            }
        }
        
        public CharacterBaseAttributeSet AttributeBonusDices
        {
            get{
                if(attributeBonusDices == null)
                {
                    return new CharacterBaseAttributeSet();
                }
                else
                { 
                    return attributeBonusDices;
                }
            }
            set { attributeBonusDices = value; }
        }

        public CharacterSkills SkillSet { get; set; }

        public CharacterBasicDetails GetBasicDetails()
        {
            return new CharacterBasicDetails()
            {
                SelectedArchetype = Basics.Archetype,
                SelectedBackground = Basics.Background,
                SelectedEnvironment = Basics.Environment,
                SelectedRace = Basics.Race
            };
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
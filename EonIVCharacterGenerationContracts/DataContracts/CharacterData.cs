﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public class CharacterData
    {
        private CharacterMetaData scaffolding;
        private CharacterBaseAttributeSet attributeBonusDices = new CharacterBaseAttributeSet();

        public CharacterData()
        {
            scaffolding = new CharacterMetaData(this);
            Basics = new CharacterBasics();
            Events = new CharacterEventSet();
            SkillSet = new CharacterSkills();
        }

        public CharacterBasics Basics { get; set; }
        public CharacterEventSet Events { get; set; }
        //public List<EventViewModel> Events { get; set; }

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

        public ICharacterBasicChoices GetBasicDetails()
        {
            return new CharacterBasicDetails()
            {
                SelectedArchetype = Basics.Archetype,
                SelectedBackground = Basics.Background,
                SelectedEnvironment = Basics.Environment,
                SelectedRace = Basics.Race
            };
        }

        public EonIVCharacterSheet ToCharacterSheet()
        {
            return new EonIVCharacterSheet()
            {
                Archetype = Basics.Archetype,
                Background = Basics.Background,
                Environment = Basics.Environment,
                Race = Basics.Race,

                Attributes = this.Attributes
            };
        }


        public CharacterData Modify(CharacterBaseAttributeSet a)
        {
            this.Attributes.Base += a;
            return this;
        }

        public CharacterData Modify(CharacterSkill s)
        {
            this.SkillSet.Add(s);
            return this;
        }
    }
}
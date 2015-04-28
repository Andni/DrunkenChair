using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Niklasson.DrunkenChair.DatabaseTables;
using Niklasson.DrunkenChair.Character;

using Niklasson.DrunkenChair.Model;

namespace Niklasson.DrunkenChair.Character
{

    [ComplexType]
    [System.Runtime.Serialization.DataContract(IsReference=true)]
    public class CharacterAttributeSet : CharacterBaseAttributeSet, ICharacterAttributes
    {
        [System.Web.Script.Serialization.ScriptIgnore]
        public CharacterBaseAttributeSet Base { get { return (CharacterBaseAttributeSet)this; }
            set {
                if(value == null)
                {
                    return;
                }
                Strength = value.Strength;
                Stamina = value.Stamina;
                Agility = value.Agility;
                Perception = value.Perception;
                Will = value.Will;
                Psyche = value.Psyche;
                Wisdom = value.Wisdom;
                Charisma = value.Charisma; 
            }
        }
        
        [System.Runtime.Serialization.IgnoreDataMember]
        [System.Web.Script.Serialization.ScriptIgnore]
        public CharacterAttributeSet Derived { get { return this; } }

        public DiceRollCheck BonusBuild { get; set; }
        public DiceRollCheck BonusImpression { get; set; }
        public DiceRollCheck BonusLifeforce { get; set; }
        public DiceRollCheck BonusMovement { get; set; }
        public DiceRollCheck BonusReaction { get; set; }
        public DiceRollCheck BonusSelfcontrol { get; set; }
        public DiceRollCheck BonusVigilance { get; set; }

        public CharacterAttributeSet() : base()
        {
            BonusBuild = 0;
            BonusImpression = 0;
            BonusLifeforce = 0;
            BonusMovement = 0;
            BonusReaction= 0;
            BonusSelfcontrol = 0;
            BonusVigilance = 0;
        }

        public CharacterAttributeSet(CharacterBaseAttributeSet baseAttributes)
        {
            Base = baseAttributes;
        }

        public DiceRollCheck Movement
        {
            get
            {
                return BonusMovement + (Agility + Stamina) / 2;
            }
        }

        public DiceRollCheck Impression
        {
            get
            {
                return BonusImpression + (Wisdom + Charisma) / 2;
            }
        }

        public DiceRollCheck Build
        {
            get
            {
                return BonusBuild + (Strength + Stamina) / 2;
            }
        }

        public DiceRollCheck Lifeforce
        {
            get
            {
                return BonusLifeforce + (Will + Stamina) / 2;
            }
        }

        public DiceRollCheck Reaction
        {
            get
            {
                return BonusReaction + (Agility + Perception) / 2;
            }
        }

        public DiceRollCheck Selfcontrol
        {
            get
            {
                return BonusSelfcontrol + (Will + Psyche) / 2;
            }
        }

        public DiceRollCheck Vigilance
        {
            get
            {
                return BonusVigilance + (Perception + Psyche) / 2;
            }
        }

     

        public static CharacterAttributeSet operator +(CharacterAttributeSet lh, CharacterAttributeSet rh)
        {
            lh.Agility += rh.Agility;
            lh.Charisma += rh.Charisma;
            lh.Perception += rh.Perception;
            lh.Psyche += rh.Psyche;
            lh.Stamina += rh.Stamina;
            lh.Strength += rh.Strength;
            lh.Will += rh.Will;
            lh.Wisdom += rh.Wisdom;

            lh.BonusBuild += rh.BonusBuild;
            lh.BonusImpression += rh.BonusImpression;
            lh.BonusLifeforce += rh.BonusLifeforce;
            lh.BonusMovement += rh.BonusMovement;
            lh.BonusReaction += rh.BonusReaction;
            lh.BonusSelfcontrol += rh.BonusSelfcontrol;
            lh.BonusVigilance += rh.BonusVigilance;
            
            return lh;
        }
        
    }
}
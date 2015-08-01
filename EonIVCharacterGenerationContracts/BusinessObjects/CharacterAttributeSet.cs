using System.ComponentModel.DataAnnotations.Schema;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
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
        
        public CharacterAttributeSet() : base() { }

        public CharacterAttributeSet(CharacterBaseAttributeSet baseAttributes)
        {
            Base = baseAttributes;
        }

        public DiceRollCheck Movement
        {
            get
            {
                return //BonusMovement + 
                    (Agility + Stamina) / 2;
            }
        }

        public DiceRollCheck Impression
        {
            get
            {
                return //BonusImpression + 
                    (Wisdom + Charisma) / 2;
            }
        }

        public DiceRollCheck Build
        {
            get
            {
                return //BonusBuild + 
                    (Strength + Stamina) / 2;
            }
        }

        public DiceRollCheck Lifeforce
        {
            get
            {
                return //BonusLifeforce + 
                    (Will + Stamina) / 2;
            }
        }

        public DiceRollCheck Reaction
        {
            get
            {
                return //BonusReaction + 
                    (Agility + Perception) / 2;
            }
        }

        public DiceRollCheck Selfcontrol
        {
            get
            {
                return //BonusSelfcontrol + 
                    (Will + Psyche) / 2;
            }
        }

        public DiceRollCheck Vigilance
        {
            get
            {
                return //BonusVigilance +
                    (Perception + Psyche) / 2;
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

            return lh;
        }
        
    }
}
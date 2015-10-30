using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{

    [ComplexType]
    [DataContract(IsReference=true)]
    public class CharacterAttributeSet : CharacterBaseAttributeSet, ICharacterAttributes
    {
        [ScriptIgnore]
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
        
        public static CharacterAttributeSet operator +(CharacterAttributeSet lh, ICharacterBaseAttributes rh)
        {
            return new CharacterAttributeSet
            {
                Agility = lh.Agility + rh.Agility,
                Charisma = lh.Charisma + rh.Charisma,
                Perception = lh.Perception + rh.Perception,
                Psyche = lh.Psyche + rh.Psyche,
                Stamina = lh.Stamina + rh.Stamina,
                Strength = lh.Strength + rh.Strength,
                Will = lh.Will + rh.Will,
                Wisdom = lh.Wisdom + rh.Wisdom,
            };
        }
        
        public static CharacterAttributeSet operator +(CharacterAttributeSet lh, IBaseAttributeDices rh)
        {
            return new CharacterAttributeSet
            {
                Agility = new DiceRollCheck(lh.Agility).AddDice(rh.AgilityBonusDices),
                Charisma = new DiceRollCheck(lh.Charisma).AddDice(rh.CharismaBonusDices),
                Perception = new DiceRollCheck(lh.Perception).AddDice(rh.PerceptionBonusDices),
                Psyche = new DiceRollCheck(lh.Psyche).AddDice(rh.PsycheBonusDices),
                Stamina = new DiceRollCheck(lh.Stamina).AddDice(rh.StaminaBonusDices),
                Strength = new DiceRollCheck(lh.Strength).AddDice(rh.StrengthBonusDices),
                Will = new DiceRollCheck(lh.Will).AddDice(rh.WillBonusDices),
                Wisdom = new DiceRollCheck(lh.Wisdom).AddDice(rh.WisdomBonusDices),
            };
        }
        
    }
}
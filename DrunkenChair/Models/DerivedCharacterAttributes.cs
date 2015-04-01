using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrunkenChair.Models
{
    [ComplexType]
    [System.Runtime.Serialization.DataContract(IsReference=true)]
    public class DerivedCharacterAttributes : CharacterBaseAttributes, ICharacterAttributes
    {
        [System.Web.Script.Serialization.ScriptIgnore]
        public CharacterBaseAttributes Base { get { return (CharacterBaseAttributes)this; }
            set {
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
        public DerivedCharacterAttributes Derived { get { return this; } }

        public Attribute BonusBuild { get; set; }
        public Attribute BonusImpression { get; set; }
        public Attribute BonusLifeforce { get; set; }
        public Attribute BonusMovement { get; set; }
        public Attribute BonusReaction { get; set; }
        public Attribute BonusSelfcontrol { get; set; }
        public Attribute BonusVigilance { get; set; }

        public DerivedCharacterAttributes() : base()
        {
            BonusBuild = 0;
            BonusImpression = 0;
            BonusLifeforce = 0;
            BonusMovement = 0;
            BonusReaction= 0;
            BonusSelfcontrol = 0;
            BonusVigilance = 0;
        }

        public Attribute Movement
        {
            get
            {
                return BonusMovement + (Agility + Stamina) / 2;
            }
        }

        public Attribute Impression
        {
            get
            {
                return BonusImpression + (Wisdom + Charisma) / 2;
            }
        }

        public Attribute Build
        {
            get
            {
                return BonusBuild + (Strength + Stamina) / 2;
            }
        }

        public Attribute Lifeforce
        {
            get
            {
                return BonusLifeforce + (Will + Stamina) / 2;
            }
        }

        public Attribute Reaction
        {
            get
            {
                return BonusReaction + (Agility + Perception) / 2;
            }
        }

        public Attribute Selfcontrol
        {
            get
            {
                return BonusSelfcontrol + (Will + Psyche) / 2;
            }
        }

        public Attribute Vigilance
        {
            get
            {
                return BonusVigilance + (Perception + Psyche) / 2;
            }
        }

        public static DerivedCharacterAttributes operator +(DerivedCharacterAttributes lh, DerivedCharacterAttributes rh)
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
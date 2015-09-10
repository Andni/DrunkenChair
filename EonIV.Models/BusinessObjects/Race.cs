using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Niklasson.EonIV.Models.DataTypes; 

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Race
    {
        [Key]
        public string Name { get; set; }

        public CharacterBaseAttributeSet StartingAttributes {get; set;} = new CharacterBaseAttributeSet();
        
        public int? PerkContainerId { get; set; }

        [ForeignKey("PerkContainerId")]
        public virtual CharacterModifierContainer Perks { get; set; }
        
        public virtual List<Language> Laguages { get; set; } = new List<Language>(); 

        public static implicit operator string(Race r)
        {
            return r.ToString();
        }

        public override string ToString()
        {
            return Name;
        }

        public static List<Race> GetRaces()
        {
            return new List<Race>
            {
                new Race
                {
                    Name = "Adasier",
                    StartingAttributes = new CharacterBaseAttributeSet
                    {
                        Strength = new DiceRollCheck(1, 2),
                        Stamina = new DiceRollCheck(2, 3),
                        Agility = new DiceRollCheck(3, 0),
                        Perception = new DiceRollCheck(2, 2),
                        Will = new DiceRollCheck(2, 1),
                        Psyche = new DiceRollCheck(1, 3),
                        Wisdom = new DiceRollCheck(1, 0),
                        Charisma = new DiceRollCheck(1, 3)
                    },
                    Perks = null
                },

                new Race
                {
                    Name = "Cirefalier",
                    StartingAttributes = new CharacterBaseAttributeSet
                    {
                        Strength = new DiceRollCheck(2, 0),
                        Stamina = new DiceRollCheck(2, 0),
                        Agility = new DiceRollCheck(2, 0),
                        Perception = new DiceRollCheck(1, 2),
                        Will = new DiceRollCheck(2, 0),
                        Psyche = new DiceRollCheck(2, 0),
                        Wisdom = new DiceRollCheck(2, 2),
                        Charisma = new DiceRollCheck(2, 2),
                    },
                    Perks = null
                }
            };
        }

    }

    public class Language
    {
        [Key]
        public string Name { get; set; }

        //written and spoken languages are treated as separate entities
        //so we're using a bool to separate the types.
        public bool Written { get; set; }
    }
}
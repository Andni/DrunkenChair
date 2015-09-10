using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Archetype
    {
        [Key]
        public string Name { get; set; }

        [Display(Name = "Events")]
        public EventTableRolls EventRolls { get; set; } = new EventTableRolls();

        public Skillpoints Skillpoints { get; set; } = new Skillpoints();

        public int? ResourcesContainerId { get; set; }

        [ForeignKey("ResourcesContainerId")]
        public virtual CharacterModifierContainer Resources { get; set; }

    public static implicit operator string(Archetype a)
        {
            return a.ToString();
        }

        public override string ToString()
        {
            return Name;
        }

        public static List<Archetype> GetArchetypes()
        {
            return new List<Archetype>
            {
                new Archetype { Name = "Krigare", EventRolls = new EventTableRolls(1, 0, 0, 2, 0),
                Skillpoints = new Skillpoints
                { } },
                new Archetype { Name = "Mystiker", EventRolls = new EventTableRolls(0, 0, 2, 0, 1),
                    Skillpoints = new Skillpoints { Knowledge = 2, Mystic = 10, FreeChoise = 8 },
                    Resources = new CharacterModifierContainer
                    {
                        new WeaponVoucher
                        {
                            Label = "Beväpning",
                            Description = "Ett vanligt vapen.",
                            Rarity = WeaponRarity.COMMON,
                        },
                        new SpecialSkillPoints
                        {
                            Label = "Expertis",
                            Description = "1 poäng Expertiser.",
                            Category = SpecialSkillCategory.EXPERTISE,
                        }
                    }
                }
                
            };
        }
    }
    
}


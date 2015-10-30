using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Niklasson.EonIV.Models.DataTypes;

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

        public int? PickTwoResourcesContainerId { get; set; }

        [ForeignKey("ResourcesContainerId")]
        public virtual CharacterModifierContainer Resources { get; set; }

        [ForeignKey("PickTwoResourcesContainerId")]
        public virtual CharacterModifierContainerMultiChoice PickTwoResources { get; set; }
        
        public override string ToString()
        {
            return Name;
        }

        public static List<Archetype> GetArchetypes()
        {
            return new List<Archetype>
            {
                new Archetype
                {
                    Name = "Krigare", EventRolls = new EventTableRolls(1, 0, 0, 2, 0),
                    Skillpoints = new Skillpoints
                    {
                        Movement = 4,
                        Battle = 8,
                        FreeChoise = 8,
                    },
                    Resources = new CharacterModifierContainer
                    {
                        new CharacterModifierContainer("Beväpning", "Ett ovanligt vapen, två vanliga vapen samt utrustning för att hålla vapnen i gott skick.")
                        {
                            new WeaponVoucher
                            {
                                Rarity = WeaponRarity.Uncommon,
                            },
                            new WeaponVoucher
                            {
                                Rarity = WeaponRarity.Common,
                            },
                            new WeaponVoucher
                            {
                                Rarity = WeaponRarity.Common,
                            },
                        },
                        new SpecialSkillPoints
                        {
                            Category = SpecialSkillCategory.Expertise,
                            Points = 1
                        },
                        new ArmourSet
                        {
                            ValidMaterials = new List<string> { "Fjällpansar", "Lamellpansar", "Ringbrynja" },
                            Coverage = ArmourCoverage.All,
                        },
                    },
                    PickTwoResources =
                    new CharacterModifierContainerMultiChoice(2)
                    {
                        new JadednessCross
                        {
                            Type = JadednessType.Violence,
                            Crosses = 1,
                        },
                        new Resource
                        {
                            Label = "Blodstillande örter",
                            Description = "8 doser av blodstillande örter.",
                        },
                        new Resource
                        {
                            Label = "Riddjur",
                            Description = "En stridshäst.",
                        },
                        new ArmourSet
                        {
                            Coverage = ArmourCoverage.All,
                            ValidMaterials = new List<string>{ "Tunnplåt", "Plåt" },
                        },
                        new CharacterModifierContainerSingleChoice("Vapen", "Två ovanliga vapen eller ett sällsynt vapen.")
                        {
                            new CharacterModifierContainer("", "Två ovanliga vapen.")
                            {
                                new WeaponVoucher
                                {
                                    Rarity = WeaponRarity.Uncommon,
                                },
                                new WeaponVoucher
                                {
                                    Rarity = WeaponRarity.Uncommon,
                                }
                            },
                            new WeaponVoucher
                            {
                                Description = "Ett sällsynt vapen.",
                                Rarity = WeaponRarity.Rare,
                            }

                        },
                        new CharacterModifierContainerSingleChoice("Ytterligare vapen", "Två ovanliga vapen eller ett sällsynt vapen.")
                        {
                            new CharacterModifierContainer("", "Två ovanliga vapen.")
                            {
                                new WeaponVoucher
                                {
                                    Rarity = WeaponRarity.Uncommon,
                                },
                                new WeaponVoucher
                                {
                                    Rarity = WeaponRarity.Uncommon,
                                }
                            },
                            new WeaponVoucher
                            {
                                Description = "Ett sällsynt vapen.",
                                Rarity = WeaponRarity.Rare,
                            }

                        },
                        new RandomSilver
                        {
                            Dices = DiceRollCheck.CreateFromDice(4),
                            SilverMultiplier = 4,
                        }
                    }
                },
                new Archetype
                {
                    Name = "Mystiker", EventRolls = new EventTableRolls(0, 0, 2, 0, 1),
                    Skillpoints = new Skillpoints { Knowledge = 2, Mystic = 10, FreeChoise = 8 },
                    Resources = new CharacterModifierContainer
                    {
                        new WeaponVoucher
                        {
                            Label = "Beväpning",
                            Description = "Ett vanligt vapen.",
                            Rarity = WeaponRarity.Common,
                        },
                        new SpecialSkillPoints
                        {
                            Label = "Expertis",
                            Description = "1 poäng Expertiser.",
                            Category = SpecialSkillCategory.Expertise,
                        },
                        new HolyItemVoucher
                        {
                            Label = "Heligt föremål",
                            Description = "Ett heligt föremål.",
                        },
                        new MysteryVoucher
                        {
                            Label = "Mysterier",
                            Description = "6 Mysterier.",
                            NumberOfMysteries = 6,
                        },
                    },
                    PickTwoResources = new CharacterModifierContainerMultiChoice(2)
                    {
                        new JadednessCross
                        {
                            Type = JadednessType.Supernatural,
                            Crosses = 2,
                        },
                        new CharacterModifierContainer
                        {
                            new WeaponVoucher
                            {
                                Label = "Beväpning",
                                Rarity = WeaponRarity.Uncommon,
                            },
                            new CharacterModifierContainerSingleChoice
                            {
                                new ArmourSet
                                {
                                    Coverage = ArmourCoverage.All,
                                    ValidMaterials = new List<string> {"Härdat läder", "Nitläder", "Ringläder", "Fjällpansar", "Lamellpansar", "Ringbrynja" },
                                }
                            },
                            new HolyItemVoucher
                            {
                                Label = "Heligt föremål",
                                Description = "Ytterligare ett heligt föremål.",
                            },
                            new Apprentice
                            {
                                Label = "Lärling",
                                Description = "Rollpersinen har med sig en lärling. Slå två gånger på bakgrundstabellen och välj en som beskriver lärlingens härkomst.",
                            },
                            new Resource
                            {
                                Label = "Mästare",
                                Description = "Rollpersonen har god kontakt med en mästare inom sitt gebit. Mästaren kan hjälpa rollpersonen med problem av mystisk karaktär.",
                            },
                            new SpecialSkillVoucher
                            {
                                Label = "Specialträning",
                                Description = "Rollpersonen har fått särskilld bildning och får en valfri extertis som denne får 5T6 i. Exempel för en Daakpräst är Begravningsriter, Citera Libera, Flagellera, Helgonens liv, Kyrkor och heliga platser, Tolka religösa skrifter och Tortyr.",
                                Value = DiceRollCheck.CreateFromDice(5),
                            },
                            new RandomSilver
                            {
                                Label = "Pengar",
                                Description = "4T6x5 silver.",
                                SilverMultiplier = 5,
                                Dices = DiceRollCheck.CreateFromDice(4),
                            }
                        }
                    }
                }
            };
        }
    }
}


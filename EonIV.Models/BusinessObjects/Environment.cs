using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Environment
    {
        [Key]
        public string Name { get; set; }

        public string Description { get; set; }

        public EventTableRolls EventRolls { get; set; }

        public Skillpoints Skillpoints { get; set; }

        public int StartingSilver { get; set; }

        public int? GearAndResourcesContainerId { get; set; }

        [ForeignKey("GearAndResourcesContainerId")]
        public virtual CharacterModifierContainer GearAndResources { get; set; }

        public Environment()
        {
            EventRolls = new EventTableRolls();
            Skillpoints = new Skillpoints();
        }

        public Environment(string name, EventTableRolls eventRolls, Skillpoints skills)
        {
            Name = name;
            EventRolls = eventRolls;
            Skillpoints = skills;
        }

        public static implicit operator string(Environment e)
        {
            return e.ToString();
        }

        public override string ToString()
        {
            return Name;
        }

        public static List<Environment> GetEnvironments()
        {
            return new List<Environment>
            {
                new Environment {
                    Name = "Hav",
                    StartingSilver = 30,
                    EventRolls = new EventTableRolls
                    {
                        BattlesAndSkirmishes = 1,
                        TravlesAndAdventures = 1,
                        FreeChoise = 1
                    },
                    Skillpoints = new Skillpoints
                    {
                        Battle = 2,
                        Knowledge = 1,
                        Movement = 4,
                        Wilderness = 5
                    },
                    GearAndResources = new CharacterModifierContainer
                    {
                        new Resource
                        {
                            Label = "Fiskeutrustning",
                            Description = "Bestående av nät, 30 meter rev, fem krokar, renskniv och en korg.",
                            
                        },
                        new CharacterModifierContainerMultiChoice(2)
                        {
                            new JadednessCross
                            {
                                Label = "Avtrubbning",
                                Type = JadednessType.Vulnrability,
                                Crosses = 1
                            },
                            new Resource
                            {
                                Label = "Egendom",
                                Description = "Ett litet torp, en nedgången gård vid havet eller en våning i stadens sämre delar. Lever rollpersonen invid vattnet (hamnstad eller by vid kusten eller vattendrag så har denne även en roddbåt eller mindre segelbåt.",    
                            },
                            new SkillModification
                            {
                                SkillName = "Simma",
                                Label = "Som fisken i vattnet",
                                LearningModifier = LearningModifier.FastLearner,
                            },
                            new CategorySkillPoints
                            {
                                Label = "Språk",
                                Category = SkillCategory.Language,
                                SkillPoints = 2
                            },
                            new Resource
                            {
                                Label = "Tubkikare",
                                Description = "En tubkikare som gör det möjligt att se över stora avstånd. Bonus +1T6 på färdigheten speja vid situationer där tubkikaren kan användas.",
                            },
                            new RandomSilver
                            {
                                Dices = DiceRollCheck.CreateFromDice(4),
                                SilverMultiplier = 3
                            }
                        }
                    }
                },
                new Environment
                {
                    Name = "Hov",
                    StartingSilver = 100,
                    EventRolls = new EventTableRolls
                    {
                        IntrigueAndIlldeads = 2,
                        FreeChoise = 1
                    },
                    Skillpoints = new Skillpoints
                    {
                        Knowledge = 3,
                        Movement = 1,
                        Social = 8
                    },
                    GearAndResources = new CharacterModifierContainer
                    {
                        new Resource
                        {
                            Label = "Luxuösa kläder",
                            Description = "En uppsättning figursydda och lyxiga kläder av mycket god kvalitet. Smycken och värdeföremål värda 50 silver.",
                            
                        },
                        new CharacterModifierContainerMultiChoice(2)
                        {
                            new Resource
                            {
                                Label = "Egendom",
                                Description =
                                "Ett mindre gods på landet, ett ståtligt hus i stadens bättre delar eller en större våning i ett slott eller palats.",
                            },
                            new SkillModification
                            {
                                Label = "Född med silversked",
                                SkillName = "Hovliv",
                                LearningModifier = LearningModifier.FastLearner
                            },
                            new Resource
                            {
                                Label = "Slav eller tjänare",
                                Description = "En slav eller tjänare som lyder och passar upp rollpersonen."
                            },
                            new Resource
                            {
                                Label = "Ståtligt riddjur",
                                Description = "Ett ståtligt och präktigt riddjur, exempelvis en stridshäst, en snövit ridhäst eller något annat som drar till sig rppmärksamhet.",
                            },
                            new RandomSilver
                            {
                                Dices = DataTypes.DiceRollCheck.CreateFromDice(4),
                                SilverMultiplier = 10
                            }
                        }
                    }
                },
                new Environment
                {
                    Name = "Stad",
                    StartingSilver = 60,
                    EventRolls = new EventTableRolls
                    {
                        IntrigueAndIlldeads = 1,
                        KnowledgeAndMysteries = 1,
                        FreeChoise = 1
                    },
                    Skillpoints = new Skillpoints
                    {
                        Knowledge = 2,
                        Movement = 3,
                        Social = 5,
                        Battle = 2,
                    },
                    GearAndResources = new CharacterModifierContainer
                    {
                        new Resource
                        {
                            Label = "Finkläder",
                            Description = "En uppsättning finare kläder som man vanligen bär vid festligheter och högtider.",    
                        },
                        new JadednessCross
                        {

                            Label = "Avtrubbning",
                            Description = "I staden är det viktigt att hålla sig vän med rätt personer och inte tappa ansiktet. 1 avtrubbningskryss för utsatthet.",
                            Type = JadednessType.Vulnrability,
                            Crosses = 1,
                        },
                        new Resource
                        {
                            Label = "Egendom",
                            Description = "Ett litet hus i stadens sämre delar eller en våning i stadens bättre delar.",
                        },
                        new SpecialSkillPoints
                        {
                            Label = "Expertiser",
                            Description = "1 poäng Expertiser.",
                            Category = SpecialSkillCategory.Expertise,
                        },
                        new SpecialSkillPoints
                        {
                            Label = "Hantverk",
                            Description = "1 poäng Hantverk.",
                            Category = SpecialSkillCategory.Craft,
                        },
                        new CategorySkillPoints
                        {
                            Label = "Språk",
                            Description = "2 Språkenheter.",
                            Category = SkillCategory.Language,
                            SkillPoints = 2
                        },
                        new RandomSilver
                        {
                            Label = "Pengar",
                            Description = "4T6x6.",
                            SilverMultiplier = 6,
                            Dices = DiceRollCheck.CreateFromDice(4),
                        }
                    }
                }
            };
        }
    }

}
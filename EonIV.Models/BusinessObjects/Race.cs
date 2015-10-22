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

        public string Description { get; set; }

        public CharacterBaseAttributeSet StartingAttributes {get; set;} = new CharacterBaseAttributeSet();
        
        public int? PerkContainerId { get; set; }

        [ForeignKey("PerkContainerId")]
        public virtual CharacterModifierContainer Perks { get; set; }
        
        public virtual List<Language> Laguages { get; set; } = new List<Language>(); 
        
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
                    Perks = new CharacterModifierContainer
                    {
                        new CharacterModifierContainer ("Böjliga", "Asasier är smidiga och böjliga och kan lätt slingra sig ur red och bojor. De Börjar med expertisen utbrytarkonst 4T6. De får även 2 enheter Rörelsefärdigheter.")
                        {
                            new Expertise
                            {
                                SkillName = "Utrbytarkonst",
                            },
                            new CategorySkillPoints
                            {
                                Category = SkillCategory.Movement,
                                SkillPoints = 2,
                            }
                        },
                        new Perk
                        {
                            Label = "Dricka saltvatter",
                            Description = "Adasier kan dricka, och klara sig på, såväl bräckt som saltvatten. Saltet skiljs från vätskan och utsöndras via tårkanalerna likt små saltkristaller.",
                        },
                        new CharacterModifierContainer("Naturliga simmare", "Färdigheten simma är Lättlärd och adasiern börjar med 5T6 i den. Adasier har +3T6 på alla slag för att hålla andan.")
                        {
                            new SkillModification
                            {
                                SkillName = "Simma",
                                LearningModifier = LearningModifier.FastLearner,
                                Value = DiceRollCheck.CreateFromDice(5), //start value is 0 so adding 5 dices is correct
                            },
                            new Perk
                            {
                                Description = "+3T6 på alla slag för att hålla andan."
                            }
                        },
                        new CharacterModifierContainer("Träskens faror", "I Maazenträsken måste man lära sig bekämpa allehanda monster för att överleva. Alla närstridsvapen räknas som att de har vapenegenskapen Sargande i en adasiers händer. De får dessutom ett extra slag på händelsetabellen Färder & Äventyr.")
                        {
                            new EventRoll
                            {
                                EventCategory = EventCategory.TravelsAndAdventures,
                                Rolls = 1,
                            },
                            new Perk
                            {
                                Description = "Alla närstridsvapen i adasierns händer räknas som Sargande."
                            }
                        }
                    },
                    //Laguages = new List<Language>
                    //{
                    //    new Language
                    //    {
                    //        Name = "Adask",
                    //        Written = false,
                    //    },
                    //    new Language
                    //    {
                    //        Name = "Lägre Jargiska",
                    //        Written = false,
                    //    }
                    //}
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
                    Perks = new CharacterModifierContainer
                    {
                        new EventRoll
                        {
                            Label = "En plan i en plan",
                            Description = "1 extra slag på händelsetabellen Intriger & Illgärningar.",
                            EventCategory = EventCategory.IntrigueAndMisdeads,
                            Rolls = 1,

                        },
                        new Silver
                        {
                            Label = "Förmögenhet",
                            Description = "Cirfalier tycks alltid ha pengar i börsen. De börjar spelet med 300 silver extra.",
                            Amount = 300,
                        },
                        new SkillModification
                        {
                            Label = "Köprmannaskap",
                            Description = "Alla cirefalier tycks ha handeln i blodet, och är därmed lättlärda i färdigheten Handel.",
                            SkillName = "Handel",
                            LearningModifier = LearningModifier.FastLearner,
                        
                        },
                        new CharacterModifierContainer("Välutbildande", "Cirfalierna är kända för att vara välutbildade och om barnen inte sätts i skola lär någon äldre släkting upp dem. De får 4 enheter Kunskapsfärdigheter och blir även Lättlärda i valfri Kunskapsfärdighet.")
                        {
                            new EventRoll
                            {
                                EventCategory = EventCategory.TravelsAndAdventures,
                                Rolls = 1,
                            },
                            new Perk
                            {
                                Description = "Alla närstridsvapen i adasierns händer räknas som Sargande."
                            }
                        }
                    },
                    //Laguages = new List<Language>
                    //{
                    //    new Language
                    //    {
                    //        Name = "Faliska",
                    //        Written = false,
                    //    },
                    //    new Language
                    //    {
                    //        Name = "Lägre Jargiska",
                    //        Written = false,
                    //    },
                    //    new Language
                    //    {
                    //        Name = "Falisk skrift",
                    //        Written = true,
                    //    }
                    //}
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
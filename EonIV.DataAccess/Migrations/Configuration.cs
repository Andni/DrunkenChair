using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EonIVCharacterGenerationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            //if (Debugger.IsAttached == false)
            //{
            //    Debugger.Launch();
            //}
        }

        protected override void Seed(EonIVCharacterGenerationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            
            SeedBackgrounds(context);
            SeedArchetypes(context);
            SeedRaces(context);
            SeedEnvironments(context);
            EventSeeder.SeedEvents(context);            
        }
        
        private void SeedBackgrounds(EonIVCharacterGenerationDbContext context)
        {
            //seed background modifiers
     //       var root = CharacterModifierNodes.GetBackgroundCharacterModifier();
            //var list = root.Cast<CharacterModifierNode>();
              //  .ToList();

    //        SeedModifierNodes(context, root, new NodeTagGenerator("B"));
            
            foreach (var b in Backgrounds.GetBackgrounds())
            {
//                b.Modifications = null;
                context.Backgrounds.AddOrUpdate(x => x.Name, b);
  //              b.ModificationContainerId = root[b.Number - 1].ID;
            }
        }

        private void SeedArchetypes(EonIVCharacterGenerationDbContext context)
        {
            context.Archetypes.AddOrUpdate(
                  a => a.Name,
                  new Archetype { Name = "Krigare", EventRolls = new EventTableRolls(1, 0, 0, 2, 0) },
                  new Archetype { Name = "Mystiker", EventRolls = new EventTableRolls(0, 0, 2, 0, 1) }
                );

        }

        private void SeedRaces(EonIVCharacterGenerationDbContext context)
        {
            context.Races.AddOrUpdate(
                r => r.Name,

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
            );
        }

        private void SeedEnvironments(EonIVCharacterGenerationDbContext context)
        {
            context.Environments.AddOrUpdate(
                e => e.Name,
                new Environment(
                    "Hav",
                    new EventTableRolls()
                    {
                        BattlesAndSkirmishes = 1,
                        TravlesAndAdventures = 1,
                        FreeChoise = 1
                    },
                    new Skillpoints()
                    {
                        Battle = 2,
                        Knowledge = 1,
                        Movement = 4,
                        Wilderness = 5
                    }),
                new Environment(
                    "Stad",
                    new EventTableRolls()
                    {
                        IntrigueAndIlldeads = 1,
                        KnowledgeAndMysteries = 1,
                        FreeChoise = 1
                    },
                    new Skillpoints()
                    {
                        Knowledge = 2,
                        Movement = 3,
                        Social = 5,
                        Battle = 2
                    })
                );
        }

    }
}

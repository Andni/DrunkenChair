namespace Niklasson.DrunkenChair.Migrations
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    using Niklasson.DrunkenChair.Model;
    using Niklasson.DrunkenChair.DatabaseTables;
    using Niklasson.DrunkenChair.Character;
    using Niklasson.DrunkenChair.DatabaseTables.Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<DrunkenChair.Model.EonIvCharacterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DrunkenChair.Model.EonIvCharacterDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            SeedArchetypes(context);
            SeedRaces(context);
            SeedEnvironments(context);
            EventSeeder.SeedEvents(context);
            //SeedConstants(context);
        }

        private void SeedArchetypes(DrunkenChair.Model.EonIvCharacterDbContext context)
        {
            context.Archetypes.AddOrUpdate(
                  a => a.Name,
                  new Archetype { Name = "Krigare", EventRolls = new EventTableRolls(1, 0, 0, 2, 0) },
                  new Archetype { Name = "Mystiker", EventRolls = new EventTableRolls(0, 0, 2, 0, 1) }
                );
            
        }

        private void SeedRaces(DrunkenChair.Model.EonIvCharacterDbContext context)
        {
            context.Races.AddOrUpdate(
                r => r.Name,

                new Race
                {
                    Name = "Adasier",
                    StartingAttributes = new CharacterBaseAttributeSet
                    {
                        Strength = new Model.DiceRollCheck(1, 2),
                        Stamina = new Model.DiceRollCheck(2, 3),
                        Agility = new Model.DiceRollCheck(3, 0),
                        Perception = new Model.DiceRollCheck(2, 2),
                        Will = new Model.DiceRollCheck(2, 1),
                        Psyche = new Model.DiceRollCheck(1, 3),
                        Wisdom = new Model.DiceRollCheck(1, 0),
                        Charisma = new Model.DiceRollCheck(1, 3)
                    },
                    Perks = "Flexible"
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
                    Perks = "A plan within a plan"
                }
            );
        }

        private void SeedEnvironments(DrunkenChair.Model.EonIvCharacterDbContext context)
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

        

        //private void SeedConstants(DrunkenChair.Model.EonIvCharacterDbContext context)
        //{
        //    context.CreationConstants.AddOrUpdate(
        //        c => c.Constant,
        //        new CharacterCreationConstants(Constant.BonusAttributeDiceses, 10),
        //        new CharacterCreationConstants(Constant.MaxBonusAttributeDicesSpentOnOneAttribute, 5)
        //        );
        //}

    }
}

namespace DrunkenChair.Migrations
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using DrunkenChair.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DrunkenChair.Models.EonIvCharacterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DrunkenChair.Models.EonIvCharacterDbContext context)
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
            SeedConstants(context);
        }

        private void SeedArchetypes(DrunkenChair.Models.EonIvCharacterDbContext context)
        {
            context.Archetypes.AddOrUpdate(
                  a => a.Name,
                  new Archetype { Name = "Krigare", LifeEventRolls = new TableRolls(1, 0, 0, 2, 0) },
                  new Archetype { Name = "Mystiker", LifeEventRolls = new TableRolls(0, 0, 2, 0, 1) }
                );
            
        }

        private void SeedRaces(DrunkenChair.Models.EonIvCharacterDbContext context)
        {
            context.Races.AddOrUpdate(
                r => r.Name,
                new Race { Name = "Adasier",
                    StartingAttributes = new Attributes {
                        Strength = new Models.Attribute(1, 2),
                        Stamina = new Models.Attribute(2, 3),
                        Agility = new Models.Attribute(3, 0),
                        Perception = new Models.Attribute(2, 2),
                        Will = new Models.Attribute(2, 1),
                        Psyche = new Models.Attribute(1, 3),
                        Wisdom = new Models.Attribute(1, 0),
                        Charisma = new Models.Attribute(1, 3)
                    },
                    Perks = "Flexible"}
                );
        }

        private void SeedEnvironments(DrunkenChair.Models.EonIvCharacterDbContext context)
        {
            context.Environments.AddOrUpdate(
                e => e.Name,
                new Environment("Hav", new TableRolls(), new Skillpoints()),
                new Environment("Stad", new TableRolls(), new Skillpoints())
                );
        }

        private void SeedConstants(DrunkenChair.Models.EonIvCharacterDbContext context)
        {
            context.CreationConstants.AddOrUpdate(
                c => c.Constant,
                new CharacterCreationConstants(Constant.BonusAttributeDiceses, 10),
                new CharacterCreationConstants(Constant.MaxBonusAttributeDicesSpentOnOneAttribute, 5)
                );
        }
    }
}

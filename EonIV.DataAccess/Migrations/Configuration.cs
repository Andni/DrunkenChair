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
            foreach (var b in Backgrounds.GetBackgrounds())
            {
                context.Backgrounds.AddOrUpdate(x => x.Name, b);
            }
        }

        private void SeedArchetypes(EonIVCharacterGenerationDbContext context)
        {
            foreach (var a in Archetype.GetArchetypes())
            {
                context.Archetypes.AddOrUpdate(x => x.Name, a);
            }
        }

        private void SeedRaces(EonIVCharacterGenerationDbContext context)
        {
            foreach (var race in Race.GetRaces())
            {
                context.Races.AddOrUpdate(x => x.Name, race);
            }
        }

        private void SeedEnvironments(EonIVCharacterGenerationDbContext context)
        {
            foreach (var env in Environment.GetEnvironments())
            {
                context.Environments.AddOrUpdate(x => x.Name, env);
            }
        }

    }
}

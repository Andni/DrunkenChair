using System.Data.Entity;
using Niklasson.DrunkenChair.DatabaseTables;

namespace Niklasson.DrunkenChair.Repository
{
    public class EonIVCharacterGenerationDbContext : DbContext
    {

        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Background> Backgrounds { get; set; }

    }
}
﻿using System.Data.Entity;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.Repository
{
    public class EonIVCharacterGenerationDbContext : DbContext
    {

        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Background> Backgrounds { get; set; }

        //public DbSet<Event2> Event2 { get; set; }

    }
}
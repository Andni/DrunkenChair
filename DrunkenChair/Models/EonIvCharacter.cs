using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrunkenChair.Models
{
    public class EonIvCharacter
    {
        public int ID { get; set; }
        public CharacterBasicDetails Basics { get; set; }
        public Attributes Attributes { get; set; }

        public EonIvCharacter()
        {
            Basics = new CharacterBasicDetails();
            Attributes = new Attributes();
        }
    }

    public class EonIvCharacterDbContext : DbContext
    {
        public DbSet<EonIvCharacter> EonIvCharacters { get; set; }
        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Environment> Environments { get; set; }

        public DbSet<CharacterCreationConstants> CreationConstants { get; set; }
    }
}
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
        public DerivedCharacterAttributes Attributes { get; set; }
        public CharacterSkills Skills { get; set; }
        //public SortedSet<Skill> Skills2 { get; set; }

        public EonIvCharacter()
        {
            Basics = new CharacterBasicDetails();
            Attributes = new DerivedCharacterAttributes();
        }

        public EonIvCharacter Modify(CharacterBaseAttributes a)
        {
            this.Attributes.Base += a;
            return this;
        }

        public EonIvCharacter Modify(DerivedCharacterAttributes a)
        {
            this.Attributes += a;
            return this;
        }

        public EonIvCharacter Modify(Skill s)
        {
            this.Skills.Add(s);
            return this;
        }
    }

    public class EonIvCharacterDbContext : DbContext
    {
        public DbSet<EonIvCharacter> EonIvCharacters { get; set; }
        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<DatabaseTables.Event> Events { get; set; } 

        public DbSet<CharacterCreationConstants> CreationConstants { get; set; }
    }
}
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
        public CharacterAttributeSet Attributes { get; set; }
        [Column("CharacterSkills")]
        public CharacterSkills Skills { get; set; }
        
        public EonIvCharacter()
        {
            Basics = new CharacterBasicDetails();
            Attributes = new CharacterAttributeSet();
        }

        public EonIvCharacter Modify(CharacterBaseAttributeSet a)
        {
            this.Attributes.Base += a;
            return this;
        }

        public EonIvCharacter Modify(CharacterAttributeSet a)
        {
            this.Attributes += a;
            return this;
        }

        public EonIvCharacter Modify(CharacterSkill s)
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
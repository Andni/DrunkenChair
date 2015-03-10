using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DrunkenChair.Models
{
    public class Archetype
    {

        public Archetype()
        {
            LifeEventRolls = new EventTableRolls();
        }

        //public int ID { get; set; }
        [Key]
        public string Name { get; set; }
        [Display(Name = "Events")]
        public EventTableRolls LifeEventRolls { get; set; }
    }

    public class ArchetypeDbContext : DbContext
    {
        public DbSet<Archetype> Archetypes { get; set; }
    }
}


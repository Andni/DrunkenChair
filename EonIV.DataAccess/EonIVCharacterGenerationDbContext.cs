﻿using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.DataAccess
{
    public class EonIVCharacterGenerationDbContext : DbContext
    {
        public DbSet<CharacterModifierNode> CharacterModifierNodes{ get; set; }
        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<RuleBookEvent> Events { get; set; }
        public DbSet<Background> Backgrounds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Background>().HasOptional(b => b.Modifications);

            //modelBuilder.Entity<CharacterModifierNode>()
            //    .HasOptional(n => n.Parent);

            modelBuilder.Entity<RuleBookEvent>().HasOptional(e => e.CharacterModifiers);
        }


        /// <summary>
        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        /// </summary>
        /// <param name="context">The context.</param>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
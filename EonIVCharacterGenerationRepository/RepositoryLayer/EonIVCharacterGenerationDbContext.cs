using System.Data.Entity;
using System.Text;
using System.Data.Entity.Validation;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.Repository
{
    public class EonIVCharacterGenerationDbContext : DbContext
    {
        public DbSet<Archetype> Archetypes { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<RuleBookEvent> Events { get; set; }
        public DbSet<Background> Backgrounds { get; set; }



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
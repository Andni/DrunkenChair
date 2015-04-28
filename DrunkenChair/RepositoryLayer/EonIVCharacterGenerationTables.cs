using System.Collections.Generic;
using System.Linq;

using Random = System.Random;

using Niklasson.DrunkenChair.DatabaseTables;
using Niklasson.DrunkenChair.Model;

namespace Niklasson.DrunkenChair.Repository
{
    public class EonIVCharacterGenerationTables : IEonIVCharacterGenerationTables
    {
        private EonIvCharacterDbContext gererationDbContext;

        public EonIVCharacterGenerationTables(EonIvCharacterDbContext context)
        {
            gererationDbContext = context;
        }

        public IEnumerable<Archetype> Archetypes
        {
            get
            {
                return gererationDbContext.Archetypes;
            }
        }

        public IEnumerable<Race> Races
        {
            get
            {
                return gererationDbContext.Races;
            }
        }

        public IEnumerable<Background> Backgrounds
        {
            get
            {
                return gererationDbContext.Backgrounds;
            }
        }

        public IEnumerable<Environment> Environments
        {
            get
            {
                return gererationDbContext.Environments;
            }
        }

        public IEnumerable<Event> GetRandomEvents(EventCategory cat, int nb)
        {
            Event[] arr = gererationDbContext.Events.Where(e => e.Category == cat).ToArray();

            var count = arr.Count();
            int numerOfEventsToGet = nb > count ? count : nb;
            var rand = new Random();
            List<Event> events = new List<Event>();

            int i = 0;
            while (i < numerOfEventsToGet)
            {
                yield return arr[rand.Next(0, count - 1)];
                i++;
            }
        }

    }
}
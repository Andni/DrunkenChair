using System.Collections.Generic;
using System.Linq;

using Random = System.Random;

using Niklasson.DrunkenChair.DatabaseTables;
using Niklasson.DrunkenChair.Models;

namespace Niklasson.DrunkenChair.Repository
{
    public class EonIVCharacterGenerationTables : IEonIVCharacterGenerationTables
    {
        private EonIVCharacterGenerationDbContext gererationDbContext;

        public EonIVCharacterGenerationTables(EonIVCharacterGenerationDbContext context)
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

        public IEnumerable<Event> Events
        {
            get { return gererationDbContext.Event; }
        }

        public Event GetRandomEvent(EventCategory cat)
        {
            var categoryEvents = gererationDbContext.Event.Where(e => e.Category == cat);
            return categoryEvents.GetRandom();
        }

        public IEnumerable<Event> GetRandomEvents(EventCategory cat, int nb)
        {
            var events = gererationDbContext.Event.Where(e => e.Category == cat);
            
            var count = events.Count();
            if(count == 0)
            {
                yield break;
            }
            List<Event> eventList = events.ToList();
            
            int numerOfEventsToGet = nb > count ? count : nb;
            var rand = new Random();

            int i = 0;
            while (i < numerOfEventsToGet)
            {
                yield return eventList[rand.Next(0, count - 1)];
                i++;
            }
        }

    }
}
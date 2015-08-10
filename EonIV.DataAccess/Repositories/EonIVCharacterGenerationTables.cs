using System.Collections.Generic;
using System.Linq;

using Random = System.Random;
using Niklasson.EonIV.DataAccess;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Models;

namespace Niklasson.EonIV.DataAccess.Repositories
{
    public class EonIVCharacterGenerationTables : IEonIVCharacterGenerationTables
    {
        private readonly EonIVCharacterGenerationDbContext gererationDbContext;

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

        public IEnumerable<IRuleBookEvent> Events
        {
            get { return gererationDbContext.Events; }
        }

        public IRuleBookEvent GetRandomEvent(EventCategory cat)
        {
            var categoryEvents = gererationDbContext.Events.Where(e => e.Category == cat);
            return categoryEvents.GetRandom();
        }

        public IEnumerable<IRuleBookEvent> GetRandomEvents(EventCategory cat, int nb)
        {
            var events = gererationDbContext.Events.Where(e => e.Category == cat);
            
            var count = events.Count();
            if(count == 0)
            {
                yield break;
            }
            List<RuleBookEvent> eventList = events.ToList();
            
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
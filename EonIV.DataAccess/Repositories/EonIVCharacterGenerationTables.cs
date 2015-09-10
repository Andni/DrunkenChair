using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using Niklasson.EonIV.Models;
using Niklasson.EonIV.Models.BusinessObjects;
using Environment = Niklasson.EonIV.Models.BusinessObjects.Environment;

namespace Niklasson.EonIV.DataAccess.Repositories
{
    public class EonIVCharacterGenerationTables : IEonIVCharacterGenerationTables
    {
        private readonly EonIVCharacterGenerationDbContext generationDbContext;

        public EonIVCharacterGenerationTables(EonIVCharacterGenerationDbContext context)
        {
            generationDbContext = context;
        }

        public IEnumerable<Archetype> Archetypes
        {
            get
            {
                return generationDbContext.Archetypes;
            }
        }

        public IEnumerable<Race> Races
        {
            get
            {
                return generationDbContext.Races;
            }
        }

        public IEnumerable<Background> Backgrounds
        {
            get
            {
                return generationDbContext.Backgrounds;
            }
        }

        public IEnumerable<Environment> Environments
        {
            get
            {
                return generationDbContext.Environments;
            }
        }

        public IEnumerable<IRuleBookEvent> Events
        {
            get { return generationDbContext.Events; }
        }

        public IRuleBookEvent GetRandomEvent(EventCategory cat)
        {
            var categoryEvents = generationDbContext.Events.Where(e => e.Category == cat);
            return categoryEvents.GetRandom();
        }

        public ICollection<Background> GetRandomBackgrounds(int count)
        {
            var r = new Random();
            var backgroundCount = generationDbContext.Backgrounds.Count();

            var res = generationDbContext.Backgrounds.OrderBy(b => SqlFunctions.Rand()).Take(count).ToList();
            return res;
        } 

        public IEnumerable<IRuleBookEvent> GetRandomEvents(EventCategory cat, int nb)
        {
            var events = generationDbContext.Events.Where(e => e.Category == cat);
            
            var numberOfEventsInCategory = events.Count();
            if(numberOfEventsInCategory == 0)
            {
                yield break;
            }
            List<RuleBookEvent> eventList = events.ToList();
            
            int numerOfEventsToGet = nb > numberOfEventsInCategory ? numberOfEventsInCategory : nb;
            var rand = new Random();

            int i = 0;
            while (i < numerOfEventsToGet)
            {
                yield return eventList[rand.Next(0, numberOfEventsInCategory - 1)];
                i++;
            }
        }

    }
}
using System.Collections.Generic;
using System.Linq;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.Toolbox;

namespace Niklasson.EonIV.DataAccess
{
    public static class EventExtensions
    {
        public static IEnumerable<RuleBookEvent> IntrigueAndMisdeads(this IEnumerable<RuleBookEvent> events)
        {
            return events.Where(e => e.Category == EventCategory.INTRIGUE_AND_MISDEADS);
        }
        
        public static IEnumerable<RuleBookEvent> BattlesAndSkirmishes(this IEnumerable<RuleBookEvent> events)
        {
            return events.Where(e => e.Category == EventCategory.BATTLES_AND_SKIRMISHES);
        }

        public static IEnumerable<RuleBookEvent> TravelsAndAdventures(this IEnumerable<RuleBookEvent> events)
        {
            return events.Where(e => e.Category == EventCategory.TRAVELS_AND_ADVENTURES);
        }

        public static IEnumerable<RuleBookEvent> KnowledgeAndMysteries(this IEnumerable<RuleBookEvent> events)
        {
            return events.Where(e => e.Category == EventCategory.KNOWLEDGE_AND_MYSTERIES);
        }

        public static RuleBookEvent GetRandom(this IEnumerable<RuleBookEvent> events)
        {
            var noEvents = events.Count();
            if (noEvents == 0)
            { 
                return new RuleBookEvent();
            }
            else if (noEvents == 1)
            {
                return events.First();
            }
            else
            {
                var maxVal = noEvents - 1;
                return events.ToArray()[RandomNumberGenerator.Next(0, maxVal)];
            }
        }
    }
}
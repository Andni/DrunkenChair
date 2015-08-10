using System.Collections.Generic;
using System.Linq;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.Models
{
    public static class EventExtensions
    {
        public static IEnumerable<T> IntrigueAndMisdeads<T>(this IEnumerable<T> events) where T : IBaseEvent
        {
            return events.Where(e => e.Category == EventCategory.INTRIGUE_AND_MISDEADS);
        }

        public static IEnumerable<T> BattlesAndSkirmishes<T>(this IEnumerable<T> events) where T : IBaseEvent
        {
            return events.Where(e => e.Category == EventCategory.BATTLES_AND_SKIRMISHES);
        }

        public static IEnumerable<T> TravelsAndAdventures<T>(this IEnumerable<T> events) where T : IBaseEvent
        {
            return events.Where(e => e.Category == EventCategory.TRAVELS_AND_ADVENTURES);
        }

        public static IEnumerable<T> KnowledgeAndMysteries<T>(this IEnumerable<T> events) where T : IBaseEvent
        {
            return events.Where(e => e.Category == EventCategory.KNOWLEDGE_AND_MYSTERIES);
        }

        public static IEnumerable<T> FilterByCategory<T>(this IEnumerable<T> events, EventCategory cat) where T : IBaseEvent
        {
            return events.Where(e => e.Category == cat);
        }

        public static T GetRandom<T>(this IEnumerable<T> events) where T : IBaseEvent, new()
        {
            var noEvents = events.Count();
            if (noEvents == 0)
            { 
                return new T();
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
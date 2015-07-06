using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.EonIV.CharacterGeneration.Contracts;
using Niklasson.Toolbox;

namespace Niklasson.EonIV.CharacterGeneration.Repository
{
    public static class EventExtensions
    {
        public static IEnumerable<Event> IntrigueAndMisdeads(this IEnumerable<Event> events)
        {
            return events.Where(e => e.Category == EventCategory.INTRIGUE_AND_MISDEADS);
        }
        
        public static IEnumerable<Event> BattlesAndSkirmishes(this IEnumerable<Event> events)
        {
            return events.Where(e => e.Category == EventCategory.BATTLES_AND_SKIRMISHES);
        }

        public static IEnumerable<Event> TravelsAndAdventures(this IEnumerable<Event> events)
        {
            return events.Where(e => e.Category == EventCategory.TRAVELS_AND_ADVENTURES);
        }

        public static IEnumerable<Event> KnowledgeAndMysteries(this IEnumerable<Event> events)
        {
            return events.Where(e => e.Category == EventCategory.KNOWLEDGE_AND_MYSTERIES);
        }

        public static Event GetRandom(this IEnumerable<Event> events)
        {
            var noEvents = events.Count();
            if (noEvents == 0)
            { 
                return new Event();
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
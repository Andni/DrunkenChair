using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Models;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.Toolbox;


namespace Niklasson.DrunkenChair.Extensions
{
    public static class EventViewModelCollectionExtension
    {
        public static IEnumerable<EventViewModel> IntrigueAndMisdeads(this IEnumerable<EventViewModel> events)
        {
            return events.Where(e => e.Category == EventCategory.INTRIGUE_AND_MISDEADS);
        }

        public static IEnumerable<EventViewModel> BattlesAndSkirmishes(this IEnumerable<EventViewModel> events)
        {
            return events.Where(e => e.Category == EventCategory.BATTLES_AND_SKIRMISHES);
        }

        public static IEnumerable<EventViewModel> TravelsAndAdventures(this IEnumerable<EventViewModel> events)
        {
            return events.Where(e => e.Category == EventCategory.TRAVELS_AND_ADVENTURES);
        }

        public static IEnumerable<EventViewModel> KnowledgeAndMysteries(this IEnumerable<EventViewModel> events)
        {
            return events.Where(e => e.Category == EventCategory.KNOWLEDGE_AND_MYSTERIES);
        }

        public static void ReplaceEvent(this IList<EventViewModel> events, EventCategory cat, int index, EventViewModel newEvent)
        {
            throw new InvalidOperationException("Does not make any sense to index by index as well as category, ");
        }

        public static IEnumerable<EventViewModel> GetCategory(this IEnumerable<EventViewModel> events, EventCategory cat)
        {
            return events.Where(e => e.Category == cat);
        }

        public static IList<EventViewModel> GetCategory(this List<EventViewModel> events, EventCategory cat)
        {
            return events.Where(e => e.Category == cat).ToList();
        }

        public static EventViewModel GetRandom(this IEnumerable<EventViewModel> events)
        {
            var noEvents = events.Count();
            if (noEvents == 0)
            {
                return new EventViewModel();
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
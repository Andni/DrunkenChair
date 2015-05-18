using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.DatabaseTables;
using Niklasson.DrunkenChair.Character;
using Niklasson.DrunkenChair.Repository;

namespace Niklasson.DrunkenChair.Models
{
    public class RolledEvents
    {
        private List<Event> events = new List<Event>();

        public IEnumerable<Event> Travels
        {
            get
            { return this[EventCategory.TRAVELS_AND_ADVENTURES]; }

            set
            {
                Replace(EventCategory.TRAVELS_AND_ADVENTURES, value);
            }
        }

        public IEnumerable<Event> Intrigue {
            get
            { return this[EventCategory.INTRIGUE_AND_MISDEADS]; }
            set
            {
                Replace(EventCategory.INTRIGUE_AND_MISDEADS, value);
            }
        }

        public IEnumerable<Event> Knowledge
        {
            get 
            { return this[EventCategory.KNOWLEDGE_AND_MYSTERIES]; }
            set
            {
                Replace(EventCategory.KNOWLEDGE_AND_MYSTERIES, value);
            }
        }
        public IEnumerable<Event> Battles
        {
            get
            { return this[EventCategory.BATTLES_AND_SKIRMISHES]; }
            set
            {
                Replace(EventCategory.BATTLES_AND_SKIRMISHES, value);
            }
        }

        private IEnumerable<Event> GetRandomEvents(EonIVCharacterGenerationDbContext db, EventCategory cat, int nb)
        {
            Event[] arr = db.Events.Where(e => e.Category == cat).ToArray();
                
            var count = db.Events.Count(e => e.Category == cat);
            int numerOfEventsToGet = nb > count ? count : nb;
            var rand = new Random();
            List<Event> events = new List<Event>();
            
            int i = 0;
            while(i < numerOfEventsToGet)
            {
                yield return arr[rand.Next(0, count - 1)];
                i++;
            }
        }

        public IEnumerable<Event> this[EventCategory key]
        {
            get{
                return events.Where(e => e.Category == key);
            }
            set
            {
                Replace(key, value);
            }
        }

        private void Replace(EventCategory cat, IEnumerable<Event> newEvents)
        {
            events.RemoveAll(e => e.Category == cat);
            events.AddRange(newEvents.Where(e => e.Category == cat));
        }

    }
}
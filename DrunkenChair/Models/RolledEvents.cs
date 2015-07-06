using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.Models
{
    public class RolledEvents
    {
        private List<Event> events = new List<Event>();

        public RolledEvents() {}

        public RolledEvents(IEnumerable<Event> events1)
        {
            events = events1.ToList();
        }

        public List<Event> Travels
        {
            get
            { return this[EventCategory.TRAVELS_AND_ADVENTURES].ToList(); }

            set
            {
                Replace(EventCategory.TRAVELS_AND_ADVENTURES, value);
            }
        }

        public List<Event> Intrigue {
            get
            { return this[EventCategory.INTRIGUE_AND_MISDEADS].ToList(); }
            set
            {
                Replace(EventCategory.INTRIGUE_AND_MISDEADS, value);
            }
        }

        public List<Event> Knowledge
        {
            get
            { return this[EventCategory.KNOWLEDGE_AND_MYSTERIES].ToList(); }
            set
            {
                Replace(EventCategory.KNOWLEDGE_AND_MYSTERIES, value);
            }
        }
        public List<Event> Battles
        {
            get
            { return this[EventCategory.BATTLES_AND_SKIRMISHES].ToList(); }
            set
            {
                Replace(EventCategory.BATTLES_AND_SKIRMISHES, value);
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

        public void ReplaceEvent(EventCategory cat, int index, Event evnt)
        {
            var ev = events.Where(e => e.Category == cat).ElementAt(index);
            ev = evnt;
        }

        private void Replace(EventCategory cat, IEnumerable<Event> newEvents)
        {
            events.RemoveAll(e => e.Category == cat);
            events.AddRange(newEvents.Where(e => e.Category == cat));
        }


        public IEnumerable<CharacterEvent> ToCharacterEvents()
        {
            var res = new List<CharacterEvent>();
            foreach(Event e in events)
            {
                res.Add(e.ToCharacterEvent());
            }
            return new List<CharacterEvent>();
        }

        public void Add(Event ev)
        {
            events.Add(ev);
        }
    }
}
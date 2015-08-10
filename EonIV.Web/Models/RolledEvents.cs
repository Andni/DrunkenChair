using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.DrunkenChair.Models
{
    public class RolledEvents
    {
        private List<EventViewModel> events = new List<EventViewModel>();

        public RolledEvents() {}

        public RolledEvents(IEnumerable<IRuleBookEvent> events1)
        {
            foreach( IRuleBookEvent e in events1)
            {
                events.Add(new EventViewModel(e));
            }
        }

        public List<EventViewModel> Travels
        {
            get
            { return this[EventCategory.TRAVELS_AND_ADVENTURES].ToList(); }

            set
            {
                Replace(EventCategory.TRAVELS_AND_ADVENTURES, value);
            }
        }

        public List<EventViewModel> Intrigue {
            get
            { return this[EventCategory.INTRIGUE_AND_MISDEADS].ToList(); }
            set
            {
                Replace(EventCategory.INTRIGUE_AND_MISDEADS, value);
            }
        }

        public List<EventViewModel> Knowledge
        {
            get
            { return this[EventCategory.KNOWLEDGE_AND_MYSTERIES].ToList(); }
            set
            {
                Replace(EventCategory.KNOWLEDGE_AND_MYSTERIES, value);
            }
        }
        public List<EventViewModel> Battles
        {
            get
            { return this[EventCategory.BATTLES_AND_SKIRMISHES].ToList(); }
            set
            {
                Replace(EventCategory.BATTLES_AND_SKIRMISHES, value);
            }
        }

        public IEnumerable<EventViewModel> this[EventCategory key]
        {
            get{
                return events.Where(e => e.Category == key);
            }
            set
            {
                Replace(key, value);
            }
        }

        public void ReplaceEvent(EventCategory cat, int index, EventViewModel evnt)
        {
            var ev = events.Where(e => e.Category == cat).ElementAt(index);
            ev = evnt;
        }

        private void Replace(EventCategory cat, IEnumerable<EventViewModel> newEvents)
        {
            events.RemoveAll(e => e.Category == cat);
            events.AddRange(newEvents.Where(e => e.Category == cat));
        }

        public void Add(EventViewModel ev)
        {
            events.Add(ev);
        }
    }
}
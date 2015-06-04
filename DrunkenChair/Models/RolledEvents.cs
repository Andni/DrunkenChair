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

        private IEnumerable<Event> GetRandomEvents(EonIVCharacterGenerationDbContext db, EventCategory cat, int nb)
        {
            Event[] arr = db.Event.Where(e => e.Category == cat).ToArray();
                
            var count = db.Event.Count(e => e.Category == cat);
            int numerOfEventsToGet = nb > count ? count : nb;
            var rand = new Random();
            
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
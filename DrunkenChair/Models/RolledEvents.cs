using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.DatabaseTables;
using Niklasson.DrunkenChair.Character;

namespace Niklasson.DrunkenChair.Model
{
    public class RolledEvents
    {
        public List<Event> Travels { get; set; }
        public List<Event> Intrigue { get; set; }
        public List<Event> Knowledge { get; set; }
        public List<Event> Battles { get; set; }

        private IEnumerable<Event> GetRandomEvents(EonIvCharacterDbContext db, EventCategory cat, int nb)
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
    }
}
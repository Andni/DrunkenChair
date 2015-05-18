using System.Collections.Generic;

namespace Niklasson.DrunkenChair.Models
{
    public class EventDetails
    {
        public int FreeEventRolls { get; set; }
        public RolledEvents RolledEvents { get; set; }
        public List<string> SelectedEventModifications { get; set; }

        public EventDetails()
        {
            RolledEvents = new RolledEvents();
            SelectedEventModifications = new List<string>();
        }
    }
}
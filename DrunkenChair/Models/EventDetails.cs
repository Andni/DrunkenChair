using System.Collections.Generic;

using Niklasson.DrunkenChair.Character;

namespace Niklasson.DrunkenChair.Models
{
    public class EventDetails
    {
        public int FreeEventRolls { get; set; }
        public RolledEvents RolledEvents { get; set; }

        public EventDetails()
        {
            RolledEvents = new RolledEvents();
        }
    }
}
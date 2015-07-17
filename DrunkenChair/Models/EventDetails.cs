using System.Collections.Generic;

using Niklasson.DrunkenChair.Character;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.Models
{
    public class EventDetails
    {
        public int FreeEventRolls { get; set; }
        public EventViewModelSet RolledEvents { get; set; }

        public EventDetails()
        {
            RolledEvents = new EventViewModelSet();
        }
    }
}
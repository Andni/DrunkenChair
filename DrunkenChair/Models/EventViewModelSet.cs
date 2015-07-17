using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.Models
{
    public class EventViewModelSet : BaseEventSet<EventViewModel>
    {
        public EventViewModelSet() : base() { }
        public EventViewModelSet(IEnumerable<EventViewModel> events) : base(events) { }
        public EventViewModelSet(IEnumerable<IRuleBookEvent> events) : base()
        {
            foreach(IRuleBookEvent e in events)
            {
                this.Add(new EventViewModel(e));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niklasson.EonIV.CharacterGeneration.BusinessObjects
{
    public class EventDetails
    {
        private RuleBookEventSet events = new RuleBookEventSet();

        public RuleBookEventSet Events
        {
            get
            {
                return events;
            }
        }
    }
}

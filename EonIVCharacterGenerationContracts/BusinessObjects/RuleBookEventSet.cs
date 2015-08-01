using System.Collections.Generic;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class RuleBookEventSet : BaseEventSet<IRuleBookEvent>
    {
        public RuleBookEventSet() : base() { }
        public RuleBookEventSet(IEnumerable<IRuleBookEvent> events) : base(events) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.BusinessObjects
{
    public class RuleBookEventSet : BaseEventSet<IRuleBookEvent>, ICharacterEventChoises
    {
        public RuleBookEventSet() : base() { }
        public RuleBookEventSet(IEnumerable<IRuleBookEvent> events) : base(events) { }
    }
}

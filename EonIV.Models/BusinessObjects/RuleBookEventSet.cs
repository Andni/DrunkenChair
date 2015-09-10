using System.Collections.Generic;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class RuleBookEventSet : BaseEventSet<IRuleBookEvent>
    {
        public RuleBookEventSet() : base() { }
        public RuleBookEventSet(IEnumerable<IRuleBookEvent> events) : base(events) { }

        private List<CharacterModifierNode> modifiers = new List<CharacterModifierNode>();

        public override bool Add(IRuleBookEvent e)
        {
            var added = base.Add(e);
            if(added)
            {
                modifiers.AddRange(e.CharacterModifiers.Children);
            }
            return added;
        }

        public ICollection<CharacterModifierNode> GetModifiers()
        {
            return modifiers;
        }
    }
}

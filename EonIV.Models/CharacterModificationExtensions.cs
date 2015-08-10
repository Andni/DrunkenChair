using System.Collections.Generic;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.Models
{
    public static class CharacterModificationExtensions
    {
        public static List<CharacterEvent> CollapseChoices(this IEnumerable<IRuleBookEvent> ruleBookEvents)
        {
            var res = new List<CharacterEvent>();
            foreach(IRuleBookEvent e in ruleBookEvents)
            {
                res.Add(e.ToCharacterEvent());
            }
            return res;
        }
    }
}

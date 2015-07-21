using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.Extensions
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

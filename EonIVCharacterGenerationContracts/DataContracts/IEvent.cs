using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public interface IRuleBookEvent : IBaseEvent
    {
        List<CharacterModificationOptions> ModificationOptions { get; set; }
        CharacterEvent ToCharacterEvent();
    }
}

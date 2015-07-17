using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public interface ICharacterEvent : IBaseEvent
    {
        List<CharacterModifier> SelectedModifications { get; }
    }
}

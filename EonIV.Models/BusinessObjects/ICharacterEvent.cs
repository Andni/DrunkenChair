using System.Collections.Generic;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public interface ICharacterEvent : IBaseEvent
    {
        List<CharacterModifier> SelectedModifications { get; }
    }
}

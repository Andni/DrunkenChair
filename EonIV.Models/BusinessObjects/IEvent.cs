using System.Collections.Generic;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public interface IRuleBookEvent : IBaseEvent
    {
        CharacterModifierContainerSingleChoice CharacterModifiers { get; set; }
        CharacterEvent ToCharacterEvent();
    }
}

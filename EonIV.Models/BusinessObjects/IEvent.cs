using System.Collections.Generic;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public interface IRuleBookEvent : IBaseEvent
    {
        CharacterModifierContainer CharacterModifiers { get; set; }
        CharacterEvent ToCharacterEvent();
    }
}

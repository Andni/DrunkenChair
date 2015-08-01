using System.Collections.Generic;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public interface IRuleBookEvent : IBaseEvent
    {
        List<CharacterModificationOptions> ModificationOptions { get; set; }
        CharacterEvent ToCharacterEvent();
    }
}

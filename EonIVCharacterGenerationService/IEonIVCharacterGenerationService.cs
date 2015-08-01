using System.Collections.Generic;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.Services
{
    public interface IEonIVCharacterGenerationService
    {

        IEnumerable<Archetype> Archetypes { get; }
        IEnumerable<Background> Backgrounds { get; }
        IEnumerable<Environment> Environments { get; }
        IEnumerable<Race> Races { get; }
        
        IEnumerable<IRuleBookEvent> RollEvents(EventTableRolls eventRolls);

        IRuleBookEvent GetRandomEvent(EventCategory cat);

        CharacterBasics ResolveBasicChoices(ICharacterBasicChoices basics);

    }
}

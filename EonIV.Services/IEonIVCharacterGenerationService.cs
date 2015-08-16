using System;
using System.Collections.Generic;
using Niklasson.EonIV.Models.BusinessObjects;
using Environment = Niklasson.EonIV.Models.BusinessObjects.Environment;

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

        //Type GetObjecType(string typeString);

    }
}

﻿using System.Collections.Generic;
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
        ICollection<Background> GetRandomBackgrounds(int count);
        CharacterBasics ResolveBasicChoices(ICharacterBasicChoices basics);

        Archetype GetArchetype(string archetypeName);
        Background GetBackground(string backgroundName);
        Environment GetEnvironment(string environmentName);
        Race GetRace(string raceName);

    }
}

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Niklasson.EonIV.CharacterGeneration.Contracts;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public interface IEonIVCharacterGenerationService
    {

        IEnumerable<Archetype> Archetypes { get; }
        IEnumerable<Background> Backgrounds { get; }
        IEnumerable<Environment> Environments { get; }
        IEnumerable<Race> Races { get; }
        
        IEnumerable<Event> RollEvents(EventTableRolls eventRolls);

        Event GetRandomEvent(EventCategory cat);

        CharacterBasics ResolveBasicChoices(ICharacterBasicChoices basics);

    }
}

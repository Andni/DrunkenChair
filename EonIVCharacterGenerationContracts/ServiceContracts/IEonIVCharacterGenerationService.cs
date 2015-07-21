using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Niklasson.EonIV.CharacterGeneration.Contracts;
using Niklasson.EonIV.CharacterGeneration.BusinessObjects;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
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

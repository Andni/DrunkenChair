using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public interface IEonIVCharacterGenerationTables
    {
        IEnumerable<IRuleBookEvent> GetRandomEvents(EventCategory cat, int number);

        IEnumerable<Archetype> Archetypes { get; }
        IEnumerable<Background> Backgrounds { get; }
        IEnumerable<Environment> Environments { get; }
        IEnumerable<Race> Races { get; }

        IRuleBookEvent GetRandomEvent(EventCategory cat);
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Niklasson.DrunkenChair.DatabaseTables;

namespace Niklasson.DrunkenChair.Repository
{
    public interface IEonIVCharacterGenerationTables
    {
        IEnumerable<Event> GetRandomEvents(EventCategory cat, int number);

        IEnumerable<Archetype> Archetypes { get; }
        IEnumerable<Background> Backgrounds { get; }
        IEnumerable<Environment> Environments { get; }
        IEnumerable<Race> Races { get; }

        Event GetRandomEvent(EventCategory cat);
    }
}

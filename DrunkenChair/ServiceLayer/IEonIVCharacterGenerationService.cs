using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.Composition;

using Niklasson.DrunkenChair.DatabaseTables;
using Niklasson.DrunkenChair.Models;

namespace Niklasson.DrunkenChair.ServiceLayer
{
    [InheritedExport]
    public interface IEonIVCharacterGenerationService
    {
        RolledEvents RollEvents(EventTableRolls eventRolls);

        IEnumerable<Archetype> Archetypes { get; }
        IEnumerable<Background> Backgrounds { get; }
        IEnumerable<Environment> Environments { get; }
        IEnumerable<Race> Races { get; }
        
        //IEnumerable<Event> GetRandomEvents(EventCategory cat, int number);

        Event GetRandomEvent(EventCategory cat);
    }
}

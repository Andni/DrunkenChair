using System.Collections.Generic;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.DataAccess.Repositories
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

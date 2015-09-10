using System.Collections.Generic;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.DataAccess.Repositories
{
    public interface IEonIVCharacterGenerationTables
    {

        IEnumerable<Archetype> Archetypes { get; }
        IEnumerable<Background> Backgrounds { get; }
        IEnumerable<Environment> Environments { get; }
        IEnumerable<Race> Races { get; }

        IEnumerable<IRuleBookEvent> GetRandomEvents(EventCategory cat, int number);
        ICollection<Background> GetRandomBackgrounds(int count);
        IRuleBookEvent GetRandomEvent(EventCategory cat);
    }
}

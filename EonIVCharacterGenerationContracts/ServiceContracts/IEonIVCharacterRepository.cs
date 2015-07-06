using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public interface IEonIVCharacterRepository
    {
        Task<IEnumerable<EonIVCharacterSheet>> GetLatestCharacters(int numberOfCharactersToGet);
        Task<EonIVCharacterSheet> FindAsync(int? id);
        Task SaveChangesAsync();
        void Add(EonIVCharacterSheet character);
        void Remove(EonIVCharacterSheet character);
        void Dispose();
        void SetModified(EonIVCharacterSheet character);
    }
}

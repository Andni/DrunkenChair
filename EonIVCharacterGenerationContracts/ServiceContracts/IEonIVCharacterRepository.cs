using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public interface IEonIVCharacterRepository
    {
        Task<IEnumerable<CharacterSheet>> GetLatestCharacters(int numberOfCharactersToGet);
        Task<CharacterSheet> FindAsync(int? id);
        Task SaveChangesAsync();
        void Add(CharacterSheet character);
        void Remove(CharacterSheet character);
        void Dispose();
        void SetModified(CharacterSheet character);
    }
}

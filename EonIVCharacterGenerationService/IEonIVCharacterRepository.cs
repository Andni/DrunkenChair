using System.Collections.Generic;
using System.Threading.Tasks;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.Services
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

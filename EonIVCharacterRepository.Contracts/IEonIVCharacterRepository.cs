using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niklasson.EonIV.CharacterRepository.Contracts
{
    public interface IEonIVCharacterRepository
    {
        Task<IEnumerable<EonIVCharacterSheet>> GetLatestCharacters(int numberOfCharactersToGet);
        Task<EonIVCharacterSheet> FindAsync(int? id);
    }
}

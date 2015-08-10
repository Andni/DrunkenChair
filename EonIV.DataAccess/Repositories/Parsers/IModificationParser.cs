using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.DataAccess.Repositories.Parsers
{
    interface IModificationParser
    {
        CharacterModifier TryParse(string text);
    }
}

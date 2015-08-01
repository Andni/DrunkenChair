using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.DataAccess.Migrations
{
    interface IModificationParser
    {
        CharacterModifier TryParse(string text);
    }
}

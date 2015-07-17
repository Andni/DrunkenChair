using System;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.DatabaseTables.Helpers
{
    interface IModificationParser
    {
        CharacterModifier TryParse(string text);
    }
}

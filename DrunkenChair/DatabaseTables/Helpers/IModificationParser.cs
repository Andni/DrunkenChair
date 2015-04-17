using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DrunkenChair.DatabaseTables;
namespace DrunkenChair.DatabaseTables.Helpers
{
    interface IModificationParser
    {
        EonIVCharacterModifier TryParse(string text);
    }
}

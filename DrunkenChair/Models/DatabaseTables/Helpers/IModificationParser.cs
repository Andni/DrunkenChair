using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkenChair.Models.DatabaseTables.Helpers
{
    interface IModificationParser
    {
        EonIVCharacterModifier TryParse(string text);
    }
}

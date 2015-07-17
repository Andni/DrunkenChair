using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.Repository.Parsers
{
    interface IModificationParser
    {
        CharacterModifier TryParse(string text);
    }
}

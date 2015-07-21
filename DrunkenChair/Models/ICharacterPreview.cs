using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Niklasson.EonIV.CharacterGeneration.BusinessObjects;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.Models
{
    public interface ICharacterPreview
    {
        CharacterSheet CharacterSheet { get; }
        CharacterGenerationData Scaffolding { get; }        
    }
}

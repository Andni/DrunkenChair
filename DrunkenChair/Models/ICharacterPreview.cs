using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.DrunkenChair.Models
{
    public interface ICharacterPreview
    {
        CharacterSheet CharacterSheet { get; }
        CharacterGenerationData Scaffolding { get; }        
    }
}

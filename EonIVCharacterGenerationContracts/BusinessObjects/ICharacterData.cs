using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.BusinessObjects
{
    public interface ICharacterData
    {
        CharacterBasics Basics { get; set; }
        BaseAttributeDices ExtraAttributeDiceDistribution { get; set; }
        RuleBookEventSet Events { get; set; }
    }
}

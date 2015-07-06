using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public interface ICharacterBasicChoices
    {
        string SelectedArchetype { get; set; }
        string SelectedBackground { get; set; }
        string SelectedEnvironment { get; set; }
        string SelectedRace { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Niklasson.EonIV.CharacterGeneration.BusinessObjects;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public class CharacterBasicChoices : ICharacterBasicChoices
    {
        public string SelectedArchetype { get; set; }
        public string SelectedBackground { get; set; }
        public string SelectedEnvironment { get; set; }
        public string SelectedRace { get; set; }
    }
}

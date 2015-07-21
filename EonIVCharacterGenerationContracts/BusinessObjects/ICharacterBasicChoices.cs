using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niklasson.EonIV.CharacterGeneration.BusinessObjects
{
    public interface ICharacterBasicChoices
    {
        string SelectedArchetype { get; set; }
        string SelectedBackground { get; set; }
        string SelectedEnvironment { get; set; }
        string SelectedRace { get; set; }
    }
}

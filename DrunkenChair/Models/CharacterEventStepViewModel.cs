using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.EonIV.CharacterGeneration.BusinessObjects;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.Models
{
    public class CharacterEventStepViewModel : CharacterEventDetails
    {
        public int FreeEventRolls { get; set; }
        public CharacterPreview CharacterPreview { get; set; }

        public CharacterEventStepViewModel() { }

        public CharacterEventStepViewModel(CharacterConstructionSite ccs)
        {
            CharacterPreview = new CharacterPreview(ccs);

            events = ccs.GetCharacterEvents();
            FreeEventRolls = ccs.GetCharacterEventRolls().FreeChoise;
        }
   
    }
}
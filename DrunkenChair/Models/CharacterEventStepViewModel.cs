using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.EonIV.CharacterGeneration.BusinessObjects;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.Models
{
    public class CharacterEventStepViewModel : EventDetails
    {
        public int FreeEventRolls { get; set; }
        public CharacterPreview CharacterPreview { get; set; }
    }
}
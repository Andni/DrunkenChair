using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public class EventSkillpoints : EonIVCharacterModifier
    {
        public int Value { get; set; }
        public SkillCategory ApplicableCategory { get; set; }
    }
}
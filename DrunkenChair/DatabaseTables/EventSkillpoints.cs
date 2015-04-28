using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Character;

namespace Niklasson.DrunkenChair.DatabaseTables
{
    public class EventSkillpoints : EonIVCharacterModifier
    {
        public int Value { get; set; }
        public SkillCategory ApplicableCategory { get; set; }
    }
}
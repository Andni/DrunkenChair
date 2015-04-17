using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DrunkenChair.Character;

namespace DrunkenChair.DatabaseTables
{
    public class EventSkillpoints : EonIVCharacterModifier
    {
        public int Value { get; set; }
        public SkillCategory ApplicableCategory { get; set; }
    }
}
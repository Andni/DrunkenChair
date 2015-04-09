using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrunkenChair.Models.DatabaseTables
{
    public class EventSkillpoints : EonIVCharacterModifier
    {
        public SkillCategory ApplicableCategory { get; set; }
    }
}
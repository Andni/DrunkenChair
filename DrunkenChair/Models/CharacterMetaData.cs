using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Character;
using Niklasson.DrunkenChair.DatabaseTables;

namespace Niklasson.DrunkenChair.Models
{
    public class CharacterMetaData
    {
        public CharacterBaseAttributeSet BonusDiceDistribution { get; set; }
        public EventTableRolls EventRolls { get; set; }
        public EventDetails EventDetails { get; set; }
        public Skillpoints Skillpoints { get; set; } 

        public CharacterMetaData()
        {
            EventRolls = new EventTableRolls();
            Skillpoints = new Skillpoints();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DrunkenChair.Character;
using DrunkenChair.DatabaseTables;

namespace DrunkenChair.Models
{
    public class EonIVCharacterScaffolding
    {
        public EventTableRolls EventRolls { get; set; }
        public Skillpoints Skillpoints { get; set; } 
    }
}
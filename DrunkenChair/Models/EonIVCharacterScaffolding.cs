using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Character;
using Niklasson.DrunkenChair.DatabaseTables;

namespace Niklasson.DrunkenChair.Model
{
    public class EonIVCharacterScaffolding
    {
        public EventTableRolls EventRolls { get; set; }
        public Skillpoints Skillpoints { get; set; } 
    }
}
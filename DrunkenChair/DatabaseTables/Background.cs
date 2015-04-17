using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using DrunkenChair.Character;

namespace DrunkenChair.DatabaseTables
{
    public class Background
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public EventTableRolls EventRolls { get; set; }
        public List<EonIVCharacterModifier> Modifications { get; private set; }

        public static implicit operator string(Background b)
        {
            return b.ToString();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
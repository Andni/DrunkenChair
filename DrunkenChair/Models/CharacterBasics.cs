using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrunkenChair.Models
{
    public class CharacterBasics
    {
        public Attributes Attributes{ get; set; }
        public EventTableRolls EventRolls { get; set; }
        public Skillpoints Skillpoints { get; set; }

        public CharacterBasics()
        {
            Attributes = new Attributes();
            EventRolls = new EventTableRolls();
            Skillpoints = new Skillpoints();
        }

    }
}
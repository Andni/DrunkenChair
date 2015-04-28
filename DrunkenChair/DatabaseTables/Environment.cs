using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using Niklasson.DrunkenChair.Character;
using Niklasson.DrunkenChair.Model;

namespace Niklasson.DrunkenChair.DatabaseTables
{
    public class Environment
    {
        [Key]
        public string Name { get; set; }
        public Skillpoints Skills { get; set; }
        public EventTableRolls EventRolls { get; set; }

        public Environment()
        {
            EventRolls = new EventTableRolls();
            Skills = new Skillpoints();
        }

        public Environment(string name, EventTableRolls eventRolls, Skillpoints skills)
        {
            Name = name;
            EventRolls = eventRolls;
            Skills = skills;
        }

        public static implicit operator string(Environment e)
        {
            return e.ToString();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
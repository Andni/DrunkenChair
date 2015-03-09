using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DrunkenChair.Models
{
    public class Environment
    {
        [Key]
        public string Name { get; set; }
        public Skillpoints Skills { get; set; }
        public TableRolls Events { get; set; }

        public Environment() : this("Default", new TableRolls(), new Skillpoints()) { }

        public Environment(string name, TableRolls eventRolls, Skillpoints skills)
        {
            Name = name;
            Events = eventRolls;
            Skills = skills;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Niklasson.EonIV.CharacterGeneration.Contracts;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public class Archetype
    {
        public Archetype()
        {
            EventRolls = new EventTableRolls();
        }

        [Key]
        public string Name { get; set; }
        [Display(Name = "Events")]
        public EventTableRolls EventRolls { get; set; }

        public static implicit operator string(Archetype a)
        {
            return a.ToString();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}


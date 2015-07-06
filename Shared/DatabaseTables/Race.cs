﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using Niklasson.DrunkenChair.Shared.Character;
using Niklasson.DrunkenChair.Shared.DataTypes;

namespace Niklasson.DrunkenChair.Shared.DatabaseTables
{
    public class Race
    {
        [Key]
        public string Name { get; set; }
        public CharacterBaseAttributeSet StartingAttributes {get; set;}
        public EventTableRolls EventRolls { get; set; }
        public string Perks { get; set; }

        public Race()
        {
            EventRolls = new EventTableRolls();
            StartingAttributes = new CharacterBaseAttributeSet();
        }
        
        public static implicit operator string(Race r)
        {
            return r.ToString();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
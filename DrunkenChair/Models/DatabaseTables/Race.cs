using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DrunkenChair.Models
{
    public class Race
    {
        [Key]
        public string Name { get; set; }
        public CharacterBaseAttributeSet StartingAttributes {get; set;}
        public string Perks { get; set; }
    }
}
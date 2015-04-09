using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DrunkenChair.Models.DatabaseTables
{
    public class Perk : EonIVCharacterModifier
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
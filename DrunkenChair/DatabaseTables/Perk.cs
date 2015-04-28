using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Niklasson.DrunkenChair.DatabaseTables
{
    public class Perk : EonIVCharacterModifier
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
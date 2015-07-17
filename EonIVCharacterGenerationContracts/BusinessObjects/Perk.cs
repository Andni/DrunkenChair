using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public class Perk : CharacterModifier
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
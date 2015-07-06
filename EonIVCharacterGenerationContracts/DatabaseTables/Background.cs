using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using Niklasson.EonIV.CharacterGeneration.Contracts;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public class Background
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public EventTableRolls EventRolls { get; set; }
        public List<EonIVCharacterModifier> Modifications { get; private set; }

        public Background()
        {
            EventRolls = new EventTableRolls();
            Modifications = new List<EonIVCharacterModifier>();
        }

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
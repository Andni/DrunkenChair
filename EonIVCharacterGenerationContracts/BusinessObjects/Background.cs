using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class Background
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public EventTableRolls EventRolls { get; set; }
        public List<CharacterModifier> Modifications { get; private set; }

        public Background()
        {
            EventRolls = new EventTableRolls();
            Modifications = new List<CharacterModifier>();
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
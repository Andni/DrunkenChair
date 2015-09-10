using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class ItemSkillBonus : ItemProperty
    {
        public string SkillName { get; set; }
        public DiceRollCheck Bonus { get; set; }

    }
}

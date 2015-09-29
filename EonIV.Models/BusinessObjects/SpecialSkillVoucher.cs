using System;
using System.ComponentModel.DataAnnotations.Schema;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class SpecialSkillVoucher : CharacterModifier
    {
        public override string ConcreteModelType
        {
            get
            {
                return typeof(SpecialSkillVoucher).ToString();
            }
        }

        [Column("SpecialSkillVoucherValue")]
        public DiceRollCheck Value { get; set; }

        [Column("SpecialSkillVoucherCategory")]
        public SpecialSkillCategory Category { get; set; }

    }
}
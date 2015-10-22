using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class SkillModification : CharacterModifier
    {
        [Required]
        public string SkillName { get; set; }
        [Column("SkillValue")]
        public DiceRollCheck Value { get; set; } = new DiceRollCheck(0);
        public LearningModifier LearningModifier { get; set; }

        public override string ConcreteModelType
        {
            get { return typeof (SkillModification).ToString(); }
        }

    }
}
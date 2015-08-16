using System.ComponentModel.DataAnnotations;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class SkillModification : CharacterModifier
    {
        [Required]
        public string Name { get; set; }
        public DiceRollCheck Value { get; set; }
        public LearningModifier LearningModifier { get; set; }

        public override string ConcreteModelType
        {
            get { return typeof (SkillModification).ToString(); }
        }

    }
}
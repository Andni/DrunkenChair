using System.ComponentModel.DataAnnotations;
using Shared.DataTypes;

namespace Shared.DatabaseTables
{
    public class SkillModification : EonIVCharacterModifier
    {
        [Required]
        public string Name { get; set; }
        public DiceRollCheck Value { get; set; }
        public LearningModifier LearningModifier { get; set; }
    }
}
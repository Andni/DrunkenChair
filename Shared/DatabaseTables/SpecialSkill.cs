using Shared.DataTypes;

namespace Shared.DatabaseTables
{
    public enum SpecialSkillCategory
    {
        EXPERTISE,
        CRAFT,
        CHARACTERISTIC,
        UNCATEGORIZED = 0
    }

    public abstract class SpecialSkill : SkillModification
    {
        public SpecialSkill()
        {
            LearningModifier = LearningModifier.FAST_LEARNER;
            Value = EonIVValue.DiceToValue(4);
        }
    }
}
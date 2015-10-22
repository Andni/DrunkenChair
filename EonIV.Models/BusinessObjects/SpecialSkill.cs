using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public enum SpecialSkillCategory
    {
        Expertise,
        Craft,
        Characteristic,
        UNCATEGORIZED = 0
    }

    public abstract class SpecialSkill : SkillModification
    {
        public SpecialSkill()
        {
            LearningModifier = LearningModifier.FastLearner;
            Value = new DiceRollCheck(4, 0);
        }
    }
}
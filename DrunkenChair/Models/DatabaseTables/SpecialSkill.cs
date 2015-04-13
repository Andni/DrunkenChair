using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrunkenChair.Models.DatabaseTables
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
            LearningModifier = Models.LearningModifier.FAST_LEARNER;
            Value = EonIVValue.DiceToValue(4);
        }
    }
}
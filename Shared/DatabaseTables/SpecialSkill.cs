using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Shared.DataTypes;

namespace Niklasson.DrunkenChair.Shared.DatabaseTables
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
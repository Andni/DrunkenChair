using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Model;

namespace Niklasson.DrunkenChair.DatabaseTables
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
            LearningModifier = Model.LearningModifier.FAST_LEARNER;
            Value = EonIVValue.DiceToValue(4);
        }
    }
}
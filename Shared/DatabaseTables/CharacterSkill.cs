using System;
using System.ComponentModel.DataAnnotations;
using Shared.DataTypes;

namespace Shared.DatabaseTables
{

    public enum LearningModifier
    {
        SLOW_LEARNER = -1,
        NONE = 0,
        FAST_LEARNER = 1
    }

    public class CharacterSkill : IComparable
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int EonIvCharacterID { get; set; }
        [Required]
        public string Name { get; set; }
        public DiceRollCheck Value { get; set; }
        public LearningModifier LearningModifier { get; set; }
        public SkillCategory Category { get; set; }
        public BaseAttribute GuidingAttribute { get; set; }

        public CharacterSkill()
        {
            Name = "";
            Value = 0;
            LearningModifier = LearningModifier.NONE;
            Category = SkillCategory.UNCATEGORIZED;
        }

        public CharacterSkill(SkillCategory cat) : this()
        {
            Category = cat;
        }

        public int CompareTo(object o)
        {
            int result = 0;
            var skill = o as CharacterSkill;
            if(skill != null)
            {
                result = this.Name.CompareTo(skill.Name);
            }
            return result;
        }

    }
}
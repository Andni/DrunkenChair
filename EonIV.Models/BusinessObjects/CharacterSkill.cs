using System;
using System.ComponentModel.DataAnnotations;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{

    public enum LearningModifier
    {
        SlowLearner = -1,
        None = 0,
        FastLearner = 1
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
            Value =  new DiceRollCheck(0);
            LearningModifier = LearningModifier.None;
            Category = SkillCategory.Uncategorized;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using DrunkenChair.Models.Interfaces;

namespace DrunkenChair.Models
{

    public enum LearningModifier
    {
        SLOW_LEARNER = -1,
        NONE = 0,
        FAST_LEARNER = 1
    }

    public enum SkillCategory
    {
        BATTLE,
        SOCIAL,
        WILDERNESS,
        MOVEMENT,
        MYSTIC,
        KNOWLEDGE,
        LANGUAGE,
        MISC,
        UNCATEGORIZED
    }

    public class Skill : EonIVCharacterModifier, IComparable
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int EonIvCharacterID { get; set; }
        [Required]
        public string Name { get; set; }
        public Attribute Value { get; set; }
        public LearningModifier LearningModifier { get; set; }
        public SkillCategory Category { get; set; }
        public BaseAttributes GuidingAttribute { get; set; }

        public Skill()
        {
            Name = "";
            Value = 0;
            LearningModifier = Models.LearningModifier.NONE;
            Category = SkillCategory.UNCATEGORIZED;
        }

        public Skill(SkillCategory cat) : this()
        {
            Category = cat;
        }

        public int CompareTo(object o)
        {
            int result = 0;
            var skill = o as Skill;
            if(skill != null)
            {
                result = this.Name.CompareTo(skill.Name);
            }
            return result;
        }

    }
}
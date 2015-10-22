
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    //TODO to be replaced by a CharacterModifierContainer containing CategorySkillPoints
    [ComplexType]
    public class Skillpoints
    {
        public int Battle { get; set; }
        public int Social { get; set; }
        public int Knowledge { get; set; }
        public int Mystic { get; set; }
        public int Movement { get; set; }
        public int Wilderness { get; set; }
        public int FreeChoise { get; set; }
        
        public int Count()
        {
            return Battle + Social + Knowledge + Mystic +
                Movement + Wilderness + FreeChoise;
        }
        
        public static Skillpoints operator+(Skillpoints lh, Skillpoints rh)
        {
            return new Skillpoints()
            {
                Battle = lh.Battle + rh.Battle,
                Social = lh.Social + rh.Social,
                Knowledge = lh.Knowledge + rh.Knowledge,
                Mystic = lh.Mystic + rh.Mystic,
                Movement = lh.Movement + rh.Movement,
                Wilderness = lh.Wilderness + rh.Wilderness,
                FreeChoise = lh.FreeChoise + rh.FreeChoise
            };
        }
        
        public void Add(CategorySkillPoints skillpoints)
        {
            switch(skillpoints.Category)
            {
                case DataTypes.SkillCategory.Battle:
                    this.Battle += skillpoints.SkillPoints;
                    break;
                case DataTypes.SkillCategory.FreeChoise:
                    this.FreeChoise += skillpoints.SkillPoints;
                    break;
                case DataTypes.SkillCategory.Knowledge:
                    this.Knowledge += skillpoints.SkillPoints;
                    break;
                case DataTypes.SkillCategory.Movement:
                    this.Movement += skillpoints.SkillPoints;
                    break;
                case DataTypes.SkillCategory.Mystic:
                    this.Mystic+= skillpoints.SkillPoints;
                    break;
                case DataTypes.SkillCategory.Social:
                    this.Social += skillpoints.SkillPoints;
                    break;
                case DataTypes.SkillCategory.Wilderness:
                    this.Wilderness += skillpoints.SkillPoints;
                    break;
            }
        }
        
        public static Skillpoints operator +(Skillpoints lh, List<CategorySkillPoints> rh)
        {
            rh.ForEach(e => lh.Add(e));
            return lh;
        }

    }
}

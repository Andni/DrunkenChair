using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class SpecialSkillPoints : CharacterModifier
    {

        public override string Label
        {
            get
            {
                if (string.IsNullOrEmpty(base.Label))
                {
                    return Category.ToString();
                }
                return base.Label;
            }

            set
            {
                base.Label = value;
            }
        }

        public override string Description
        {
            get
            {
                string t = "";
                if(string.IsNullOrEmpty(description))
                {
                    switch(Category)
                    {
                        case SpecialSkillCategory.Expertise:
                            t = "Expertiser";
                            break;
                        case SpecialSkillCategory.Craft:
                            t = "Hantverk";
                            break;
                        case SpecialSkillCategory.Characteristic:
                            t = "Kännetecken";
                            break;
                        default:
                            t = "";
                            break;
                    }
                    return string.Format("{0} poäng {1}", Points, t);
                }
                return description;
            }

            set
            {
                base.Description = value;
            }
        }

        [Column("SpecialSkillCategory")]
        public SpecialSkillCategory Category { get; set; }

        [Column("SpecialSkillPoints")]
        public int Points { get; set; }

        public override string ConcreteModelType
        {
            get
            {
                return typeof(SpecialSkillPoints).ToString();
            }
        }
    }
}

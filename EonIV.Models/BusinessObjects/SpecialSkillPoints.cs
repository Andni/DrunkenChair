using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class SpecialSkillPoints : CharacterModifier
    {

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

using Niklasson.EonIV.Models.DataTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public abstract class SkillPointModification : CharacterModifier
    {
        public int SkillPoints { get; set; }

        public override string ConcreteModelType => typeof (SkillPointModification).ToString();
    }
}

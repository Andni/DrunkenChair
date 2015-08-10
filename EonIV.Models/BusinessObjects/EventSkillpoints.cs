using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class EventSkillpoints : CharacterModifier
    {
        public int Value { get; set; }
        public SkillCategory ApplicableCategory { get; set; }
    }
}
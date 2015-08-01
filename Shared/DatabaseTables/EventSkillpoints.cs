using Shared.DataTypes;

namespace Shared.DatabaseTables
{
    public class EventSkillpoints : EonIVCharacterModifier
    {
        public int Value { get; set; }
        public SkillCategory ApplicableCategory { get; set; }
    }
}
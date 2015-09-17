using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    [Table("Character")]
    public class CharacterSheet
    {
        public int ID { get; set; }
     
        public string Archetype { get; set; }
        public string Background { get; set; }
        public string Environment { get; set; }
        public string Race { get; set; }

        public string Profession { get; set; }
        public int StartingCapitalInSilver { get; set; }

        [Column("Attributes")]
        public CharacterAttributeSet Attributes { get; set; } = new CharacterAttributeSet();
        public CharacterJadedness Jadedness { get; set; } = new CharacterJadedness();
        public CharacterEventSet Events { get; set; } = new CharacterEventSet();
        public CharacterSkillSet Skills { get; set; } = new CharacterSkillSet();
        public List<CharacterLanguageSkill> Languages { get; set; } = new List<CharacterLanguageSkill>();
        public List<CharacterModifier> Notes { get; set; } = new List<CharacterModifier>();
        
        public CharacterSheet(ICharacterData data)
        {
            Archetype = data.Archetype;
            Background = data.Background;
            Environment = data.Environment;
            Race = data.Race;

            Attributes = new CharacterAttributeSet(data.Race.StartingAttributes + data.ExtraAttributeDiceDistribution);

            if(data.Archetype.Resources != null)
            {
                Notes.AddRange(data.Archetype.Resources.Flatten());
            }
            if (data.Background.Modifications != null)
            {
                Notes.AddRange(data.Background.Modifications.Flatten());
            }
            if (data.Environment.GearAndResources != null)
            {
                Notes.AddRange(data.Environment.GearAndResources.Flatten());
            }

            StartingCapitalInSilver = data.Environment.StartingSilver;
        }
    }
}
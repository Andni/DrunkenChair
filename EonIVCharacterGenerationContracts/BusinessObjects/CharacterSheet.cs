using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

using Niklasson.EonIV.CharacterGeneration.Contracts;
using Niklasson.EonIV.CharacterGeneration.BusinessObjects;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
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
        public CharacterAttributeSet Attributes { get; set; }
        public CharacterJadedness Jadedness { get; set;}
        public CharacterEventSet Events { get; set; }
        public CharacterSkillSet Skills { get; set; }
        public List<CharacterResource> Resources { get; set; }
        public List<CharacterLanguageSkill> Languages { get; set; } 
        
        public CharacterSheet()
        {
            Attributes = new CharacterAttributeSet();
            Events = new CharacterEventSet();
            Skills = new CharacterSkillSet();
            Jadedness = new CharacterJadedness();
            Resources = new List<CharacterResource>();
            Languages = new List<CharacterLanguageSkill>();
        }

        public CharacterSheet(ICharacterData data)
        {
            Archetype = data.Basics.Archetype;
            Background = data.Basics.Background;
            Environment = data.Basics.Environment;
            Race = data.Basics.Race;
        }
    }
}
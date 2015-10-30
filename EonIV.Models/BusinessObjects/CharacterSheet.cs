using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Startkapital")]
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
            if (data == null)
            {
                return;
            }

            Race = data.Race?.Name;
            Attributes += data.ExtraAttributeDiceDistribution;
            //race
            if (data.Race != null)
            {
                Attributes += new CharacterAttributeSet(data.Race.StartingAttributes);
            }


            //background notes
            if (data?.Background?.Modifications != null)
            {
                Background = data.Background?.Name;
                Notes.AddRange(data.Background.Modifications.Flatten());
            }

            //environment
            if (data?.Environment != null)
            {
                StartingCapitalInSilver = data.Environment.StartingSilver;
                Environment = data.Environment.Name;
                if(data.Environment?.GearAndResources != null)
                {
                    Notes.AddRange(data.Environment.GearAndResources.Flatten());
                }

            }

            //archetype notes
            var archetype = data?.Archetype;
            if (archetype != null)
            {
                Archetype = data.Archetype?.Name;

                if (archetype.Resources != null)
                {
                    Notes.AddRange(archetype.Resources.Flatten());
                }
                if (archetype.PickTwoResources != null)
                {
                    Notes.AddRange(archetype.PickTwoResources.Flatten());
                }
            }
        }
    }
}
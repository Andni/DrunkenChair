using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

using Niklasson.DrunkenChair.Shared.Character;
using Niklasson.DrunkenChair.Shared.DataTypes;

namespace Niklasson.DrunkenChair.Shared.DatabaseTables
{
    public class EonIvCharacterSheet
    {
        public int ID { get; set; }
     
        public string Archetype { get; set; }
        public string Background { get; set; }
        public string Environment { get; set; }
        public string Race { get; set; }

        public CharacterAttributeSet Attributes { get; set; }
        [Column("CharacterSkills")]
        public CharacterSkills Skills { get; set; }
        
        public EonIvCharacterSheet()
        {
            //Basics = new CharacterBasics();
            Attributes = new CharacterAttributeSet();
        }

        public EonIvCharacterSheet Modify(CharacterBaseAttributeSet a)
        {
            this.Attributes.Base += a;
            return this;
        }

        public EonIvCharacterSheet Modify(CharacterAttributeSet a)
        {
            this.Attributes += a;
            return this;
        }

        public EonIvCharacterSheet Modify(CharacterSkill s)
        {
            this.Skills.Add(s);
            return this;
        }
    }
}
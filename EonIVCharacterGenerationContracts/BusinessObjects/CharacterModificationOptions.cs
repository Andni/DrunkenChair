using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterModificationOptions : BaseCharacterModificationOptions
    {
        [Key]
        public int ID { get; set; }
        public int EventsID { get; set; }

        [NotMapped]
        public int? SelectedAlternativeIndex { get; set; }

        //public static implicit operator CharacterModificationOptions(CharacterModifier mod)
        //{
        //    return new CharacterModificationOptions() { Alternatives = new List<CharacterModifier> { mod } };
        //}

    }

    public class BaseCharacterModificationOptions
    {
        public virtual RuleBookEvent Events { get; set; }
        //public virtual List<CharacterModifier> Alternatives { get; set; }
        
        public BaseCharacterModificationOptions()
        {
            //Alternatives = new List<CharacterModifier>();
        }
    }
}   
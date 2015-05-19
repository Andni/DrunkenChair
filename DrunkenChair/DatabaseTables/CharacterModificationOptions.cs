using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Niklasson.DrunkenChair.Models;

namespace Niklasson.DrunkenChair.DatabaseTables
{
    public class CharacterModificationOptions
    {
        [Key]
        public int ID { get; set; }
        public int EventsID { get; set; }
        public virtual Event Events { get; set; }
        public virtual List<EonIVCharacterModifier> Alternatives { get; set; }
        
        [NotMapped]
        public int SelectedAlternativeIndex { get; set; }


        public CharacterModificationOptions()
        {
            Alternatives = new List<EonIVCharacterModifier>();
        }

        public static implicit operator CharacterModificationOptions(EonIVCharacterModifier mod)
        {
            return new CharacterModificationOptions() { Alternatives = new List<EonIVCharacterModifier> { mod } };
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach(EonIVCharacterModifier m in Alternatives)
            {
                sb.AppendLine(m.ToString());
            }
            return sb.ToString();
        }
    }
}   
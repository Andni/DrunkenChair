using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public class CharacterModificationOptions : BaseCharacterModificationOptions
    {
        [Key]
        public int ID { get; set; }
        public int EventsID { get; set; }

        [NotMapped]
        public int? SelectedAlternativeIndex { get; set; }

        public static implicit operator CharacterModificationOptions(CharacterModifier mod)
        {
            return new CharacterModificationOptions() { Alternatives = new List<CharacterModifier> { mod } };
        }

    }

    public class BaseCharacterModificationOptions
    {
        public virtual RuleBookEvent Events { get; set; }
        public virtual List<CharacterModifier> Alternatives { get; set; }
        
        public BaseCharacterModificationOptions()
        {
            Alternatives = new List<CharacterModifier>();
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach(CharacterModifier m in Alternatives)
            {
                sb.AppendLine(m.ToString());
            }
            return sb.ToString();
        }
    }
}   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public class CharacterModificationOptions : IValidatableObject
    {
        [Key]
        public int ID { get; set; }
        public int EventsID { get; set; }
        public virtual Event Events { get; set; }
        public virtual List<EonIVCharacterModifier> Alternatives { get; set; }
        
        [NotMapped]
        public int? SelectedAlternativeIndex { get; set; }

        public CharacterModificationOptions()
        {
            Alternatives = new List<EonIVCharacterModifier>();
        }

        public EonIVCharacterModifier Collapse()
        {

            if(Alternatives.Count() > 1 && IsValid())
            {
                return Alternatives[SelectedAlternativeIndex.Value];
            }
            else if (Alternatives.Count() == 1)
            {
                return Alternatives.First();
            }
            else
            {
                return null;
            }
        }

        private bool IsValid()
        {
            if (Alternatives.Count() > 1)
            {
                if (SelectedAlternativeIndex.HasValue && SelectedAlternativeIndex.Value < Alternatives.Count())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
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

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if(!IsValid())
            {
                yield return new ValidationResult("One option must be selected.", new [] { "SelectedAlternativeIndex" } );
            }
        }
    }
}   
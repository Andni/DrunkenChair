using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.DrunkenChair.Models
{
    public class CharacterModificationOptionsViewModel : BaseCharacterModificationOptions, IValidatableObject
    {
        public int? SelectedAlternativeIndex { get; set; }

        public static implicit operator CharacterModificationOptionsViewModel( CharacterModificationOptions options)
        {
            return new CharacterModificationOptionsViewModel()
            {    
                Alternatives = options.Alternatives,
                Events = options.Events
            };
        }

        public CharacterModificationOptionsViewModel()
        {
            Alternatives = new List<CharacterModifier>();
        }

        public CharacterModificationOptionsViewModel(BaseCharacterModificationOptions b)
        {
            this.Alternatives = b.Alternatives;
            this.Events = b.Events;
        }

        public CharacterModifier Collapse()
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

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach(CharacterModifier m in Alternatives)
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
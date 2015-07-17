using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.Models
{
    public class EventViewModel : ICharacterEvent
    {

        public int Number { get; set; }
        public EventCategory Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<CharacterModificationOptionsViewModel> ModificationOptions { get; set; }
        public virtual List<CharacterModifier> SelectedModifications
        { get
            {
                return new List<CharacterModifier>(ModificationOptions.Cast<CharacterModifier>());
            }
        }

        public EventViewModel()
        {
            ModificationOptions = new List<CharacterModificationOptionsViewModel>();
        }

        public EventViewModel(IRuleBookEvent e) : this()
        {
            this.Category = e.Category;
            this.Description = e.Description;
            this.Number = e.Number;
            this.Name = e.Name;
            foreach (CharacterModificationOptions o in e.ModificationOptions)
            {
                ModificationOptions.Add(o);
            }
        }

        public EventViewModel(IBaseEvent e)
        {
            // TODO: Complete member initialization
            this.Number = e.Number;
            this.Name = e.Name;
            this.Category= e.Category;
            this.Description = e.Description;
        }

        public static implicit operator EventViewModel(RuleBookEvent evnt)
        {
            return new EventViewModel() { };
        }
    }
}
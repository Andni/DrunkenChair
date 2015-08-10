using System.Collections.Generic;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterEvent : ICharacterEvent
    {
        public EventCategory Category { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }

        public virtual List<CharacterModifier> SelectedModifications { get; set; }
    
    }
}
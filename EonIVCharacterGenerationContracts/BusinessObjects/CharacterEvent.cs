using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
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
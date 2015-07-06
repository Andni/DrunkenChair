using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Shared.DatabaseTables;

namespace Niklasson.DrunkenChair.Shared.Character
{
    public class CharacterEvent
    {
        public EventCategory Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<EonIVCharacterModifier> Modifications { get; set; }
    
    }
}
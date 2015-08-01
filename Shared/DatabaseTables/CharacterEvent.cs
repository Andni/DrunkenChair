using System.Collections.Generic;

namespace Shared.DatabaseTables
{
    public class CharacterEvent
    {
        public EventCategory Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<EonIVCharacterModifier> Modifications { get; set; }
    
    }
}
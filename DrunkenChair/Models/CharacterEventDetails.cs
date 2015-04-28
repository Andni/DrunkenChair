using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.DatabaseTables;

namespace Niklasson.DrunkenChair.Model
{
    public class CharacterEventDetails
    {
        public int FreeEventRolls { get; set; }
        public RolledEvents RolledEvents { get; set; }

        public CharacterConstructionSite CharacterConstructionSite { get; set; }
    }
}
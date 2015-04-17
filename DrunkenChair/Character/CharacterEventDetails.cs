using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DrunkenChair.DatabaseTables;

namespace DrunkenChair.Models
{
    public class CharacterEventDetails
    {
        public List<Event> Events { get; set; }
        public EonIVCharacterConstructionSite CharacterConstructionSite { get; set; }
    }
}
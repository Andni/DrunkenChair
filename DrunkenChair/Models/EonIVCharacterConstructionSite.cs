using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrunkenChair.Models
{
    public class EonIVCharacterConstructionSite
    {
        public EonIvCharacter Character { get; set; }
        public EonIVCharacterScaffolding Scaffolding { get; set; }
    
        public EonIVCharacterConstructionSite()
        {
            Character = new EonIvCharacter();
            Scaffolding = new EonIVCharacterScaffolding();
        }
    }
}
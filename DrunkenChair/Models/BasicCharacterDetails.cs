using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace DrunkenChair.Models
{
    public class BasicCharacterDetails
    {
        public string Background { get; set; }
        public string Race { get; set; }
        public string Archetype { get; set; }
        public string Environment { get; set; }

        public SelectList Races { get; set; }
        public SelectList Archetypes { get; set; }
        public SelectList Environments { get; set; }

        public BasicCharacterDetails() : this(null, null, null) { }

        public BasicCharacterDetails(SelectList archetypes, SelectList environments, SelectList races)
        {
            Archetypes = archetypes;
            Environments = environments;
            Races = races;
        }
    }
}
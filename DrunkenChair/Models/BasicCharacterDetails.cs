using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DrunkenChair.Models
{
    public class BasicCharacterDetails
    {
        [Display(Name="Bakgrund")]
        public string Background { get; set; }

        [Display(Name = "Folkslag")]
        public string Race { get; set; }

        [Display(Name = "Arketyp")]
        public string Archetype { get; set; }

        [Display(Name = "Miljö")]
        public string Environment { get; set; }

        public List<Race> Races { get; set; }
        public SelectList Archetypes { get; set; }
        public SelectList Environments { get; set; }

        public EonIVCharacterConstructionSite CharacterConstructionSite { get; set; }

        public BasicCharacterDetails() : this(null, null, null) { }

        public BasicCharacterDetails(SelectList archetypes, SelectList environments, List<Race> races)
        {
            Archetypes = archetypes;
            Environments = environments;
            Races = races;
        }
    }
}
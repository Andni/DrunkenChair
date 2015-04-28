using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

using Niklasson.DrunkenChair.Character;
using Niklasson.DrunkenChair.DatabaseTables;

namespace Niklasson.DrunkenChair.Model
{
    public class CharacterBasicDetails
    {
        public SelectList Archetypes { get; set; }
        public SelectList Backgrounds { get; set; }
        public SelectList Environments { get; set; }
        public SelectList Races { get; set; }

        public string SelectedArchetype { get; set; }
        public string SelectedBackground { get; set; }
        public string SelectedEnvironment { get; set; }
        public string SelectedRace { get; set; }

        public CharacterConstructionSite CharacterConstructionSite { get; set; }

        public CharacterBasicDetails() : this(null, null, null) { }

        public CharacterBasicDetails(SelectList archetypes, SelectList environments, SelectList races)
        {
            Archetypes = archetypes;
            Environments = environments;
            Races = races;
        }
    }
}
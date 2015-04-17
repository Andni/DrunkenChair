using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

using DrunkenChair.Character;
using DrunkenChair.DatabaseTables;

namespace DrunkenChair.Models
{
    public class CharacterBasicDetails : CharacterBasics
    {
        public SelectList Races { get; set; }
        public SelectList Archetypes { get; set; }
        public SelectList Environments { get; set; }

        public string selectedArchetype { get; set; }
        public string selectedEnvironment { get; set; }
        public string selectedRace { get; set; }

        public EonIVCharacterConstructionSite CharacterConstructionSite { get; set; }

        public CharacterBasicDetails() : this(null, null, null) { }

        public CharacterBasicDetails(SelectList archetypes, SelectList environments, SelectList races)
        {
            Archetypes = archetypes;
            Environments = environments;
            Races = races;
        }
    }
}
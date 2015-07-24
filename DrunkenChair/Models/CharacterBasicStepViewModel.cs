using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Niklasson.EonIV.CharacterGeneration.Contracts;
using Niklasson.EonIV.CharacterGeneration.BusinessObjects;

namespace Niklasson.DrunkenChair.Models
{
    public class CharacterBasicStepViewModel : ICharacterBasicChoices
    {
        public SelectList Archetypes { get; set; }
        public SelectList Backgrounds { get; set; }
        public SelectList Environments { get; set; }
        public SelectList Races { get; set; }

        [Required]
        [Display(Name="Arketyp")]
        public string SelectedArchetype { get; set; }
        [Required]
        [Display(Name = "Bakgrund")]
        public string SelectedBackground { get; set; }
        [Required]
        [Display(Name = "Miljö")]
        public string SelectedEnvironment { get; set; }
        [Required]
        [Display(Name = "Folkslag")]
        public string SelectedRace { get; set; }

        public CharacterPreview CharacterPreview { get; set; }

        public CharacterBasicStepViewModel() {}
        
        public CharacterBasicStepViewModel(CharacterConstructionSite ccs)
        {
            CharacterPreview = new CharacterPreview(ccs);
            SelectedArchetype = ccs.GetArchetype();
            SelectedBackground = ccs.GetBackground();
            SelectedEnvironment = ccs.GetEnvironment();
            SelectedRace = ccs.GetRace();
        }
    }
}
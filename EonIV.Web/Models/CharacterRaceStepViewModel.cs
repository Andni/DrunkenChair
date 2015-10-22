using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Services;

namespace Niklasson.EonIV.Web.Models
{
    public class CharacterRaceStepViewModel
    {
        public SelectList Races { get; set; }

        [Required]
        [Display(Name = "Folkslag")]
        public string SelectedRace { get; set; }

        public Race DefaultRace { get; set; } 

        public CharacterPreview CharacterPreview { get; set; }

        public CharacterRaceStepViewModel() { }

        public CharacterRaceStepViewModel(CharacterConstructionSite ccs)
        {
            CharacterPreview = new CharacterPreview(ccs);
            SelectedRace = ccs.GetRaceName();
        }
    }
}
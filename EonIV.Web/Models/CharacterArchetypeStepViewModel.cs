using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using Niklasson.EonIV.Services;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.Web.Models
{
    public class CharacterArchetypeStepViewModel
    {
        public SelectList Archetypes { get; set; }

        [Required]
        [Display(Name = "Arketyp")]
        public string SelectedArchetype { get; set; }

        public Archetype CurrentSelectedArchetype { get; set; }

        public CharacterPreview CharacterPreview { get; set; }

        public CharacterArchetypeStepViewModel() { }

        public CharacterArchetypeStepViewModel(CharacterConstructionSite ccs)
        {
            CharacterPreview = new CharacterPreview(ccs);
            SelectedArchetype = ccs.GetArchetype();
        }

    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Niklasson.EonIV.Services;
using Niklasson.EonIV.Models.BusinessObjects;
using System.Web.Mvc;

namespace Niklasson.EonIV.Web.Models
{
    public class CharacterEnvironmentStepViewModel
    {
        public SelectList Environments { get; set; }
        [Display(Name = "Miljö")]
        public string SelectedEnvironment{ get; set; }

        public CharacterPreview CharacterPreview { get; set; }

        public CharacterEnvironmentStepViewModel(CharacterConstructionSite ccs)
        {
            CharacterPreview = new CharacterPreview(ccs);
            SelectedEnvironment = ccs.GetEnvironment();
        }

    }
}
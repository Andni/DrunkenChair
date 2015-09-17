using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Niklasson.EonIV.Services;
using Niklasson.EonIV.Models.BusinessObjects;

using System.Web.Mvc;
namespace Niklasson.EonIV.Web.Models
{
    public class CharacterBackgroundStepViewModel : herp
    {
        
        public CharacterPreview CharacterPreview { get; set; }

        public CharacterBackgroundStepViewModel(CharacterConstructionSite ccs)
        {
            CharacterPreview = new CharacterPreview(ccs);
            SelectedBackground = ccs.GetBackground();
        }
    }

    public class herp
    {
        public List<Background> Backgrounds { get; set; } = new List<Background>();

        [Display(Name = "Bakgrund")]
        public string SelectedBackground { get; set; }

        public Background BackgroundInfo { get; set; }
    }
}
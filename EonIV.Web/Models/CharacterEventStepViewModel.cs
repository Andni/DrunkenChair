using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Services;

namespace Niklasson.DrunkenChair.Models
{
    public class CharacterEventStepViewModel : CharacterEventDetails
    {
        public int FreeEventRolls { get; set; }
        public CharacterPreview CharacterPreview { get; set; }

        public CharacterEventStepViewModel() { }

        public CharacterEventStepViewModel(CharacterConstructionSite ccs)
        {
            CharacterPreview = new CharacterPreview(ccs);

            events = ccs.GetCharacterEvents();
            FreeEventRolls = ccs.GetCharacterEventRolls().FreeChoise;
        }
   
    }
}
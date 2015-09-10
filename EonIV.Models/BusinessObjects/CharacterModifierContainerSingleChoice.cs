using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterModifierContainerSingleChoice : CharacterModifierContainer
    {
        [NotMapped]
        public int SelectedAlternativeIndex { get; set; }
    }
}

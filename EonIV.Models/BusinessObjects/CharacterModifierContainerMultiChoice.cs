using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    class CharacterModifierContainerMultiChoice : CharacterModifierContainer
    {
        [NotMapped]
        public int NumberOfChoices { get; set; }

        [NotMapped]
        public List<int> SelectedIndices { get; set; } = new List<int>();

        public CharacterModifierContainerMultiChoice() { }

        public CharacterModifierContainerMultiChoice(int numberOfChoices)
        {
            NumberOfChoices = numberOfChoices;
        }
    }
}

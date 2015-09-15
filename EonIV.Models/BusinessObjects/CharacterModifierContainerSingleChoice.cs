using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterModifierContainerSingleChoice : CharacterModifierContainer
    {
        [NotMapped]
        public int SelectedAlternativeIndex { get; set; }

        public override IList<CharacterModifier> Flatten()
        {
            var res = new List<CharacterModifier>();
            res.AddRange(Children[SelectedAlternativeIndex].Flatten());
            return res;
        }
    }
}

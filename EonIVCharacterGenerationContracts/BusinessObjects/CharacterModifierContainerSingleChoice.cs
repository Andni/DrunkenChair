using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterModifierContainerSingleChoice : CharacterModifierContainer
    {
        public int SelectedAlternativeIndex { get; set; }

        public CharacterModifierContainerSingleChoice() : base()
        {
        }
    }
}

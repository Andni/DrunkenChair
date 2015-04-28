using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Extensions;
using Niklasson.DrunkenChair.Character;

namespace Niklasson.DrunkenChair.Model
{
    public class CharacterAttributeDetails
    {
        public int DicesToDistribute = 10;
        public int MaxDicesPerAttribute = 5;

        public CharacterConstructionSite CharacterConstructionSite { get; set; }

        public int StrenghtBonusDices { get; set; }
        public int StaminaBonusDices { get; set; }
        public int AgilityBonusDices { get; set; }
        public int PerceptionBonusDices { get; set; }
        public int WillBonusDices { get; set; }
        public int PsycheBonusDices { get; set; }
        public int WisdomBonusDices { get; set; }
        public int CharismaBonusDices { get; set; }

        public CharacterAttributeDetails() { }

        public CharacterAttributeDetails(CharacterConstructionSite ccs)
        {
            CharacterConstructionSite = ccs;
        }

        public CharacterBaseAttributeSet GetBonusDiceDistribution()
        {
            return CharacterBaseAttributeSet.CreateFromDiceSet(
                StrenghtBonusDices,
                StaminaBonusDices,
                AgilityBonusDices,
                PerceptionBonusDices,
                WillBonusDices,
                PsycheBonusDices,
                WisdomBonusDices,
                CharismaBonusDices
            );
        }
    }
}
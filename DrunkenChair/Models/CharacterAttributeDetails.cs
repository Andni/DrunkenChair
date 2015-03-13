using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DrunkenChair.Extensions;

namespace DrunkenChair.Models
{
    public class CharacterAttributeDetails
    {
        public int DicesToDistribute = 0;
        public int MaxDicesPerAttribute = 0;

        public Attributes Attributes { get; set; }

        public EonIVCharacterConstructionSite CharacterConstructionSite { get; set; }

        public int StrenghtBonusDices { get; set; }
        public int StaminaBonusDices { get; set; }
        public int AgilityBonusDices { get; set; }
        public int PerceptionBonusDices { get; set; }
        public int WillBonusDices { get; set; }
        public int PsycheBonusDices { get; set; }
        public int WisdomBonusDices { get; set; }
        public int CharismaBonusDices { get; set; }

        public CharacterAttributeDetails(int dicesToDistribute, int maxDicesPerAttribute, Attributes attrs)
        {
            this.DicesToDistribute = dicesToDistribute;
            this.MaxDicesPerAttribute = maxDicesPerAttribute;
            Attributes = attrs;
        }
    }
}
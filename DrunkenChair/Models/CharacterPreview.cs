using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Services;

namespace Niklasson.DrunkenChair.Models
{
    public class CharacterPreview : ICharacterPreview
    {
        private CharacterSheet sheet;
        private CharacterGenerationData scaffolding;

        public CharacterSheet CharacterSheet { get { return sheet; } }
        public CharacterGenerationData Scaffolding { get { return scaffolding; } }

        public CharacterPreview(CharacterConstructionSite ccs)
        {
            sheet = ccs.ToCharacterSheet();
            scaffolding = ccs.GetGenerationData();
        }

    }
}
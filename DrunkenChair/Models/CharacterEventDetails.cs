using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.DrunkenChair.Models
{
    public class CharacterEventDetails : EventDetails
    {
        public CharacterConstructionSite CharacterConstructionSite { get; set; }

        //public CharacterEventDetails()
        //{
        //    CharacterConstructionSite = new CharacterConstructionSite();
        //}
    }
}
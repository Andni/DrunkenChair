using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Extensions;
using Niklasson.DrunkenChair.Character;
using Niklasson.DrunkenChair.ServiceLayer;

using System.ComponentModel.DataAnnotations;


namespace Niklasson.DrunkenChair.Models
{
    public class CharacterAttributeDetails : BaseAttributeDetails
    {
        public CharacterConstructionSite CharacterConstructionSite { get; set; }        
    }
}
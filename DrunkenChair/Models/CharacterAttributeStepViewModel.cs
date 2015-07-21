using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Niklasson.DrunkenChair.Extensions;
using Niklasson.DrunkenChair.Character;

using System.ComponentModel.DataAnnotations;

using Niklasson.EonIV.CharacterGeneration.Contracts;
using Niklasson.EonIV.CharacterGeneration.BusinessObjects;

namespace Niklasson.DrunkenChair.Models
{
    public class CharacterAttributeStepViewModel : BaseAttributeDetails
    {
        public CharacterPreview Preview { get; set; }
    }
}
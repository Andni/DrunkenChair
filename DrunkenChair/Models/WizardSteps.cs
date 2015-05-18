using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niklasson.DrunkenChair.Models
{
    public class WizardSteps
    {
        public CharacterBasicDetails BasicDetails { get; set; }
        public CharacterAttributeDetails AttributeDetails { get; set; }
        public CharacterEventDetails EventDetails { get; set; }

        public WizardSteps()
        {
            BasicDetails = new CharacterBasicDetails();
            AttributeDetails = new CharacterAttributeDetails();
            EventDetails = new CharacterEventDetails();
        }
    }
}
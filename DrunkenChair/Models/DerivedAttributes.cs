using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

namespace DrunkenChair.Models
{
    [ComplexType]
    public class DerivedAttributes
    {
        public Attribute Movement { get; private set; }
        public Attribute Impression { get; private set; }
        public Attribute BodyBuild { get; private set; }
        public Attribute Lifeforce { get; private set; }
        public Attribute Reaction { get; private set; }
        public Attribute Selfcontrol { get; private set; }
        public Attribute Viligance { get; private set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

namespace DrunkenChair.Models
{
    [ComplexType]
    public class CharacterAttributes
    {
        public Attributes Basic { get; set; }
        public DerivedAttributes Derived { get; private set; }
    }
}
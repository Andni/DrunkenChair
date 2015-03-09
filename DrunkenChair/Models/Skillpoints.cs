using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;

namespace DrunkenChair.Models
{
    [ComplexType]
    public class Skillpoints
    {
        public int Swords { get; set; }
    }
}

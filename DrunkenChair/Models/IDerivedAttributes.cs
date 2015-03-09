using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkenChair.Models
{
    public interface IDerivedAttributes
    {
        Attribute Movement { get;}
        Attribute Impression { get; }
        Attribute BodyBuild { get; }
        Attribute Lifeforce { get; }
        Attribute Reaction { get; }
        Attribute Selfcontrol { get; }
        Attribute Viligance { get; }
    }
}

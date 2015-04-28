using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.RegularExpressions;

using Niklasson.DrunkenChair.Character.Helpers;
using Niklasson.DrunkenChair.Character;
using Attribute =Niklasson.DrunkenChair.Character.Attribute;

using Niklasson.Toolbox.Enumerable;

namespace Niklasson.DrunkenChair.DatabaseTables.Helpers
{
    public class AttributeModificationParser : IAttributeModificationParser
    {
        private Regex regex = new Regex(@"(?<value>\d) (?<attribute>[\w]+)");
        private static IEnumerable<Attribute> attributes = EnumUtil.GetValues<Attribute>();
        
        public EonIVCharacterModifier TryParse(string text)
        {
            var textWithoutLinebreaks = text.Replace(System.Environment.NewLine, "");
            var lc = textWithoutLinebreaks.ToLower();
            var match = regex.Match(lc);
            
            if(match.Success)
            {
                return CreateAttribute(match.Groups["attribute"].Value, match.Groups["value"].Value);
            }

            return null;
        }

        private AttributeModification CreateAttribute(string attribute, string value)
        {
            int parsedValue;
            var attr = AttributeHelper.ParseAttribute(attribute);
            if( Int32.TryParse(value, out parsedValue) &&
                attr != Attribute.UNDEFINED)
            {

                return new AttributeModification()
                {
                    Value = parsedValue,
                    Attribute = attr
                };
                
            }
            else
            {
                return null;
            }
        }
    }
}
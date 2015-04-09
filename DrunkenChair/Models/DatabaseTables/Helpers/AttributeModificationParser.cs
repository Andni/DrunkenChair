using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.RegularExpressions;
using DrunkenChair.Character;
using Attribute = DrunkenChair.Character.Attribute;

using Niklasson.Toolbox.Enumerable;

namespace DrunkenChair.Models.DatabaseTables.Helpers
{
    public class AttributeModificationParser : IAttributeModificationParser
    {
        private Regex regex = new Regex(@"+(?<value>\d) (?<attribute>[\w]+)");
        private static IEnumerable<Attribute> attributes = EnumUtil.GetValues<Attribute>();
        
        public AttributeModification TryParse(string text)
        {
            var lc = text.ToLower();
            var match = regex.Match(lc);
            
            if(match.Success)
            {
                return CreateAttribute(match.Groups["attribute"].Value, match.Groups["value"].Value);
            }

            return null;
        }

        private AttributeModification CreateAttribute(string value, string attribute)
        {
            int parsedValue;
            Attribute matchedAttribute;
            if (MatchAttribute(value, out matchedAttribute)
                && Int32.TryParse(attribute, out parsedValue))
            {
                return new AttributeModification()
                {
                    Value = parsedValue,
                    Attribute = matchedAttribute
                };
            }
            else
            {
                return null;
            }
        }

        private bool MatchAttribute(string attribute, out Attribute matchedAttribute)
        {

            foreach(Attribute a in attributes)
            {
                if(a.ToString().ToLower().Equals(attribute))
                {
                    matchedAttribute = a;
                    return true;
                }
            }
            matchedAttribute = 0;
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Models.BusinessObjects.Helpers;
using Niklasson.Toolbox;
using Attribute =Niklasson.EonIV.Models.DataTypes.Attribute;

namespace Niklasson.EonIV.DataAccess.Migrations
{
    public class AttributeModificationParser : IAttributeModificationParser
    {
        private Regex regex = new Regex(@"(?<value>\d) (?<attribute>[\w]+)");
        private static IEnumerable<Attribute> attributes = EnumUtil.GetValues<Attribute>();
        
        public CharacterModifier TryParse(string text)
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
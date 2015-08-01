using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niklasson.DrunkenChair.DatabaseTables.Helpers
{
    public class ModificationListParser 
    {

        static List<IModificationParser> parsers = new List<IModificationParser>() {
            new AttributeModificationParser(),
            new SkillPointModificationParser(),
            new SkillModificationParser()
        };
        
        public static string NormalizeText(string text)
        {
            var textWithoutLinebreaks = text.Replace(System.Environment.NewLine, " ");
            return textWithoutLinebreaks.ToLower().Trim();
        }

        public ICollection<CharacterModificationOptions> TryParse(string text)
        {
            return ParseModifiers(NormalizeText(text));
        }

        private List<CharacterModificationOptions> ParseModifiers(string text)
        {
            var res = new List<CharacterModificationOptions>();
            var strArr = text.Split(new char[] { ',', '.' });

            CharacterModificationOptions lastModifierParsed = null;

            foreach (string s in strArr)
            {
                var modifier = ParseModifier(s);
                if (modifier.Alternatives.Count > 0)
                {
                    res.Add(modifier);
                    lastModifierParsed = modifier;
                }
                else
                {
                    if(lastModifierParsed != null)
                    {
                        lastModifierParsed.Alternatives.Last().Condition = s;
                    }
                }
            }
            return res;
        }


        private CharacterModificationOptions ParseModifier(string text)
        {
            var lowerCase = text.ToLower();
            var res = new CharacterModificationOptions();

            foreach (IModificationParser p in parsers)
            {
                var m = p.TryParse(text);
                if (m != null)
                {
                    res.Alternatives.Add(m);
                    return res;
                }
            }
            return res;
        }
    }
}
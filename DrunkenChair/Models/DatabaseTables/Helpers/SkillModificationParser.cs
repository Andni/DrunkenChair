using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.RegularExpressions;

using DrunkenChair.Character.Helpers;
using DrunkenChair.Character;
using DrunkenChair.Models.DatabaseTables;

namespace DrunkenChair.Models.DatabaseTables.Helpers
{
    public class SkillModificationParser : ISkillModificationParser
    {
        private const string category = "category";
        private const string value = "value";
        private Regex regex = new Regex(@"(?<" + value + @">\d) enheter (?<" + category + @">[\w]+) färdigheter");

        public EonIVCharacterModifier TryParse(string text)
        {
            var textWithoutLinebreaks = text.Replace(System.Environment.NewLine, "");
            var lc = textWithoutLinebreaks.ToLower();
            var match = regex.Match(lc);

            if (match.Success)
            {
                return CreateSkillModification(match.Groups[category].Value, match.Groups[value].Value);
            }

            return null;
        }

        private EonIVCharacterModifier CreateSkillModification(string skillCategory, string value)
        {
            int val;
            var h = SkillCategoryHelper.TryParse(skillCategory);
            if(Int32.TryParse(value, out val))
            {
                return new EventSkillpoints()
                {
                    ApplicableCategory = SkillCategoryHelper.TryParse(skillCategory),
                    Value = val
                };
            }
            else
            {
                return null;
            }
        }

    }
}
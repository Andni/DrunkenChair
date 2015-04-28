using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.RegularExpressions;

using Niklasson.DrunkenChair.Character.Helpers;
using Niklasson.DrunkenChair.Character;
using Niklasson.DrunkenChair.DatabaseTables;

namespace Niklasson.DrunkenChair.DatabaseTables.Helpers
{
    public class SkillPointModificationParser : ISkillPointModificationParser
    {
        private const string category = "category";
        private const string value = "value";
        private const string free = "free";
        private Regex regex = new Regex(@"(?<" + value + @">\d) (?<" + free + ">valfria)? ?enheter (?<skills>(?<" + category + @">[\w]+) färdigheter)?(?<condition>[\w\s.]*)?");

        public EonIVCharacterModifier TryParse(string text)
        {
            var textWithoutLinebreaks = text.Replace(System.Environment.NewLine, " ");
            var lc = textWithoutLinebreaks.ToLower();
            var match = regex.Match(lc);

            if (match.Success)
            {
                EonIVCharacterModifier res;
                if(match.Groups[free].Success && !match.Groups["skills"].Success)
                {
                    res = CreateSkillPointModification(match.Groups[free].Value, match.Groups[value].Value);
                }
                else
                {
                    res = CreateSkillPointModification(match.Groups[category].Value, match.Groups[value].Value);
                }

                if(match.Groups["condition"].Success)
                {
                    res.Condition = match.Groups["condition"].Value;
                }
                return res;
            }

            return null;
        }

        private EonIVCharacterModifier CreateSkillPointModification(string skillCategory, string value)
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
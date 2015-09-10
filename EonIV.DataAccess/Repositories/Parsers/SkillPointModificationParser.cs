using System;
using System.Text.RegularExpressions;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Models.DataTypes;
using Environment = System.Environment;

namespace Niklasson.EonIV.DataAccess.Repositories.Parsers
{
    public class SkillPointModificationParser : ISkillPointModificationParser
    {
        private const string category = "category";
        private const string value = "value";
        private const string free = "free";
        private Regex regex = new Regex(@"(?<" + value + @">\d) (?<" + free + ">valfria)? ?enheter (?<skills>(?<" + category + @">[\w]+) färdigheter)?(?<condition>[\w\s.]*)?");

        public CharacterModifier TryParse(string text)
        {
            var textWithoutLinebreaks = text.Replace(Environment.NewLine, " ");
            var lc = textWithoutLinebreaks.ToLower();
            var match = regex.Match(lc);

            if (match.Success)
            {
                CharacterModifier res;
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

        private CharacterModifier CreateSkillPointModification(string skillCategory, string value)
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
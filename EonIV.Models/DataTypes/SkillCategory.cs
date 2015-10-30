using System.Collections.Generic;
using System.Linq;

namespace Niklasson.EonIV.Models.DataTypes
{
    public enum SkillCategory
    {
        Battle = 1,
        Knowledge = 2,
        Language = 3,
        Misc = 4,
        Movement = 5,
        Mystic = 6,
        Social = 7,
        Wilderness = 8,
        FreeChoise = 9,
        Uncategorized = 0
    }

    public static class SkillCategoryHelper
    {
        private static Dictionary<SkillCategory, string> dic = new Dictionary<SkillCategory, string>() {
            {SkillCategory.Battle, "strid"},
            {SkillCategory.Social, "sociala"},
            {SkillCategory.Wilderness, "vildmark"},
            {SkillCategory.Movement, "rörelse"},
            {SkillCategory.Mystic, "mystik"},
            {SkillCategory.Knowledge, "kunskap"},
            {SkillCategory.Language, "språk"},
            {SkillCategory.Misc, "övrigt"},
            {SkillCategory.FreeChoise, "valfria"},
            {SkillCategory.Uncategorized, "okategoriserat"}
        };

        public static SkillCategory TryParse(string cat)
        {
            var lcCat = cat.ToLower();
            return dic.SingleOrDefault(c => c.Value.ToLower().Equals(lcCat)).Key;
        }
    }
}
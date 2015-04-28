using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Niklasson.DrunkenChair.Character
{
    public enum SkillCategory
    {
        BATTLE = 1,
        KNOWLEDGE = 2,
        LANGUAGE = 3,
        MISC = 4,
        MOVEMENT = 5,
        MYSTIC = 6,
        SOCIAL = 7,
        WILDERNESS = 8,
        FREE_CHOISE = 9,
        UNCATEGORIZED = 0
    }

    public static class SkillCategoryHelper
    {
        private static Dictionary<SkillCategory, string> dic = new Dictionary<SkillCategory, string>() {
            {SkillCategory.BATTLE, "strid"},
            {SkillCategory.SOCIAL, "sociala"},
            {SkillCategory.WILDERNESS, "vildmark"},
            {SkillCategory.MOVEMENT, "rörelse"},
            {SkillCategory.MYSTIC, "mystik"},
            {SkillCategory.KNOWLEDGE, "kunskap"},
            {SkillCategory.LANGUAGE, "språk"},
            {SkillCategory.MISC, "övrigt"},
            {SkillCategory.FREE_CHOISE, "valfria"},
            {SkillCategory.UNCATEGORIZED, "okategoriserat"}
        };

        public static SkillCategory TryParse(string cat)
        {
            var lcCat = cat.ToLower();
            return dic.SingleOrDefault(c => c.Value.ToLower().Equals(lcCat)).Key;
        }
    }
}
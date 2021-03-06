﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.RegularExpressions;

using Niklasson.DrunkenChair.Character.Helpers;
using Niklasson.DrunkenChair.Character;
using Niklasson.DrunkenChair.DatabaseTables;

namespace Niklasson.DrunkenChair.DatabaseTables.Helpers
{
    public class ExpertiseParser : IModificationParser
    {
        private const string category = "category";
        private const string value = "value";
        private const string free = "free";
        private Regex regex = new Regex(@"((?<" + value + @">\d) poäng Expertiser)|(Expertisen (?<expertise>[\s\&\w]+))(?<condition>[\w\s.]*)?");

        public EonIVCharacterModifier TryParse(string text)
        {
            SpecialSkill res = null;
            //res.LearningModifier = LearningModifier.FAST_LEARNER;
            
            return res;
        }
    }
}
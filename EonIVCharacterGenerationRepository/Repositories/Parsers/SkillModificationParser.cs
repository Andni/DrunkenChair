using System.Text.RegularExpressions;
using Niklasson.EonIV.Models.BusinessObjects;

namespace Niklasson.EonIV.DataAccess.Repositories.Parsers
{
    public class SkillModificationParser : IModificationParser
    {
        private const string skill = "skill";
        private const string value = "value";
        private const string free = "free";
        private const string learning = "learning";
        private Regex regex = new Regex(@"(lättlärd i) (?<" + free + ">valfri färdighet)|(?<" + skill + @">[\w\&\s]+).? ?(?<condition>[\w\s.]*)?");
        
        public CharacterModifier TryParse(string text)
        {
            CharacterModifier res = null;
            var textWithoutLinebreaks = text.Replace(System.Environment.NewLine, " ");
            var lc = textWithoutLinebreaks.ToLower();



            return res;
        }
    }
}

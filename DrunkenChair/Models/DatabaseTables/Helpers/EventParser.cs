using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Text.RegularExpressions;

namespace DrunkenChair.Models.DatabaseTables.Helpers
{
    public class EventParser : IEventProvider
    {


        private Regex eventBasics = new Regex(@"(?<number>/d/d?) (?<name>[/s/w]+): (?<description>[/s/w]+) /[(?<modifications>[/s/w/]+)]");
        private Regex attributeMods = new Regex(@"styrka");

        
        public void ParseEventFile(string filepath)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filepath);
                string fileText = reader.ReadToEnd();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
            }
        }

        public Event ParseEvent(string text)
        {
            Event res = new Event();
            var basics = eventBasics.Match(text);

            res.Name = basics.Groups["name"].Value;
            res.Number = Convert.ToInt32(basics.Groups["number"].Value);
            res.Description = basics.Groups["description"].Value;

            return res;
        }

        private List<CharacterModificationOpitons> ParseModifiers(string text)
        {
            var res = new List<CharacterModificationOpitons>();
            var strArr = text.Split('.');
            foreach(string s in strArr)
            {
                var modifier = ParseModifier(s);
                if(modifier.Alternatives.Count > 0)
                {
                    res.Add(modifier);
                }
            }
            return res;
        }

        private CharacterModificationOpitons ParseModifier(string text)
        {
            var lowerCase = text.ToLower();
            var res = new CharacterModificationOpitons();

            if (lowerCase.Contains("styrka"))
            {
                res.Alternatives.Add(new AttributeModification());
            }

            return res;
        }

    }
}
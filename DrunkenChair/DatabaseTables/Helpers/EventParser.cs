using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Text.RegularExpressions;

using DrunkenChair.DatabaseTables;

namespace DrunkenChair.DatabaseTables.Helpers
{
    public class EventParser : IEventProvider
    {


        static string regexEvent = @"(?<number>\d\d?\d?) (?<name>[\s\w\n]+):\n?\w?(?<description>[.\,\w\n\s\’\?\”\\&(\)-]+)\n?\w?\[(?<modifications>[\n\w\s\×.\’\?\”\\&(\)\,\+\:\–]+)]";
        private Regex eventBasics = new Regex(regexEvent);
        
        static List<IModificationParser> parsers = new List<IModificationParser>() {
            new AttributeModificationParser(),
            new SkillPointModificationParser()
        };
        
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
            var textWithoutLinebreaks = text.Replace(System.Environment.NewLine, " ");
            var basics = eventBasics.Match(textWithoutLinebreaks);

            res.Name = basics.Groups["name"].Value;
            res.Number = Convert.ToInt32(basics.Groups["number"].Value);
            res.Description = basics.Groups["description"].Value;
            res.Modifications = ParseModifiers(basics.Groups["modifications"].Value);

            return res;
        }

        private List<CharacterModificationOpitons> ParseModifiers(string text)
        {
            var res = new List<CharacterModificationOpitons>();
            var strArr = text.Split(new char[]{',','.'});
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

            foreach(IModificationParser p in parsers)
            {
                var m = p.TryParse(text);
                if(m != null)
                {
                    res.Alternatives.Add(m);
                    return res;
                }
            }
            return res;
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DrunkenChair.Models.DatabaseTables;
using DrunkenChair.Models.DatabaseTables.Helpers;
using DrunkenChair.Character;

namespace DrunkenChair.Tests.EventParsing
{
    [TestClass]
    public class EventParsingTests
    {
        [TestMethod]
        public void ParseAttribute()
        {
            string attributeString = @"+2 Utstrålning.";

            AttributeModificationParser p = new AttributeModificationParser();
            AttributeModification attr = (AttributeModification) p.TryParse(attributeString);

            Assert.IsNotNull(attr);
            Assert.AreEqual(2, attr.Value);
            Assert.AreEqual(Attribute.CHARISMA, attr.Attribute);
        }

        [TestMethod]
        public void ParseSkillpoints()
        {
            string attributeString = @"4 enheter Sociala färdigheter.";

            var p = new SkillModificationParser();
            var skillpoints = (EventSkillpoints)p.TryParse(attributeString);

            Assert.IsNotNull(skillpoints);
            Assert.AreEqual(4, skillpoints.Value);
            Assert.AreEqual(SkillCategory.SOCIAL, skillpoints.ApplicableCategory);
        }

        [TestMethod]
        public void ParseEvent()
        {
            string eventString = @"9 Charmant: Rollpersonen har ett charmant
och socialt kompetent beteende och
det finns något speciellt över denne som
gör att personer har en tendens att lyssna
på vad denne säger. [+2 Utstrålning.
4 enheter
Sociala färdigheter.]";

            var eventParser = new EventParser();
            var res = eventParser.ParseEvent(eventString);

            Assert.IsNotNull(res);
            Assert.AreEqual(2, res.Modifications.Count);
        }
    }
}

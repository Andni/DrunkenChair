using Microsoft.VisualStudio.TestTools.UnitTesting;

using Niklasson.DrunkenChair.DatabaseTables;
using Niklasson.DrunkenChair.DatabaseTables.Helpers;
using Niklasson.DrunkenChair.Character;

namespace Niklasson.DrunkenChair.Tests.EventParsing
{
    [TestClass]
    public class EventParsingTests
    {
        [TestMethod]
        public void ParseAttributeModification()
        {
            string attributeString = @"+2 Utstrålning.";

            AttributeModificationParser p = new AttributeModificationParser();
            AttributeModification attr = (AttributeModification) p.TryParse(attributeString);

            Assert.IsNotNull(attr);
            Assert.AreEqual(2, attr.Value);
            Assert.AreEqual(Attribute.CHARISMA, attr.Attribute);
        }
        [TestMethod]
        public void ParseSkillpointModificationWithCondition()
        {
            string attributeString = @"2 valfria enheter knutna till dådet.";

            var p = new SkillPointModificationParser();
            var skillpoints = (EventSkillpoints) p.TryParse(attributeString);

            Assert.IsNotNull(skillpoints);
            Assert.AreEqual(2, skillpoints.Value);
            Assert.AreEqual(SkillCategory.FREE_CHOISE, skillpoints.ApplicableCategory);
            Assert.AreEqual(skillpoints.Condition, "knutna till dådet.");

        }

        [TestMethod]
        public void ParseSkillpointModification()
        {
            string attributeString = @"4 enheter Sociala färdigheter.";

            var p = new SkillPointModificationParser();
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

        [TestMethod]
        public void ParseMultipleModifications()
        {
            string text = @"+1 Psyke, +1 Utstrålning. 3 enheter
Sociala färdigheter.";

            ModificationListParser p = new ModificationListParser();
            var res = p.TryParse(text);

            Assert.AreEqual(3, res.Count);
        }

    }
}

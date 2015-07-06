using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using Niklasson.DrunkenChair.Shared.DatabaseTables;
using Niklasson.DrunkenChair.Shared.DataTypes;

using Niklasson.DrunkenChair.Models;

namespace DrunkenChairTests
{
    [TestClass]
    public class CharacterConstructorSiteTests
    {
        [TestMethod]
        public void ReplaceEventBasedOnCategoryAndIndex()
        {
            Event e = new Event();
            e.Name = "new event";

            var ccs = new CharacterConstructionSite();
            //ccs.Character.RolledEvents.Battles = GetTestEventList();

        }

        private static List<Event> GetTestEventList()
        {
            return new List<Event>()
            {
                new Event
                {
                    Name = "event 1"
                },
                new Event
                {
                    Name = "event 2"
                },
                new Event
                {
                    Name = "event 3"
                }
            };
        }

    }
}

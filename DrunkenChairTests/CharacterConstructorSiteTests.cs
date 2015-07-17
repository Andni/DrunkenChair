using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using Niklasson.DrunkenChair.Models;

namespace DrunkenChairTests
{
    [TestClass]
    public class CharacterConstructorSiteTests
    {
        [TestMethod]
        public void ReplaceEventBasedOnCategoryAndIndex()
        {
            EventViewModel e = new EventViewModel();
            e.Name = "new event";

            var ccs = new CharacterConstructionSite();
            ccs.Character.Events.BattlesAndSkirmishes = GetTestEventList();

        }

        private static List<EventViewModel> GetTestEventList()
        {
            return new List<EventViewModel>()
            {
                new EventViewModel
                {
                    Name = "event 1"
                },
                new EventViewModel
                {
                    Name = "event 2"
                },
                new EventViewModel
                {
                    Name = "event 3"
                }
            };
        }

    }
}

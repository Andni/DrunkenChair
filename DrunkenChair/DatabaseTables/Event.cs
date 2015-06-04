using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

using Niklasson.Toolbox;
using Niklasson.DrunkenChair.Models.Interfaces;
using Niklasson.DrunkenChair.Character;

namespace Niklasson.DrunkenChair.DatabaseTables
{
    public enum EventCategory
    {
        TRAVELS_AND_ADVENTURES = 1,
        INTRIGUE_AND_MISDEADS = 2,
        KNOWLEDGE_AND_MYSTERIES = 3,
        BATTLES_AND_SKIRMISHES = 4,
        UNCATEGORIZED = 0
    }

    public class Event
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }
        
        [Required]
        public EventCategory Category { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
       
        [Required]
        public virtual List<CharacterModificationOptions> Modifications { get; set; }

        public CharacterEvent ToCharacterEvent()
        {
            return new CharacterEvent()
            {
                Category = Category,
                Name = Name,
                Description = Description,
                Modifications = CollapseModificationOptions()
            };
        }

        private List<EonIVCharacterModifier> CollapseModificationOptions()
        {
            var res = new List<EonIVCharacterModifier>();
            foreach(CharacterModificationOptions o in Modifications)
            {
                res.Add(o.Collapse());
            }
            return res;
        }
    }

    public static class EventExtensions
    {

        public static IEnumerable<Event> IntrigueAndMisdeads(this IEnumerable<Event> events)
        {
            return events.Where(e => e.Category == EventCategory.INTRIGUE_AND_MISDEADS);
        }
        
        public static IEnumerable<Event> BattlesAndSkirmishes(this IEnumerable<Event> events)
        {
            return events.Where(e => e.Category == EventCategory.BATTLES_AND_SKIRMISHES);
        }

        public static IEnumerable<Event> TravelsAndAdventures(this IEnumerable<Event> events)
        {
            return events.Where(e => e.Category == EventCategory.TRAVELS_AND_ADVENTURES);
        }

        public static IEnumerable<Event> KnowledgeAndMysteries(this IEnumerable<Event> events)
        {
            return events.Where(e => e.Category == EventCategory.KNOWLEDGE_AND_MYSTERIES);
        }

        public static Event GetRandom(this IEnumerable<Event> events)
        {
            var noEvents = events.Count();
            if (noEvents == 0)
            { 
                return new Event();
            }
            else if (noEvents == 1)
            {
                return events.First();
            }
            else
            {
                var maxVal = noEvents - 1;
                return events.ToArray()[RandomNumberGenerator.Next(0, maxVal)];
            }
        }
    }
}
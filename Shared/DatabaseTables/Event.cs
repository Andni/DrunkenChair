using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.DatabaseTables
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
}
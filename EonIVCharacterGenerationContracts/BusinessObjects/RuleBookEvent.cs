using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public enum EventCategory
    {
        TRAVELS_AND_ADVENTURES = 1,
        INTRIGUE_AND_MISDEADS = 2,
        KNOWLEDGE_AND_MYSTERIES = 3,
        BATTLES_AND_SKIRMISHES = 4,
        UNCATEGORIZED = 0
    }

    public class RuleBookEvent : IRuleBookEvent
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
        public virtual List<CharacterModificationOptions> ModificationOptions { get; set; }

        public CharacterEvent ToCharacterEvent()
        {
            return new CharacterEvent()
            {
                Category = this.Category,
                Description = this.Description,
                Name = this.Name,
                Number = this.Number
            };
        }
    }

}
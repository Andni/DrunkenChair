using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Niklasson.Toolbox;
using Niklasson.EonIV.Extensions;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    public class CharacterEventSet : BaseEventSet<ICharacterEvent>
    {

        public CharacterEventSet() : base() {}

        public CharacterEventSet(IEnumerable<ICharacterEvent> events) : this()
        {
            foreach(ICharacterEvent e in events)
            {
                Add(e);
            }
        }

        public static implicit operator CharacterEventSet(List<ICharacterEvent> events)
        {
            return new CharacterEventSet
            {
                TravelsAndAdventures = new List<ICharacterEvent>(events.FilterByCategory(EventCategory.TRAVELS_AND_ADVENTURES)),
                BattlesAndSkirmishes = new List<ICharacterEvent>(events.FilterByCategory(EventCategory.BATTLES_AND_SKIRMISHES)),
                KnowledgeAndMysteries = new List<ICharacterEvent>(events.FilterByCategory(EventCategory.KNOWLEDGE_AND_MYSTERIES)),
                IntrigueAndMisdeads = new List<ICharacterEvent>(events.FilterByCategory(EventCategory.INTRIGUE_AND_MISDEADS))
            };
        }
    }
}

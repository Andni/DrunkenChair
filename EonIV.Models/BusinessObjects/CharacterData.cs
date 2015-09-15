using System.Collections.Generic;
using System.Linq;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterData : ICharacterData
    {
        public Archetype Archetype { get; set; } = new Archetype();
        public Background Background { get; set; } = new Background();
        public Environment Environment { get; set; } = new Environment();
        public Race Race { get; set; } = new Race();
        
        public BaseAttributeDices ExtraAttributeDiceDistribution { get; set; } = new BaseAttributeDices();
        public RuleBookEventSet Events { get; set; } = new RuleBookEventSet();
        
        public EventTableRolls GetEventRolls()
        {
            return Background.EventRolls + Archetype.EventRolls
                + Environment.EventRolls;
        }

        public Skillpoints GetSkillpoints()
        {
            var e = Events.GetModifiers();

            List<CategorySkillPoints> eventSkillpoints = new List<CategorySkillPoints>();
            if (e != null)
            {
                eventSkillpoints = e.Where(x => x is CategorySkillPoints).Cast<CategorySkillPoints>().ToList();
            }

            return Archetype.Skillpoints + Environment.Skillpoints
                        + eventSkillpoints;
        }
            

        public CharacterSheet ToCharacterSheet()
        {
            return new CharacterSheet(this);
        }
    }
}

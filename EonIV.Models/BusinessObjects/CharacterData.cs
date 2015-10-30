using System.Collections.Generic;
using System.Linq;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterData : ICharacterData
    {
        public Archetype Archetype { get; set; }
        public Background Background { get; set; }
        public Environment Environment { get; set; }
        public Race Race { get; set; }
        
        public BaseAttributeDices ExtraAttributeDiceDistribution { get; set; } = new BaseAttributeDices();
        public RuleBookEventSet Events { get; set; } = new RuleBookEventSet();
        
        public EventTableRolls GetEventRolls()
        {
            var res = new EventTableRolls();
            if(Background != null)
            {
                res += Background.EventRolls;
            }
            if (Environment != null)
            {
                res += Environment.EventRolls;
            }
            if (Archetype!= null)
            {
                res += Archetype.EventRolls;
            }
            return res;
        }

        public Skillpoints GetSkillpoints()
        {
            var e = Events.GetModifiers();

            List<CategorySkillPoints> eventSkillpoints = new List<CategorySkillPoints>();
            if (e != null)
            {
                eventSkillpoints = e.Where(x => x is CategorySkillPoints).Cast<CategorySkillPoints>().ToList();
            }

            var res = new Skillpoints();
            if (Environment != null)
            {
                res += Environment.Skillpoints;
            }
            if (Archetype != null)
            {
                res += Archetype.Skillpoints;
            }
            return res;
        }
            

        public CharacterSheet ToCharacterSheet()
        {
            return new CharacterSheet(this);
        }
    }
}

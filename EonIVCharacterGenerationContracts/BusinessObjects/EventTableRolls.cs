using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Niklasson.EonIV.CharacterGeneration.Contracts
{
    [ComplexType]
    public class EventTableRolls
    {
        [Display(Name = "Färder & Äventyr")]
        public int TravlesAndAdventures { get; set; }
        [Display(Name = "Intriger & Illdåd")]
        public int IntrigueAndIlldeads { get; set; }
        [Display(Name = "Kunskap & Mysterier")]
        public int KnowledgeAndMysteries { get; set; }
        [Display(Name = "Strider & Drabbningar")]
        public int BattlesAndSkirmishes { get; set; }
        [Display(Name = "Valfria")]
        public int FreeChoise { get; set; }

        public EventTableRolls() : this(0, 0, 0, 0, 0) {}

        public EventTableRolls(int travels = 0, int intrigue = 0, int knowledge = 0, int battles = 0, int free = 0)
        {
            TravlesAndAdventures = travels;
            IntrigueAndIlldeads = intrigue;
            KnowledgeAndMysteries = knowledge;
            BattlesAndSkirmishes = battles;
            FreeChoise = free;
        }

        public EventTableRolls(EventTableRolls rolls)
        {
            TravlesAndAdventures = rolls.TravlesAndAdventures;
            IntrigueAndIlldeads = rolls.IntrigueAndIlldeads;
            KnowledgeAndMysteries = rolls.KnowledgeAndMysteries;
            BattlesAndSkirmishes = rolls.BattlesAndSkirmishes;
        }

        public static EventTableRolls operator+(EventTableRolls lh, EventTableRolls rh)
        {
            if((lh == null && rh == null))
            {
                return new EventTableRolls();
            }
            else if(rh == null)
            {
                return new EventTableRolls(lh);
            }
            else if(lh == null)
            {
                return new EventTableRolls(rh);
            }
            else
            {
                return new EventTableRolls(
                    travels: lh.TravlesAndAdventures + rh.TravlesAndAdventures,
                    intrigue: lh.IntrigueAndIlldeads + rh.IntrigueAndIlldeads,
                    knowledge: lh.KnowledgeAndMysteries + rh.KnowledgeAndMysteries,
                    battles: lh.BattlesAndSkirmishes + rh.BattlesAndSkirmishes,
                    free: lh.FreeChoise + rh.FreeChoise
                );
            }
        }
    }
}
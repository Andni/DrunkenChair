using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DrunkenChair.Models
{
    [ComplexType]
    public class TableRolls
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

        public TableRolls() : this(0, 0, 0, 0, 0) {}

        public TableRolls(int travels, int intrigue, int knowledge, int battles, int free)
        {
            TravlesAndAdventures = travels;
            IntrigueAndIlldeads = intrigue;
            KnowledgeAndMysteries = knowledge;
            BattlesAndSkirmishes = battles;
            FreeChoise = free;
        }
    }
}
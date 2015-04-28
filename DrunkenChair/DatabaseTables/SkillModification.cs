using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Niklasson.DrunkenChair.Model;
using Niklasson.DrunkenChair.Character;

namespace Niklasson.DrunkenChair.DatabaseTables
{
    public class SkillModification : EonIVCharacterModifier
    {
        [Required]
        public string Name { get; set; }
        public DiceRollCheck Value { get; set; }
        public LearningModifier LearningModifier { get; set; }
    }
}
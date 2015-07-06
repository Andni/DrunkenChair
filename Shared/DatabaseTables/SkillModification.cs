using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Niklasson.DrunkenChair.Shared.DataTypes;
using Niklasson.DrunkenChair.Shared.Character;

namespace Niklasson.DrunkenChair.Shared.DatabaseTables
{
    public class SkillModification : EonIVCharacterModifier
    {
        [Required]
        public string Name { get; set; }
        public DiceRollCheck Value { get; set; }
        public LearningModifier LearningModifier { get; set; }
    }
}
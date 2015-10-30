using System.Collections.Generic;
using System.Linq;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.Models.BusinessObjects
{
    public class CharacterSkillSet : SortedSet<CharacterSkill>
    {

        private class SkillComparer : Comparer<CharacterSkill>
        {
            public override int Compare(CharacterSkill lh, CharacterSkill rh)
            {
                return lh.CompareTo(rh);
            }
        }

        private DiceRollCheck baseSkillChance = new DiceRollCheck(2, 0);

        public CharacterSkill this[string key]
        {
            get
            {
                CharacterSkill foundSkill;
                foundSkill = this.SingleOrDefault( s => s.Name.ToLower() == key.ToLower());
                return foundSkill;
            }

            set
            {
                value.Name = key;
                Add(value);
            }
        }

        public CharacterSkillSet()
        {
            this["Armborst"] = new CharacterSkill(SkillCategory.Battle) { Value = (DiceRollCheck)baseSkillChance.Value };
            this["Båge"] = new CharacterSkill(SkillCategory.Battle) { Value = (DiceRollCheck)baseSkillChance.Value };
            this["Dolk"] = new CharacterSkill(SkillCategory.Battle) { Value = (DiceRollCheck)baseSkillChance.Value };
            this["Kastvapen"] = new CharacterSkill(SkillCategory.Battle) { Value = (DiceRollCheck)baseSkillChance.Value };
            this["Klubba"] = new CharacterSkill(SkillCategory.Battle) { Value = (DiceRollCheck)baseSkillChance.Value };
            this["Kedjevapen"] = new CharacterSkill(SkillCategory.Battle) { Value = (DiceRollCheck)baseSkillChance.Value };
            this["Sköld"] = new CharacterSkill(SkillCategory.Battle) { Value = (DiceRollCheck)baseSkillChance.Value };
            this["Slagsmål"] = new CharacterSkill(SkillCategory.Battle) { Value = (DiceRollCheck) (DiceRollCheck) baseSkillChance.Value };
            this["Spjut"] = new CharacterSkill(SkillCategory.Battle) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Stav"] = new CharacterSkill(SkillCategory.Battle) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Svärd"] = new CharacterSkill(SkillCategory.Battle) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Yxa"] = new CharacterSkill(SkillCategory.Battle) { Value = (DiceRollCheck) baseSkillChance.Value };
            
            this["Dansa"] = new CharacterSkill(SkillCategory.Movement) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Fingerfärdighet"] = new CharacterSkill(SkillCategory.Movement) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Gömma"] = new CharacterSkill(SkillCategory.Movement) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Hoppa"] = new CharacterSkill(SkillCategory.Movement) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Klättra"] = new CharacterSkill(SkillCategory.Movement) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Låsdyrkning"] = new CharacterSkill(SkillCategory.Movement);
            this["Simma"] = new CharacterSkill(SkillCategory.Movement);
            this["Smyga"] = new CharacterSkill(SkillCategory.Movement) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Undvika"] = new CharacterSkill(SkillCategory.Movement) { Value = (DiceRollCheck) baseSkillChance.Value };

            this["Ceremoni"] = new CharacterSkill(SkillCategory.Mystic);
            this["Förnimma"] = new CharacterSkill(SkillCategory.Mystic);
            this["Förvränga"] = new CharacterSkill(SkillCategory.Mystic);
            this["Kanalisera"] = new CharacterSkill(SkillCategory.Mystic);
            
            this["Argumentera"] = new CharacterSkill(SkillCategory.Social) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Berättarkonst"] = new CharacterSkill(SkillCategory.Social) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Charm"] = new CharacterSkill(SkillCategory.Social) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Dupera"] = new CharacterSkill(SkillCategory.Social) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Genomskåda"] = new CharacterSkill(SkillCategory.Social) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Hovliv"] = new CharacterSkill(SkillCategory.Social);
            this["Injaga fruktan"] = new CharacterSkill(SkillCategory.Social) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Ledarskap"] = new CharacterSkill(SkillCategory.Social) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Skumraskaffärer"] = new CharacterSkill(SkillCategory.Social);
            this["Spel & dobbel"] = new CharacterSkill(SkillCategory.Social) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Sång & musik"] = new CharacterSkill(SkillCategory.Social) { Value = (DiceRollCheck) baseSkillChance.Value };

            this["Filosofi"] = new CharacterSkill(SkillCategory.Knowledge);
            this["Geografi"] = new CharacterSkill(SkillCategory.Knowledge);
            this["Gifter & droger"] = new CharacterSkill(SkillCategory.Knowledge);
            this["Handel"] = new CharacterSkill(SkillCategory.Knowledge) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Historia"] = new CharacterSkill(SkillCategory.Knowledge);
            this["Kalkylera"] = new CharacterSkill(SkillCategory.Knowledge);
            this["Kirurgi"] = new CharacterSkill(SkillCategory.Knowledge);
            this["Krigföring"] = new CharacterSkill(SkillCategory.Knowledge);
            this["Kulturkännedom"] = new CharacterSkill(SkillCategory.Knowledge);
            this["Lagkunskap"] = new CharacterSkill(SkillCategory.Knowledge);
            this["Läkekonst"] = new CharacterSkill(SkillCategory.Knowledge);
            this["Ockultism"] = new CharacterSkill(SkillCategory.Knowledge);
            this["Teologi"] = new CharacterSkill(SkillCategory.Knowledge);
            this["Teoretisk magi"] = new CharacterSkill(SkillCategory.Knowledge);
            this["Undervisa"] = new CharacterSkill(SkillCategory.Knowledge);

            this["Genomsöka"] = new CharacterSkill(SkillCategory.Wilderness) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Jakt & fiske"] = new CharacterSkill(SkillCategory.Wilderness);
            this["Köra vagn"] = new CharacterSkill(SkillCategory.Wilderness) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Marsh"] = new CharacterSkill(SkillCategory.Wilderness) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Naturlära"] = new CharacterSkill(SkillCategory.Wilderness);
            this["Navigation"] = new CharacterSkill(SkillCategory.Wilderness);
            this["Orintering"] = new CharacterSkill(SkillCategory.Wilderness) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Rida"] = new CharacterSkill(SkillCategory.Wilderness) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Filosofi"] = new CharacterSkill(SkillCategory.Wilderness);
            this["Sjömanskap"] = new CharacterSkill(SkillCategory.Wilderness);
            this["Speja"] = new CharacterSkill(SkillCategory.Wilderness) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Spåra"] = new CharacterSkill(SkillCategory.Wilderness) { Value = (DiceRollCheck) baseSkillChance.Value };
            this["Vildmarksvana"] = new CharacterSkill(SkillCategory.Wilderness);
            
        }

        public SkillCategory Battle { get; set; }
        public SkillCategory Social { get; set; }
        public SkillCategory Wilderness { get; set; }
        public SkillCategory Movement { get; set; }
        public SkillCategory Knowledge { get; set; }
        public SkillCategory Mystic { get; set; }
    }
}
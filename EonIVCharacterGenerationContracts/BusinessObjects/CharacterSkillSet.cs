using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

using Niklasson.EonIV.CharacterGeneration.Contracts;

namespace Niklasson.EonIV.CharacterGeneration.Contracts
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
            this["Armborst"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseSkillChance.Value };
            this["Båge"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseSkillChance.Value };
            this["Dolk"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseSkillChance.Value };
            this["Kastvapen"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseSkillChance.Value };
            this["Klubba"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseSkillChance.Value };
            this["Kedjevapen"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseSkillChance.Value };
            this["Sköld"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseSkillChance.Value };
            this["Slagsmål"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseSkillChance.Value };
            this["Spjut"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseSkillChance.Value };
            this["Stav"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseSkillChance.Value };
            this["Svärd"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseSkillChance.Value };
            this["Yxa"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseSkillChance.Value };
            
            this["Dansa"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseSkillChance.Value };
            this["Fingerfärdighet"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseSkillChance.Value };
            this["Gömma"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseSkillChance.Value };
            this["Hoppa"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseSkillChance.Value };
            this["Klättra"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseSkillChance.Value };
            this["Låsdyrkning"] = new CharacterSkill(SkillCategory.MOVEMENT);
            this["Simma"] = new CharacterSkill(SkillCategory.MOVEMENT);
            this["Smyga"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseSkillChance.Value };
            this["Undvika"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseSkillChance.Value };

            this["Ceremoni"] = new CharacterSkill(SkillCategory.MYSTIC);
            this["Förnimma"] = new CharacterSkill(SkillCategory.MYSTIC);
            this["Förvränga"] = new CharacterSkill(SkillCategory.MYSTIC);
            this["Kanalisera"] = new CharacterSkill(SkillCategory.MYSTIC);
            
            this["Argumentera"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseSkillChance.Value };
            this["Berättarkonst"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseSkillChance.Value };
            this["Charm"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseSkillChance.Value };
            this["Dupera"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseSkillChance.Value };
            this["Genomskåda"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseSkillChance.Value };
            this["Hovliv"] = new CharacterSkill(SkillCategory.SOCIAL);
            this["Injaga fruktan"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseSkillChance.Value };
            this["Ledarskap"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseSkillChance.Value };
            this["Skumraskaffärer"] = new CharacterSkill(SkillCategory.SOCIAL);
            this["Spel & dobbel"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseSkillChance.Value };
            this["Sång & musik"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseSkillChance.Value };

            this["Filosofi"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Geografi"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Gifter & droger"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Handel"] = new CharacterSkill(SkillCategory.KNOWLEDGE) { Value = baseSkillChance.Value };
            this["Historia"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Kalkylera"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Kirurgi"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Krigföring"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Kulturkännedom"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Lagkunskap"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Läkekonst"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Ockultism"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Teologi"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Teoretisk magi"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Undervisa"] = new CharacterSkill(SkillCategory.KNOWLEDGE);

            this["Genomsöka"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseSkillChance.Value };
            this["Jakt & fiske"] = new CharacterSkill(SkillCategory.WILDERNESS);
            this["Köra vagn"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseSkillChance.Value };
            this["Marsh"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseSkillChance.Value };
            this["Naturlära"] = new CharacterSkill(SkillCategory.WILDERNESS);
            this["Navigation"] = new CharacterSkill(SkillCategory.WILDERNESS);
            this["Orintering"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseSkillChance.Value };
            this["Rida"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseSkillChance.Value };
            this["Filosofi"] = new CharacterSkill(SkillCategory.WILDERNESS);
            this["Sjömanskap"] = new CharacterSkill(SkillCategory.WILDERNESS);
            this["Speja"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseSkillChance.Value };
            this["Spåra"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseSkillChance.Value };
            this["Vildmarksvana"] = new CharacterSkill(SkillCategory.WILDERNESS);
            
        }

        public SkillCategory Battle { get; set; }
        public SkillCategory Social { get; set; }
        public SkillCategory Wilderness { get; set; }
        public SkillCategory Movement { get; set; }
        public SkillCategory Knowledge { get; set; }
        public SkillCategory Mystic { get; set; }
    }
}
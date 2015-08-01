using System.Collections.Generic;
using System.Linq;
using Shared.DataTypes;

namespace Shared.DatabaseTables
{
    public class CharacterSkills : SortedSet<CharacterSkill>
    {

        private class SkillComparer : Comparer<CharacterSkill>
        {
            public override int Compare(CharacterSkill lh, CharacterSkill rh)
            {
                return lh.CompareTo(rh);
            }
        }

        //private SortedSet<Skill> skills = new SortedSet<Skill>( new SkillComparer());

        private DiceRollCheck baseChance = new DiceRollCheck(2, 0);

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

        public CharacterSkills()
        {
            this["Armborst"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Båge"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Dolk"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Kastvapen"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Klubba"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Kedjevapen"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Sköld"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Slagsmål"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Spjut"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Stav"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Svärd"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Yxa"] = new CharacterSkill(SkillCategory.BATTLE) { Value = baseChance.Value };
            
            this["Dansa"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseChance.Value };
            this["Fingerfärdighet"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseChance.Value };
            this["Gömma"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseChance.Value };
            this["Hoppa"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseChance.Value };
            this["Klättra"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseChance.Value };
            this["Låsdyrkning"] = new CharacterSkill(SkillCategory.MOVEMENT);
            this["Simma"] = new CharacterSkill(SkillCategory.MOVEMENT);
            this["Smyga"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseChance.Value };
            this["Undvika"] = new CharacterSkill(SkillCategory.MOVEMENT) { Value = baseChance.Value };

            this["Ceremoni"] = new CharacterSkill(SkillCategory.MYSTIC);
            this["Förnimma"] = new CharacterSkill(SkillCategory.MYSTIC);
            this["Förvränga"] = new CharacterSkill(SkillCategory.MYSTIC);
            this["Kanalisera"] = new CharacterSkill(SkillCategory.MYSTIC);
            
            this["Argumentera"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Berättarkonst"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Charm"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Dupera"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Genomskåda"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Hovliv"] = new CharacterSkill(SkillCategory.SOCIAL);
            this["Injaga fruktan"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Ledarskap"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Skumraskaffärer"] = new CharacterSkill(SkillCategory.SOCIAL);
            this["Spel & dobbel"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Sång & musik"] = new CharacterSkill(SkillCategory.SOCIAL) { Value = baseChance.Value };

            this["Filosofi"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Geografi"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Gifter & droger"] = new CharacterSkill(SkillCategory.KNOWLEDGE);
            this["Handel"] = new CharacterSkill(SkillCategory.KNOWLEDGE) { Value = baseChance.Value };
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

            this["Genomsöka"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
            this["Jakt & fiske"] = new CharacterSkill(SkillCategory.WILDERNESS);
            this["Köra vagn"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
            this["Marsh"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
            this["Naturlära"] = new CharacterSkill(SkillCategory.WILDERNESS);
            this["Navigation"] = new CharacterSkill(SkillCategory.WILDERNESS);
            this["Orintering"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
            this["Rida"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
            this["Filosofi"] = new CharacterSkill(SkillCategory.WILDERNESS);
            this["Sjömanskap"] = new CharacterSkill(SkillCategory.WILDERNESS);
            this["Speja"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
            this["Spåra"] = new CharacterSkill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
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
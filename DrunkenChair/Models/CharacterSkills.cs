using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

namespace DrunkenChair.Models
{
    public class CharacterSkills : SortedSet<Skill>
    {

        private class SkillComparer : Comparer<Skill>
        {
            public override int Compare(Skill lh, Skill rh)
            {
                return lh.CompareTo(rh);
            }
        }

        //private SortedSet<Skill> skills = new SortedSet<Skill>( new SkillComparer());

        private Attribute baseChance = new Attribute(2, 0);

        public Skill this[string key]
        {
            get
            {
                Skill foundSkill;
                foundSkill = this.SingleOrDefault( s => s.Name.ToLower() == key.ToLower());
                return foundSkill;
            }

            set
            {
                value.Name = key;
                Add(value);
            }
        }

        public bool Add(Skill s)
        {
            return Add(s);
        }

        public CharacterSkills()
        {
            this["Armborst"] = new Skill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Båge"] = new Skill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Dolk"] = new Skill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Kastvapen"] = new Skill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Klubba"] = new Skill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Kedjevapen"] = new Skill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Sköld"] = new Skill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Slagsmål"] = new Skill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Spjut"] = new Skill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Stav"] = new Skill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Svärd"] = new Skill(SkillCategory.BATTLE) { Value = baseChance.Value };
            this["Yxa"] = new Skill(SkillCategory.BATTLE) { Value = baseChance.Value };
            
            this["Dansa"] = new Skill(SkillCategory.MOVEMENT) { Value = baseChance.Value };
            this["Fingerfärdighet"] = new Skill(SkillCategory.MOVEMENT) { Value = baseChance.Value };
            this["Gömma"] = new Skill(SkillCategory.MOVEMENT) { Value = baseChance.Value };
            this["Hoppa"] = new Skill(SkillCategory.MOVEMENT) { Value = baseChance.Value };
            this["Klättra"] = new Skill(SkillCategory.MOVEMENT) { Value = baseChance.Value };
            this["Låsdyrkning"] = new Skill(SkillCategory.MOVEMENT);
            this["Simma"] = new Skill(SkillCategory.MOVEMENT);
            this["Smyga"] = new Skill(SkillCategory.MOVEMENT) { Value = baseChance.Value };
            this["Undvika"] = new Skill(SkillCategory.MOVEMENT) { Value = baseChance.Value };

            this["Ceremoni"] = new Skill(SkillCategory.MYSTIC);
            this["Förnimma"] = new Skill(SkillCategory.MYSTIC);
            this["Förvränga"] = new Skill(SkillCategory.MYSTIC);
            this["Kanalisera"] = new Skill(SkillCategory.MYSTIC);
            
            this["Argumentera"] = new Skill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Berättarkonst"] = new Skill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Charm"] = new Skill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Dupera"] = new Skill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Genomskåda"] = new Skill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Hovliv"] = new Skill(SkillCategory.SOCIAL);
            this["Injaga fruktan"] = new Skill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Ledarskap"] = new Skill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Skumraskaffärer"] = new Skill(SkillCategory.SOCIAL);
            this["Spel & dobbel"] = new Skill(SkillCategory.SOCIAL) { Value = baseChance.Value };
            this["Sång & musik"] = new Skill(SkillCategory.SOCIAL) { Value = baseChance.Value };

            this["Filosofi"] = new Skill(SkillCategory.KNOWLEDGE);
            this["Geografi"] = new Skill(SkillCategory.KNOWLEDGE);
            this["Gifter & droger"] = new Skill(SkillCategory.KNOWLEDGE);
            this["Handel"] = new Skill(SkillCategory.KNOWLEDGE) { Value = baseChance.Value };
            this["Historia"] = new Skill(SkillCategory.KNOWLEDGE);
            this["Kalkylera"] = new Skill(SkillCategory.KNOWLEDGE);
            this["Kirurgi"] = new Skill(SkillCategory.KNOWLEDGE);
            this["Krigföring"] = new Skill(SkillCategory.KNOWLEDGE);
            this["Kulturkännedom"] = new Skill(SkillCategory.KNOWLEDGE);
            this["Lagkunskap"] = new Skill(SkillCategory.KNOWLEDGE);
            this["Läkekonst"] = new Skill(SkillCategory.KNOWLEDGE);
            this["Ockultism"] = new Skill(SkillCategory.KNOWLEDGE);
            this["Teologi"] = new Skill(SkillCategory.KNOWLEDGE);
            this["Teoretisk magi"] = new Skill(SkillCategory.KNOWLEDGE);
            this["Undervisa"] = new Skill(SkillCategory.KNOWLEDGE);

            this["Genomsöka"] = new Skill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
            this["Jakt & fiske"] = new Skill(SkillCategory.WILDERNESS);
            this["Köra vagn"] = new Skill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
            this["Marsh"] = new Skill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
            this["Naturlära"] = new Skill(SkillCategory.WILDERNESS);
            this["Navigation"] = new Skill(SkillCategory.WILDERNESS);
            this["Orintering"] = new Skill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
            this["Rida"] = new Skill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
            this["Filosofi"] = new Skill(SkillCategory.WILDERNESS);
            this["Sjömanskap"] = new Skill(SkillCategory.WILDERNESS);
            this["Speja"] = new Skill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
            this["Spåra"] = new Skill(SkillCategory.WILDERNESS) { Value = baseChance.Value };
            this["Vildmarksvana"] = new Skill(SkillCategory.WILDERNESS);
            
        }

        public SkillCategory Battle { get; set; }
        public SkillCategory Social { get; set; }
        public SkillCategory Wilderness { get; set; }
        public SkillCategory Movement { get; set; }
        public SkillCategory Knowledge { get; set; }
        public SkillCategory Mystic { get; set; }
    }
}
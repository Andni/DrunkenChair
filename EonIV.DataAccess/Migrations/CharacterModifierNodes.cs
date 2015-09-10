﻿using System.Collections.Generic;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.DataAccess.Migrations
{
    public static class CharacterModifierNodes
    {
        public static List<CharacterModifierNode> GetBackgroundCharacterModifier()
        {
            return new List<CharacterModifierNode>
            {
                new CharacterModifierContainer
                {
                    new CategorySkillPoints
                    {
                        Category = SkillCategory.KNOWLEDGE,
                        SkillPoints = 4
                    },
                    new CategorySkillPoints
                    {
                        Category = SkillCategory.MYSTIC,
                        SkillPoints = 4
                    }
                },
                new CharacterModifierContainer
                {
                    new CategorySkillPoints
                    {
                        Category = SkillCategory.KNOWLEDGE,
                        SkillPoints = 4
                    },
                    new CategorySkillPoints
                    {
                        Category = SkillCategory.WILDERNESS,
                        SkillPoints = 4
                    }
                }
            };
        }
    };

    public class NodeTagGenerator
    {
        private int id;

        private string prefix;

        public NodeTagGenerator(string treeIdentifier)
        {
            this.prefix = treeIdentifier;
        }

        public string Next()
        {
            return prefix + id++;
        }

        public void ResetCounter()
        {
            id = 0;
        }
    }
}


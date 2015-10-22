using System.Collections.Generic;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.DataAccess.Migrations
{
    public static class Backgrounds
    {
        public static List<Background> GetBackgrounds()
        {
            return new List<Background>
            {
                new Background
                {
                    Number = 1,
                    Name = "Alkemist",
                    Description =
                        "Alkemisten är en konstnär besatt av att tämja de mystiska krafter som in gjutits i livets vatten som genomsyrar världen. Vissa når erkännande men många slutar som galningar efter att ha luktat för djupt i de dunster som salter och syror utsöndrar. Alkemisten viger sitt liv åt att förena magi, vetenskap och ockultism. De får dock bruka sina konster i hemlighet då inkvisitionen ser dessa som kättare och svartkonstnärer.",
                    EventRolls = new EventTableRolls {KnowledgeAndMysteries = 1},
                    Modifications = new CharacterModifierContainer
                    {
                        new CategorySkillPoints
                        {
                            Category = SkillCategory.Knowledge,
                            SkillPoints = 4
                        },
                        new CategorySkillPoints
                        {
                            Category = SkillCategory.Mystic,
                            SkillPoints = 4
                        }
                    }
                },

                new Background
                {
                    Number = 2,
                    Name = "Apotekare",
                    Description =
                        " I trånga butiker i städerna, stugor på landsbygden eller täckta vagnar som rör sig mellan byarna förrättar apotekarna sitt värv. De förser folket med extrakt, salvor och dekokter som sägs bota allt från magont, eksem och varande sår till håravfall, impotens och tandvärk. Vissa kan konsten att sätta stopp för oönskade graviditeter och andr a säljer gifter utan att ställa några frågor.",
                    EventRolls = new EventTableRolls {TravlesAndAdventures = 1},
                    Modifications = new CharacterModifierContainer
                    {
                        new CategorySkillPoints
                        {
                            Category = SkillCategory.Knowledge,
                            SkillPoints = 4
                        },
                        new CategorySkillPoints
                        {
                            Category = SkillCategory.Wilderness,
                            SkillPoints = 4
                        }
                    }
                }
            };
        } 
    }
}

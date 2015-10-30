//using System;

using System.Data.Entity.Migrations;
using Niklasson.EonIV.Models.BusinessObjects;
using Niklasson.EonIV.Models.DataTypes;

namespace Niklasson.EonIV.DataAccess.Migrations
{
    public class EventSeeder
    {
        public static void SeedEvents(EonIVCharacterGenerationDbContext context)
        {
            context.Events.AddOrUpdate(
                e => new {e.Category, e.Number},
                new RuleBookEvent()
                {
                    Category = EventCategory.TravelsAndAdventures,
                    Number = 1,
                    Name = "Allvarlig olycka",
                    Description = @"Rollpersonen har varit
                        med om en allvarlig olycka och kroppen
                        har blivit sargad och bär märken efter det
                        som skett. Det kan röra sig om brutna
                        ben, eldskador eller bettskador från ett
                        vilt djur.",
                    CharacterModifiers = new CharacterModifierContainer()
                    {
                        new CharacterModifierContainerSingleChoice()
                        {
                            new AttributeModification() {Attribute = Attribute.STRENGTH, Value = -2},
                            new AttributeModification() {Attribute = Attribute.STAMINA, Value = -2},
                            new AttributeModification() {Attribute = Attribute.MOVEMENT, Value = -2},
                            new AttributeModification() {Attribute = Attribute.PERCEPTION, Value = -2}
                        },
                        new CharacterModifierContainerSingleChoice()
                        {
                            new AttributeModification() {Attribute = Attribute.WILL, Value = EonIVValue.DiceToValue(1)},
                            new AttributeModification() {Attribute = Attribute.PSYCHE, Value = EonIVValue.DiceToValue(1)},
                            new AttributeModification() {Attribute = Attribute.WISDOM, Value = EonIVValue.DiceToValue(1)},
                            new AttributeModification() {Attribute = Attribute.CHARISMA, Value = EonIVValue.DiceToValue(1)}
                        }
                    }
                },
                new RuleBookEvent()
                {
                    Category = EventCategory.TravelsAndAdventures,
                    Number = 2,
                    Name = "Andningsteknik",
                    Description = @"Rollpersonen har lärt
                        sig olika tekniker för att kontrollera andningen
                        och kan till och med spela död
                        under en kortare tid.",
                    CharacterModifiers = new CharacterModifierContainer()
                    {
                            new Expertise() { SkillName = "Spela död"},
                            new Perk() { Description = @"Ignorerar efterverkningen Omtöcknad 
                                (se sida 176) och får en bonus på
                                +3T6 när det gäller att hålla andan eller
                                uthärda syrebrist, exempelvis vid dykning
                                eller strypning."}
                    }
                },
                new RuleBookEvent()
                {
                    Category = EventCategory.IntrigueAndMisdeads,
                    Number = 564,
                    Name = "Test event",
                    Description = @"Rollpersonen har varit med om en allvarlig olycka och kroppenhar blivit sargad och bär märken efter det som skett. Det kan röra sig om brutna ben, eldskador eller bettskador från ett vilt djur.",
                    CharacterModifiers = new CharacterModifierContainer()
                    {
                        new CharacterModifierContainerSingleChoice()
                        {
                            new AttributeModification() {Attribute = Attribute.MOVEMENT, Value = -2},
                            new AttributeModification() {Attribute = Attribute.PERCEPTION, Value = -2}
                        },
                        new CharacterModifierContainerSingleChoice()
                        {
                            new AttributeModification() {Attribute = Attribute.WILL, Value = EonIVValue.DiceToValue(1)},
                            new AttributeModification() {Attribute = Attribute.PSYCHE, Value = EonIVValue.DiceToValue(1)},
                        }
                    }
                }
            );
        }
    }
}
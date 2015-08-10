namespace Niklasson.EonIV.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archetypes",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        EventRolls_TravlesAndAdventures = c.Int(nullable: false),
                        EventRolls_IntrigueAndIlldeads = c.Int(nullable: false),
                        EventRolls_KnowledgeAndMysteries = c.Int(nullable: false),
                        EventRolls_BattlesAndSkirmishes = c.Int(nullable: false),
                        EventRolls_FreeChoise = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Backgrounds",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        EventRolls_TravlesAndAdventures = c.Int(nullable: false),
                        EventRolls_IntrigueAndIlldeads = c.Int(nullable: false),
                        EventRolls_KnowledgeAndMysteries = c.Int(nullable: false),
                        EventRolls_BattlesAndSkirmishes = c.Int(nullable: false),
                        EventRolls_FreeChoise = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.CharacterModifierNodes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Condition = c.String(),
                        SelectedAlternativeIndex = c.Int(),
                        Attribute = c.Int(),
                        Value = c.Int(),
                        Value1 = c.Int(),
                        ApplicableCategory = c.Int(),
                        Description = c.String(),
                        Name = c.String(),
                        Value_Value = c.Int(),
                        LearningModifier = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Parent_ID = c.Int(),
                        CharacterModifierContainer_ID = c.Int(),
                        ParentContainer_ID = c.Int(),
                        Background_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CharacterModifierNodes", t => t.Parent_ID)
                .ForeignKey("dbo.CharacterModifierNodes", t => t.CharacterModifierContainer_ID)
                .ForeignKey("dbo.CharacterModifierNodes", t => t.ParentContainer_ID)
                .ForeignKey("dbo.Backgrounds", t => t.Background_Name)
                .Index(t => t.Parent_ID)
                .Index(t => t.CharacterModifierContainer_ID)
                .Index(t => t.ParentContainer_ID)
                .Index(t => t.Background_Name);
            
            CreateTable(
                "dbo.Environments",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Skills_Battle = c.Int(nullable: false),
                        Skills_Social = c.Int(nullable: false),
                        Skills_Knowledge = c.Int(nullable: false),
                        Skills_Mystic = c.Int(nullable: false),
                        Skills_Movement = c.Int(nullable: false),
                        Skills_Wilderness = c.Int(nullable: false),
                        Skills_FreeChoise = c.Int(nullable: false),
                        EventRolls_TravlesAndAdventures = c.Int(nullable: false),
                        EventRolls_IntrigueAndIlldeads = c.Int(nullable: false),
                        EventRolls_KnowledgeAndMysteries = c.Int(nullable: false),
                        EventRolls_BattlesAndSkirmishes = c.Int(nullable: false),
                        EventRolls_FreeChoise = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.RuleBookEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CharacterModifiers_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CharacterModifierNodes", t => t.CharacterModifiers_ID)
                .Index(t => t.CharacterModifiers_ID);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        StartingAttributes_Strength_Value = c.Int(nullable: false),
                        StartingAttributes_Stamina_Value = c.Int(nullable: false),
                        StartingAttributes_Agility_Value = c.Int(nullable: false),
                        StartingAttributes_Perception_Value = c.Int(nullable: false),
                        StartingAttributes_Will_Value = c.Int(nullable: false),
                        StartingAttributes_Psyche_Value = c.Int(nullable: false),
                        StartingAttributes_Wisdom_Value = c.Int(nullable: false),
                        StartingAttributes_Charisma_Value = c.Int(nullable: false),
                        EventRolls_TravlesAndAdventures = c.Int(nullable: false),
                        EventRolls_IntrigueAndIlldeads = c.Int(nullable: false),
                        EventRolls_KnowledgeAndMysteries = c.Int(nullable: false),
                        EventRolls_BattlesAndSkirmishes = c.Int(nullable: false),
                        EventRolls_FreeChoise = c.Int(nullable: false),
                        Perks = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RuleBookEvents", "CharacterModifiers_ID", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.CharacterModifierNodes", "Background_Name", "dbo.Backgrounds");
            DropForeignKey("dbo.CharacterModifierNodes", "ParentContainer_ID", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.CharacterModifierNodes", "CharacterModifierContainer_ID", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.CharacterModifierNodes", "Parent_ID", "dbo.CharacterModifierNodes");
            DropIndex("dbo.RuleBookEvents", new[] { "CharacterModifiers_ID" });
            DropIndex("dbo.CharacterModifierNodes", new[] { "Background_Name" });
            DropIndex("dbo.CharacterModifierNodes", new[] { "ParentContainer_ID" });
            DropIndex("dbo.CharacterModifierNodes", new[] { "CharacterModifierContainer_ID" });
            DropIndex("dbo.CharacterModifierNodes", new[] { "Parent_ID" });
            DropTable("dbo.Races");
            DropTable("dbo.RuleBookEvents");
            DropTable("dbo.Environments");
            DropTable("dbo.CharacterModifierNodes");
            DropTable("dbo.Backgrounds");
            DropTable("dbo.Archetypes");
        }
    }
}

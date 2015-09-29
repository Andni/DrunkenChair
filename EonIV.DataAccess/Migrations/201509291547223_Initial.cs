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
                        Skillpoints_Battle = c.Int(nullable: false),
                        Skillpoints_Social = c.Int(nullable: false),
                        Skillpoints_Knowledge = c.Int(nullable: false),
                        Skillpoints_Mystic = c.Int(nullable: false),
                        Skillpoints_Movement = c.Int(nullable: false),
                        Skillpoints_Wilderness = c.Int(nullable: false),
                        Skillpoints_FreeChoise = c.Int(nullable: false),
                        ResourcesContainerId = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.CharacterModifierNodes", t => t.ResourcesContainerId)
                .Index(t => t.ResourcesContainerId);
            
            CreateTable(
                "dbo.CharacterModifierNodes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Description = c.String(),
                        ParentNodeId = c.Int(),
                        Condition = c.String(),
                        Coverage = c.Int(),
                        Attribute = c.Int(),
                        Value = c.Int(),
                        Value1 = c.Int(),
                        ApplicableCategory = c.Int(),
                        BaseItemId = c.Int(),
                        Rarity = c.Int(),
                        NumberOfHolyItems = c.Int(),
                        Crosses = c.Int(),
                        Type = c.Int(),
                        NumberOfMysteries = c.Int(),
                        Dices_Value = c.Int(),
                        SilverMultiplier = c.Int(),
                        SkillName = c.String(),
                        Value_Value = c.Int(),
                        LearningModifier = c.Int(),
                        SkillPoints = c.Int(),
                        SkillCategory = c.Int(),
                        SpecialSkillCategory = c.Int(),
                        SpecialSkillPoints = c.Int(),
                        Value_Value1 = c.Int(),
                        SpecialSkillVoucherCategory = c.Int(),
                        NumberOfChoices = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        AddedProperties_ItemPropertiesId = c.Int(),
                        WeaponVoucher_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CharacterModifierNodes", t => t.ParentNodeId)
                .ForeignKey("dbo.BaseItems", t => t.BaseItemId, cascadeDelete: true)
                .ForeignKey("dbo.ItemProperties", t => t.AddedProperties_ItemPropertiesId)
                .ForeignKey("dbo.CharacterModifierNodes", t => t.WeaponVoucher_ID)
                .Index(t => t.ParentNodeId)
                .Index(t => t.BaseItemId)
                .Index(t => t.AddedProperties_ItemPropertiesId)
                .Index(t => t.WeaponVoucher_ID);
            
            CreateTable(
                "dbo.BaseItems",
                c => new
                    {
                        BaseItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        Description = c.String(),
                        Value = c.Int(nullable: false),
                        PropertiesContainerId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.BaseItemId)
                .ForeignKey("dbo.ItemProperties", t => t.PropertiesContainerId, cascadeDelete: true)
                .Index(t => t.PropertiesContainerId);
            
            CreateTable(
                "dbo.ItemProperties",
                c => new
                    {
                        ItemPropertiesId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ItemPropertiesId);
            
            CreateTable(
                "dbo.Backgrounds",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Number = c.Int(nullable: false),
                        Description = c.String(),
                        EventRolls_TravlesAndAdventures = c.Int(nullable: false),
                        EventRolls_IntrigueAndIlldeads = c.Int(nullable: false),
                        EventRolls_KnowledgeAndMysteries = c.Int(nullable: false),
                        EventRolls_BattlesAndSkirmishes = c.Int(nullable: false),
                        EventRolls_FreeChoise = c.Int(nullable: false),
                        ModificationContainerId = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.CharacterModifierNodes", t => t.ModificationContainerId)
                .Index(t => t.ModificationContainerId);
            
            CreateTable(
                "dbo.Environments",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        EventRolls_TravlesAndAdventures = c.Int(nullable: false),
                        EventRolls_IntrigueAndIlldeads = c.Int(nullable: false),
                        EventRolls_KnowledgeAndMysteries = c.Int(nullable: false),
                        EventRolls_BattlesAndSkirmishes = c.Int(nullable: false),
                        EventRolls_FreeChoise = c.Int(nullable: false),
                        Skillpoints_Battle = c.Int(nullable: false),
                        Skillpoints_Social = c.Int(nullable: false),
                        Skillpoints_Knowledge = c.Int(nullable: false),
                        Skillpoints_Mystic = c.Int(nullable: false),
                        Skillpoints_Movement = c.Int(nullable: false),
                        Skillpoints_Wilderness = c.Int(nullable: false),
                        Skillpoints_FreeChoise = c.Int(nullable: false),
                        StartingSilver = c.Int(nullable: false),
                        GearAndResourcesContainerId = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.CharacterModifierNodes", t => t.GearAndResourcesContainerId)
                .Index(t => t.GearAndResourcesContainerId);
            
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
                        PerkContainerId = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.CharacterModifierNodes", t => t.PerkContainerId)
                .Index(t => t.PerkContainerId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Written = c.Boolean(nullable: false),
                        Race_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Races", t => t.Race_Name)
                .Index(t => t.Race_Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Races", "PerkContainerId", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.Languages", "Race_Name", "dbo.Races");
            DropForeignKey("dbo.RuleBookEvents", "CharacterModifiers_ID", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.Environments", "GearAndResourcesContainerId", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.Backgrounds", "ModificationContainerId", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.Archetypes", "ResourcesContainerId", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.CharacterModifierNodes", "WeaponVoucher_ID", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.CharacterModifierNodes", "AddedProperties_ItemPropertiesId", "dbo.ItemProperties");
            DropForeignKey("dbo.CharacterModifierNodes", "BaseItemId", "dbo.BaseItems");
            DropForeignKey("dbo.BaseItems", "PropertiesContainerId", "dbo.ItemProperties");
            DropForeignKey("dbo.CharacterModifierNodes", "ParentNodeId", "dbo.CharacterModifierNodes");
            DropIndex("dbo.Languages", new[] { "Race_Name" });
            DropIndex("dbo.Races", new[] { "PerkContainerId" });
            DropIndex("dbo.RuleBookEvents", new[] { "CharacterModifiers_ID" });
            DropIndex("dbo.Environments", new[] { "GearAndResourcesContainerId" });
            DropIndex("dbo.Backgrounds", new[] { "ModificationContainerId" });
            DropIndex("dbo.BaseItems", new[] { "PropertiesContainerId" });
            DropIndex("dbo.CharacterModifierNodes", new[] { "WeaponVoucher_ID" });
            DropIndex("dbo.CharacterModifierNodes", new[] { "AddedProperties_ItemPropertiesId" });
            DropIndex("dbo.CharacterModifierNodes", new[] { "BaseItemId" });
            DropIndex("dbo.CharacterModifierNodes", new[] { "ParentNodeId" });
            DropIndex("dbo.Archetypes", new[] { "ResourcesContainerId" });
            DropTable("dbo.Languages");
            DropTable("dbo.Races");
            DropTable("dbo.RuleBookEvents");
            DropTable("dbo.Environments");
            DropTable("dbo.Backgrounds");
            DropTable("dbo.ItemProperties");
            DropTable("dbo.BaseItems");
            DropTable("dbo.CharacterModifierNodes");
            DropTable("dbo.Archetypes");
        }
    }
}

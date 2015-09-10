namespace Niklasson.EonIV.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RaceEnvironmentOverhaulAndAddedItems : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Archetypes", "Skillpoints_Battle", c => c.Int(nullable: false));
            AddColumn("dbo.Archetypes", "Skillpoints_Social", c => c.Int(nullable: false));
            AddColumn("dbo.Archetypes", "Skillpoints_Knowledge", c => c.Int(nullable: false));
            AddColumn("dbo.Archetypes", "Skillpoints_Mystic", c => c.Int(nullable: false));
            AddColumn("dbo.Archetypes", "Skillpoints_Movement", c => c.Int(nullable: false));
            AddColumn("dbo.Archetypes", "Skillpoints_Wilderness", c => c.Int(nullable: false));
            AddColumn("dbo.Archetypes", "Skillpoints_FreeChoise", c => c.Int(nullable: false));
            AddColumn("dbo.Archetypes", "ResourcesContainerId", c => c.Int());
            AddColumn("dbo.CharacterModifierNodes", "Label", c => c.String());
            AddColumn("dbo.CharacterModifierNodes", "BaseItemId", c => c.Int());
            AddColumn("dbo.CharacterModifierNodes", "Crosses", c => c.Int());
            AddColumn("dbo.CharacterModifierNodes", "Type", c => c.Int());
            AddColumn("dbo.CharacterModifierNodes", "Dices_Value", c => c.Int());
            AddColumn("dbo.CharacterModifierNodes", "SilverMultiplier", c => c.Int());
            AddColumn("dbo.CharacterModifierNodes", "Description1", c => c.String());
            AddColumn("dbo.CharacterModifierNodes", "SkillName", c => c.String());
            AddColumn("dbo.Environments", "StartingSilver", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "GearAndResourcesContainerId", c => c.Int());
            AddColumn("dbo.Races", "PerkContainerId", c => c.Int());
            CreateIndex("dbo.Archetypes", "ResourcesContainerId");
            CreateIndex("dbo.CharacterModifierNodes", "BaseItemId");
            CreateIndex("dbo.Environments", "GearAndResourcesContainerId");
            CreateIndex("dbo.Races", "PerkContainerId");
            AddForeignKey("dbo.CharacterModifierNodes", "BaseItemId", "dbo.BaseItems", "BaseItemId", cascadeDelete: true);
            AddForeignKey("dbo.Archetypes", "ResourcesContainerId", "dbo.CharacterModifierNodes", "ID");
            AddForeignKey("dbo.Environments", "GearAndResourcesContainerId", "dbo.CharacterModifierNodes", "ID");
            AddForeignKey("dbo.Races", "PerkContainerId", "dbo.CharacterModifierNodes", "ID");
            DropColumn("dbo.CharacterModifierNodes", "AbsoluteIdentifier");
            DropColumn("dbo.CharacterModifierNodes", "Name");
            DropColumn("dbo.Races", "EventRolls_TravlesAndAdventures");
            DropColumn("dbo.Races", "EventRolls_IntrigueAndIlldeads");
            DropColumn("dbo.Races", "EventRolls_KnowledgeAndMysteries");
            DropColumn("dbo.Races", "EventRolls_BattlesAndSkirmishes");
            DropColumn("dbo.Races", "EventRolls_FreeChoise");
            DropColumn("dbo.Races", "Perks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Races", "Perks", c => c.String());
            AddColumn("dbo.Races", "EventRolls_FreeChoise", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "EventRolls_BattlesAndSkirmishes", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "EventRolls_KnowledgeAndMysteries", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "EventRolls_IntrigueAndIlldeads", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "EventRolls_TravlesAndAdventures", c => c.Int(nullable: false));
            AddColumn("dbo.CharacterModifierNodes", "Name", c => c.String());
            AddColumn("dbo.CharacterModifierNodes", "AbsoluteIdentifier", c => c.String());
            DropForeignKey("dbo.Races", "PerkContainerId", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.Languages", "Race_Name", "dbo.Races");
            DropForeignKey("dbo.Environments", "GearAndResourcesContainerId", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.Archetypes", "ResourcesContainerId", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.CharacterModifierNodes", "BaseItemId", "dbo.BaseItems");
            DropForeignKey("dbo.BaseItems", "PropertiesContainerId", "dbo.ItemProperties");
            DropIndex("dbo.Languages", new[] { "Race_Name" });
            DropIndex("dbo.Races", new[] { "PerkContainerId" });
            DropIndex("dbo.Environments", new[] { "GearAndResourcesContainerId" });
            DropIndex("dbo.BaseItems", new[] { "PropertiesContainerId" });
            DropIndex("dbo.CharacterModifierNodes", new[] { "BaseItemId" });
            DropIndex("dbo.Archetypes", new[] { "ResourcesContainerId" });
            DropColumn("dbo.Races", "PerkContainerId");
            DropColumn("dbo.Environments", "GearAndResourcesContainerId");
            DropColumn("dbo.Environments", "StartingSilver");
            DropColumn("dbo.CharacterModifierNodes", "SkillName");
            DropColumn("dbo.CharacterModifierNodes", "Description1");
            DropColumn("dbo.CharacterModifierNodes", "SilverMultiplier");
            DropColumn("dbo.CharacterModifierNodes", "Dices_Value");
            DropColumn("dbo.CharacterModifierNodes", "Type");
            DropColumn("dbo.CharacterModifierNodes", "Crosses");
            DropColumn("dbo.CharacterModifierNodes", "BaseItemId");
            DropColumn("dbo.CharacterModifierNodes", "Label");
            DropColumn("dbo.Archetypes", "ResourcesContainerId");
            DropColumn("dbo.Archetypes", "Skillpoints_FreeChoise");
            DropColumn("dbo.Archetypes", "Skillpoints_Wilderness");
            DropColumn("dbo.Archetypes", "Skillpoints_Movement");
            DropColumn("dbo.Archetypes", "Skillpoints_Mystic");
            DropColumn("dbo.Archetypes", "Skillpoints_Knowledge");
            DropColumn("dbo.Archetypes", "Skillpoints_Social");
            DropColumn("dbo.Archetypes", "Skillpoints_Battle");
            DropTable("dbo.Languages");
            DropTable("dbo.ItemProperties");
            DropTable("dbo.BaseItems");
        }
    }
}

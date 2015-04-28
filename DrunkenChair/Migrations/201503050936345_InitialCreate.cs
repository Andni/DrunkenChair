namespace Niklasson.DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EonIvCharacters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Basics_Background = c.String(),
                        Basics_Archetype = c.String(),
                        Basics_Race = c.String(),
                        Basics_Environment = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Archetypes",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        LifeEventRolls_TravlesAndAdventures = c.Int(nullable: false),
                        LifeEventRolls_IntrigueAndIlldeads = c.Int(nullable: false),
                        LifeEventRolls_KnowledgeAndMysteries = c.Int(nullable: false),
                        LifeEventRolls_BattlesAndSkirmishes = c.Int(nullable: false),
                        LifeEventRolls_FreeChoise = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Events_TravlesAndAdventures = c.Int(nullable: false),
                        Events_IntrigueAndIlldeads = c.Int(nullable: false),
                        Events_KnowledgeAndMysteries = c.Int(nullable: false),
                        Events_BattlesAndSkirmishes = c.Int(nullable: false),
                        Events_FreeChoise = c.Int(nullable: false),
                        StartingResources = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Races");
            DropTable("dbo.Archetypes");
            DropTable("dbo.EonIvCharacters");
        }
    }
}

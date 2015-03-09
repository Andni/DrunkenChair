namespace DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEnvironmentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Environments",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Events_TravlesAndAdventures = c.Int(nullable: false),
                        Events_IntrigueAndIlldeads = c.Int(nullable: false),
                        Events_KnowledgeAndMysteries = c.Int(nullable: false),
                        Events_BattlesAndSkirmishes = c.Int(nullable: false),
                        Events_FreeChoise = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Environments");
        }
    }
}

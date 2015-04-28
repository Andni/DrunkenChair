namespace Niklasson.DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventBuildingBlocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventBuildingBlocks");
        }
    }
}

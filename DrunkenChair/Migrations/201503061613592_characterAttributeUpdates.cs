namespace Niklasson.DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class characterAttributeUpdates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharacterCreationConstants",
                c => new
                    {
                        constant = c.Int(nullable: false),
                        value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.constant);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CharacterCreationConstants");
        }
    }
}

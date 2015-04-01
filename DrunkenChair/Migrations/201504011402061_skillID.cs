namespace DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skillID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Skills", new[] { "Name" });
            AlterColumn("dbo.Skills", "Name", c => c.String());
            AddPrimaryKey("dbo.Skills", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Skills", new[] { "ID" });
            AddPrimaryKey("dbo.Skills", "Name");
            AlterColumn("dbo.Skills", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Skills", "ID");
        }
    }
}

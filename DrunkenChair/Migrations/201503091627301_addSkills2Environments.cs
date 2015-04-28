namespace Niklasson.DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSkills2Environments : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Environments", "Skills_Swords", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Environments", "Skills_Swords", c => c.Int(nullable: false));
        }
    }
}

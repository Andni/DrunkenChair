namespace DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skillpointsUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Environments", "Skills_Battle", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skills_Social", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skills_Knowledge", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skills_Mystic", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skills_Movement", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skills_Wilderness", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skills_FreeChoise", c => c.Int(nullable: false));
            DropColumn("dbo.Environments", "Skills_Swords");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Environments", "Skills_Swords", c => c.Int(nullable: false));
            DropColumn("dbo.Environments", "Skills_FreeChoise");
            DropColumn("dbo.Environments", "Skills_Wilderness");
            DropColumn("dbo.Environments", "Skills_Movement");
            DropColumn("dbo.Environments", "Skills_Mystic");
            DropColumn("dbo.Environments", "Skills_Knowledge");
            DropColumn("dbo.Environments", "Skills_Social");
            DropColumn("dbo.Environments", "Skills_Battle");
        }
    }
}

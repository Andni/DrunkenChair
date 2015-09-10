namespace Niklasson.EonIV.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedEnvironmentSkillpoints : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Environments", "Skillpoints_Battle", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skillpoints_Social", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skillpoints_Knowledge", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skillpoints_Mystic", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skillpoints_Movement", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skillpoints_Wilderness", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skillpoints_FreeChoise", c => c.Int(nullable: false));
            DropColumn("dbo.Environments", "Skills_Battle");
            DropColumn("dbo.Environments", "Skills_Social");
            DropColumn("dbo.Environments", "Skills_Knowledge");
            DropColumn("dbo.Environments", "Skills_Mystic");
            DropColumn("dbo.Environments", "Skills_Movement");
            DropColumn("dbo.Environments", "Skills_Wilderness");
            DropColumn("dbo.Environments", "Skills_FreeChoise");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Environments", "Skills_FreeChoise", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skills_Wilderness", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skills_Movement", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skills_Mystic", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skills_Knowledge", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skills_Social", c => c.Int(nullable: false));
            AddColumn("dbo.Environments", "Skills_Battle", c => c.Int(nullable: false));
            DropColumn("dbo.Environments", "Skillpoints_FreeChoise");
            DropColumn("dbo.Environments", "Skillpoints_Wilderness");
            DropColumn("dbo.Environments", "Skillpoints_Movement");
            DropColumn("dbo.Environments", "Skillpoints_Mystic");
            DropColumn("dbo.Environments", "Skillpoints_Knowledge");
            DropColumn("dbo.Environments", "Skillpoints_Social");
            DropColumn("dbo.Environments", "Skillpoints_Battle");
        }
    }
}

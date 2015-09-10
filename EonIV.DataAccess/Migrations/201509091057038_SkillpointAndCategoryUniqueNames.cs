namespace Niklasson.EonIV.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkillpointAndCategoryUniqueNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CharacterModifierNodes", "SkillPoints", c => c.Int());
            AddColumn("dbo.CharacterModifierNodes", "SkillCategory", c => c.Int());
            AddColumn("dbo.CharacterModifierNodes", "SpecialSkillCategory", c => c.Int());
            AddColumn("dbo.CharacterModifierNodes", "SpecialSkillPoints", c => c.Int());
            DropColumn("dbo.CharacterModifierNodes", "Category");
            DropColumn("dbo.CharacterModifierNodes", "Points");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CharacterModifierNodes", "Points", c => c.Int());
            AddColumn("dbo.CharacterModifierNodes", "Category", c => c.Int());
            DropColumn("dbo.CharacterModifierNodes", "SpecialSkillPoints");
            DropColumn("dbo.CharacterModifierNodes", "SpecialSkillCategory");
            DropColumn("dbo.CharacterModifierNodes", "SkillCategory");
            DropColumn("dbo.CharacterModifierNodes", "SkillPoints");
        }
    }
}

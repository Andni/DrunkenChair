namespace DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class characterAttributeUpdates1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CharacterCreationConstants", "Constant", c => c.Int(nullable: false));
            AlterColumn("dbo.CharacterCreationConstants", "Value", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.CharacterCreationConstants", new[] { "constant" });
            AddPrimaryKey("dbo.CharacterCreationConstants", "Constant");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CharacterCreationConstants", new[] { "Constant" });
            AddPrimaryKey("dbo.CharacterCreationConstants", "constant");
            AlterColumn("dbo.CharacterCreationConstants", "value", c => c.Int(nullable: false));
            AlterColumn("dbo.CharacterCreationConstants", "constant", c => c.Int(nullable: false));
        }
    }
}

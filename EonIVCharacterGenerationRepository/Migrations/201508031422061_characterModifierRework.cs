namespace Niklasson.EonIV.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class characterModifierRework : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CharacterModifiers", newName: "CharacterModifierNodes");
            DropForeignKey("dbo.CharacterModificationOptions", "EventsID", "dbo.RuleBookEvents");
            DropForeignKey("dbo.CharacterModifierNodes", "FK_dbo.EonIVCharacterModifiers_dbo.CharacterModificationOptions_CharacterModificationOptions_ID");
            DropForeignKey("dbo.CharacterModifierNodes", "CharacterModificationOptions_ID", "dbo.CharacterModificationOptions");
            DropIndex("dbo.CharacterModifierNodes", new[] { "CharacterModificationOptions_ID" });
            DropIndex("dbo.CharacterModificationOptions", new[] { "EventsID" });
            AddColumn("dbo.CharacterModifierNodes", "CharacterModifierContainer_ID", c => c.Int());
            AddColumn("dbo.CharacterModifierNodes", "ParentContainer_ID", c => c.Int());
            AddColumn("dbo.RuleBookEvents", "CharacterModifiers_ID", c => c.Int());
            CreateIndex("dbo.CharacterModifierNodes", "CharacterModifierContainer_ID");
            CreateIndex("dbo.CharacterModifierNodes", "ParentContainer_ID");
            CreateIndex("dbo.RuleBookEvents", "CharacterModifiers_ID");
            AddForeignKey("dbo.CharacterModifierNodes", "CharacterModifierContainer_ID", "dbo.CharacterModifierNodes", "ID");
            AddForeignKey("dbo.CharacterModifierNodes", "ParentContainer_ID", "dbo.CharacterModifierNodes", "ID");
            AddForeignKey("dbo.RuleBookEvents", "CharacterModifiers_ID", "dbo.CharacterModifierNodes", "ID");
            DropColumn("dbo.CharacterModifierNodes", "CharacterModificationOptions_ID");
            DropTable("dbo.CharacterModificationOptions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CharacterModificationOptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.CharacterModifierNodes", "CharacterModificationOptions_ID", c => c.Int());
            DropForeignKey("dbo.RuleBookEvents", "CharacterModifiers_ID", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.CharacterModifierNodes", "ParentContainer_ID", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.CharacterModifierNodes", "CharacterModifierContainer_ID", "dbo.CharacterModifierNodes");
            DropIndex("dbo.RuleBookEvents", new[] { "CharacterModifiers_ID" });
            DropIndex("dbo.CharacterModifierNodes", new[] { "ParentContainer_ID" });
            DropIndex("dbo.CharacterModifierNodes", new[] { "CharacterModifierContainer_ID" });
            DropColumn("dbo.RuleBookEvents", "CharacterModifiers_ID");
            DropColumn("dbo.CharacterModifierNodes", "ParentContainer_ID");
            DropColumn("dbo.CharacterModifierNodes", "CharacterModifierContainer_ID");
            CreateIndex("dbo.CharacterModificationOptions", "EventsID");
            CreateIndex("dbo.CharacterModifierNodes", "CharacterModificationOptions_ID");
            AddForeignKey("dbo.CharacterModifiers", "CharacterModificationOptions_ID", "dbo.CharacterModificationOptions", "ID");
            AddForeignKey("dbo.CharacterModificationOptions", "EventsID", "dbo.RuleBookEvents", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.CharacterModifierNodes", newName: "CharacterModifiers");
        }
    }
}

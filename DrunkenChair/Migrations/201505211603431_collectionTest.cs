namespace Niklasson.DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class collectionTest : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EonIVCharacterModifiers", newName: "CharacterModifierBases");
            DropForeignKey("dbo.EonIVCharacterModifiers", "CharacterModificationOptionsID", "dbo.CharacterModificationOptions");
            DropForeignKey("dbo.CharacterModificationOptions", "EventsID", "dbo.Events");
            DropIndex("dbo.CharacterModifierBases", new[] { "CharacterModificationOptionsID" });
            DropIndex("dbo.CharacterModificationOptions", new[] { "EventsID" });
            RenameColumn(table: "dbo.CharacterModifierBases", name: "EonIVCharacterModifier_ID", newName: "EonIVCharacterModifierSelectorID");
            RenameIndex(table: "dbo.CharacterModifierBases", name: "IX_EonIVCharacterModifier_ID", newName: "IX_EonIVCharacterModifierSelectorID");
            AddColumn("dbo.CharacterModifierBases", "EventsID", c => c.Int(nullable: false));
            AddColumn("dbo.CharacterModifierBases", "CharacterModificationOptions_ID", c => c.Int());
            AddColumn("dbo.CharacterModifierBases", "Event_Id", c => c.Int());
            CreateIndex("dbo.CharacterModifierBases", "Event_Id");
            AddForeignKey("dbo.CharacterModifierBases", "Event_Id", "dbo.Events", "Id");
            DropColumn("dbo.CharacterModifierBases", "CharacterModificationOptionsID");
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
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.CharacterModifierBases", "CharacterModificationOptionsID", c => c.Int(nullable: false));
            DropForeignKey("dbo.CharacterModifierBases", "Event_Id", "dbo.Events");
            DropIndex("dbo.CharacterModifierBases", new[] { "Event_Id" });
            DropColumn("dbo.CharacterModifierBases", "Event_Id");
            DropColumn("dbo.CharacterModifierBases", "CharacterModificationOptions_ID");
            DropColumn("dbo.CharacterModifierBases", "EventsID");
            RenameIndex(table: "dbo.CharacterModifierBases", name: "IX_EonIVCharacterModifierSelectorID", newName: "IX_EonIVCharacterModifier_ID");
            RenameColumn(table: "dbo.CharacterModifierBases", name: "EonIVCharacterModifierSelectorID", newName: "EonIVCharacterModifier_ID");
            CreateIndex("dbo.CharacterModificationOptions", "EventsID");
            CreateIndex("dbo.CharacterModifierBases", "CharacterModificationOptionsID");
            AddForeignKey("dbo.CharacterModificationOptions", "EventsID", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EonIVCharacterModifiers", "CharacterModificationOptionsID", "dbo.CharacterModificationOptions", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.CharacterModifierBases", newName: "EonIVCharacterModifiers");
        }
    }
}

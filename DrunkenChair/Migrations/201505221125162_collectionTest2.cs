namespace Niklasson.DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class collectionTest2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CharacterModifierBases", "EonIVCharacterModifierSelectorID", "dbo.CharacterModifierBases");
            DropForeignKey("dbo.CharacterModifierBases", "Event_Id", "dbo.Events");
            RenameTable(name: "dbo.CharacterModifierBases", newName: "EonIVCharacterModifiers");
            DropIndex("dbo.EonIVCharacterModifiers", new[] { "EonIVCharacterModifierSelectorID" });
            DropIndex("dbo.EonIVCharacterModifiers", new[] { "Event_Id" });
            CreateTable(
                "dbo.CharacterModificationOptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Events", t => t.EventsID, cascadeDelete: true)
                .Index(t => t.EventsID);
            
            //RenameColumn(table: "dbo.CharacterModificationOptions", name: "Event_Id", newName: "EventsID");
            CreateIndex("dbo.EonIVCharacterModifiers", "CharacterModificationOptions_ID");
            AddForeignKey("dbo.EonIVCharacterModifiers", "CharacterModificationOptions_ID", "dbo.CharacterModificationOptions", "ID");
            DropForeignKey("dbo.EonIVCharacterModifiers", "EonIVCharacterModifierSelectorID", "dbo.EonIVCharacterModifiers");
            DropForeignKey("dbo.EonIVCharacterModifiers", "FK_dbo.EonIVCharacterModifiers_dbo.EonIVCharacterModifiers_EonIVCharacterModifier_ID");
            DropColumn("dbo.EonIVCharacterModifiers", "EventsID");
            DropColumn("dbo.EonIVCharacterModifiers", "EonIVCharacterModifierSelectorID");
            DropColumn("dbo.EonIVCharacterModifiers", "Event_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EonIVCharacterModifiers", "Event_Id", c => c.Int());
            AddColumn("dbo.EonIVCharacterModifiers", "EonIVCharacterModifierSelectorID", c => c.Int());
            AddColumn("dbo.EonIVCharacterModifiers", "EventsID", c => c.Int(nullable: false));
            DropForeignKey("dbo.CharacterModificationOptions", "EventsID", "dbo.Events");
            DropForeignKey("dbo.EonIVCharacterModifiers", "CharacterModificationOptions_ID", "dbo.CharacterModificationOptions");
            DropIndex("dbo.CharacterModificationOptions", new[] { "EventsID" });
            DropIndex("dbo.EonIVCharacterModifiers", new[] { "CharacterModificationOptions_ID" });
            RenameColumn(table: "dbo.CharacterModificationOptions", name: "EventsID", newName: "Event_Id");
            DropTable("dbo.CharacterModificationOptions");
            CreateIndex("dbo.EonIVCharacterModifiers", "Event_Id");
            CreateIndex("dbo.EonIVCharacterModifiers", "EonIVCharacterModifierSelectorID");
            RenameTable(name: "dbo.EonIVCharacterModifiers", newName: "CharacterModifierBases");
            AddForeignKey("dbo.CharacterModifierBases", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.CharacterModifierBases", "EonIVCharacterModifierSelectorID", "dbo.CharacterModifierBases", "ID");
        }
    }
}

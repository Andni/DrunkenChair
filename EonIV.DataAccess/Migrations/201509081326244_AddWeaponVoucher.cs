namespace Niklasson.EonIV.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeaponVoucher : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CharacterModifierNodes", "Description");
            RenameColumn(table: "dbo.CharacterModifierNodes", name: "Description1", newName: "Description");
            AddColumn("dbo.CharacterModifierNodes", "Rarity", c => c.Int());
            AddColumn("dbo.CharacterModifierNodes", "AddedProperties_ItemPropertiesId", c => c.Int());
            AddColumn("dbo.CharacterModifierNodes", "WeaponVoucher_ID", c => c.Int());
            CreateIndex("dbo.CharacterModifierNodes", "AddedProperties_ItemPropertiesId");
            CreateIndex("dbo.CharacterModifierNodes", "WeaponVoucher_ID");
            AddForeignKey("dbo.CharacterModifierNodes", "AddedProperties_ItemPropertiesId", "dbo.ItemProperties", "ItemPropertiesId");
            AddForeignKey("dbo.CharacterModifierNodes", "WeaponVoucher_ID", "dbo.CharacterModifierNodes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharacterModifierNodes", "WeaponVoucher_ID", "dbo.CharacterModifierNodes");
            DropForeignKey("dbo.CharacterModifierNodes", "AddedProperties_ItemPropertiesId", "dbo.ItemProperties");
            DropIndex("dbo.CharacterModifierNodes", new[] { "WeaponVoucher_ID" });
            DropIndex("dbo.CharacterModifierNodes", new[] { "AddedProperties_ItemPropertiesId" });
            DropColumn("dbo.CharacterModifierNodes", "WeaponVoucher_ID");
            DropColumn("dbo.CharacterModifierNodes", "AddedProperties_ItemPropertiesId");
            DropColumn("dbo.CharacterModifierNodes", "Rarity");
            RenameColumn(table: "dbo.CharacterModifierNodes", name: "Description", newName: "Description1");
            AddColumn("dbo.CharacterModifierNodes", "Description", c => c.String());
        }
    }
}

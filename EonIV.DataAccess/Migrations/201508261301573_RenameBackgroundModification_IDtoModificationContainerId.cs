using System.Data.Entity.Migrations;

namespace Niklasson.EonIV.DataAccess.Migrations
{
    public partial class RenameBackgroundModification_IDtoModificationContainerId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Backgrounds", name: "Modifications_ID", newName: "ModificationContainerId");
            RenameIndex(table: "dbo.Backgrounds", name: "IX_Modifications_ID", newName: "IX_ModificationContainerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Backgrounds", name: "IX_ModificationContainerId", newName: "IX_Modifications_ID");
            RenameColumn(table: "dbo.Backgrounds", name: "ModificationContainerId", newName: "Modifications_ID");
        }
    }
}

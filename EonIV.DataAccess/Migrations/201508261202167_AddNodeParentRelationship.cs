using System.Data.Entity.Migrations;

namespace Niklasson.EonIV.DataAccess.Migrations
{
    public partial class AddNodeParentRelationship : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.CharacterModifierNodes", "ParentNodeId", "dbo.CharacterModifierNodes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharacterModifierNodes", "ParentNodeId", "dbo.CharacterModifierNodes");
        }
    }
}

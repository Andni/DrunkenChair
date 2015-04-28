namespace Niklasson.DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class raceStartingResources2Perks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Races", "Perks", c => c.String());
            DropColumn("dbo.Races", "StartingResources");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Races", "StartingResources", c => c.String());
            DropColumn("dbo.Races", "Perks");
        }
    }
}

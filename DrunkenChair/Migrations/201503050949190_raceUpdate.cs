namespace DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class raceUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Races", "StartingAttributes_Strength_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Strength_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Stamina_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Stamina_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Agility_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Agility_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Perception_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Perception_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Will_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Will_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Psyche_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Psyche_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Wisdom_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Wisdom_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Charisma_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Charisma_Bonus", c => c.Int(nullable: false));
            DropColumn("dbo.Races", "Events_TravlesAndAdventures");
            DropColumn("dbo.Races", "Events_IntrigueAndIlldeads");
            DropColumn("dbo.Races", "Events_KnowledgeAndMysteries");
            DropColumn("dbo.Races", "Events_BattlesAndSkirmishes");
            DropColumn("dbo.Races", "Events_FreeChoise");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Races", "Events_FreeChoise", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "Events_BattlesAndSkirmishes", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "Events_KnowledgeAndMysteries", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "Events_IntrigueAndIlldeads", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "Events_TravlesAndAdventures", c => c.Int(nullable: false));
            DropColumn("dbo.Races", "StartingAttributes_Charisma_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Charisma_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Wisdom_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Wisdom_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Psyche_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Psyche_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Will_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Will_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Perception_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Perception_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Agility_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Agility_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Stamina_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Stamina_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Strength_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Strength_UnlimitedDice6");
        }
    }
}

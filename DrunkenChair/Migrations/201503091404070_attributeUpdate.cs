namespace Niklasson.DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attributeUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EonIvCharacters", "Attributes_Strength_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Strength_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Stamina_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Stamina_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Agility_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Agility_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Perception_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Perception_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Will_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Will_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Psyche_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Psyche_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Wisdom_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Wisdom_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Charisma_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Charisma_Bonus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EonIvCharacters", "Attributes_Charisma_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Charisma_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Wisdom_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Wisdom_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Psyche_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Psyche_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Will_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Will_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Perception_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Perception_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Agility_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Agility_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Stamina_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Stamina_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Strength_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Strength_UnlimitedDice6");
        }
    }
}

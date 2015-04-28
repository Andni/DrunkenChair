namespace Niklasson.DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttributeChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Races", "StartingAttributes_Strength_Value", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Stamina_Value", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Agility_Value", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Perception_Value", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Will_Value", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Psyche_Value", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Wisdom_Value", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Charisma_Value", c => c.Int(nullable: false));
            DropColumn("dbo.EonIvCharacters", "Attributes_Strength_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Strength_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Stamina_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Stamina_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Agility_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Agility_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Perception_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Perception_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Will_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Will_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Psyche_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Psyche_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Wisdom_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Wisdom_Bonus");
            DropColumn("dbo.EonIvCharacters", "Attributes_Charisma_UnlimitedDice6");
            DropColumn("dbo.EonIvCharacters", "Attributes_Charisma_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Strength_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Strength_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Stamina_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Stamina_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Agility_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Agility_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Perception_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Perception_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Will_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Will_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Psyche_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Psyche_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Wisdom_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Wisdom_Bonus");
            DropColumn("dbo.Races", "StartingAttributes_Charisma_UnlimitedDice6");
            DropColumn("dbo.Races", "StartingAttributes_Charisma_Bonus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Races", "StartingAttributes_Charisma_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Charisma_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Wisdom_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Wisdom_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Psyche_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Psyche_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Will_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Will_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Perception_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Perception_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Agility_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Agility_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Stamina_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Stamina_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Strength_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "StartingAttributes_Strength_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Charisma_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Charisma_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Wisdom_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Wisdom_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Psyche_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Psyche_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Will_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Will_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Perception_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Perception_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Agility_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Agility_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Stamina_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Stamina_UnlimitedDice6", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Strength_Bonus", c => c.Int(nullable: false));
            AddColumn("dbo.EonIvCharacters", "Attributes_Strength_UnlimitedDice6", c => c.Int(nullable: false));
            DropColumn("dbo.Races", "StartingAttributes_Charisma_Value");
            DropColumn("dbo.Races", "StartingAttributes_Wisdom_Value");
            DropColumn("dbo.Races", "StartingAttributes_Psyche_Value");
            DropColumn("dbo.Races", "StartingAttributes_Will_Value");
            DropColumn("dbo.Races", "StartingAttributes_Perception_Value");
            DropColumn("dbo.Races", "StartingAttributes_Agility_Value");
            DropColumn("dbo.Races", "StartingAttributes_Stamina_Value");
            DropColumn("dbo.Races", "StartingAttributes_Strength_Value");
        }
    }
}

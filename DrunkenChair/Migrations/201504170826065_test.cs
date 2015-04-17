namespace DrunkenChair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Skills", newName: "CharacterSkills");
            CreateTable(
                "dbo.Backgrounds",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            AddColumn("dbo.EonIvCharacters", "Archetype_Name", c => c.String(maxLength: 128));
            AddColumn("dbo.EonIvCharacters", "Background_Name", c => c.String(maxLength: 128));
            AddColumn("dbo.EonIvCharacters", "Environment_Name", c => c.String(maxLength: 128));
            AddColumn("dbo.EonIvCharacters", "Race_Name", c => c.String(maxLength: 128));
            AddColumn("dbo.Events", "Category", c => c.Int(nullable: false));
            AddColumn("dbo.EonIVCharacterModifiers", "Condition", c => c.String());
            AddColumn("dbo.EonIVCharacterModifiers", "Value1", c => c.Int());
            AddColumn("dbo.EonIVCharacterModifiers", "Description", c => c.String());
            AddColumn("dbo.EonIVCharacterModifiers", "Name", c => c.String());
            AddColumn("dbo.EonIVCharacterModifiers", "Value_Value", c => c.Int());
            AddColumn("dbo.EonIVCharacterModifiers", "LearningModifier", c => c.Int());
            AddColumn("dbo.EonIVCharacterModifiers", "Background_Name", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false));
            CreateIndex("dbo.EonIvCharacters", "Archetype_Name");
            CreateIndex("dbo.EonIvCharacters", "Background_Name");
            CreateIndex("dbo.EonIvCharacters", "Environment_Name");
            CreateIndex("dbo.EonIvCharacters", "Race_Name");
            CreateIndex("dbo.EonIVCharacterModifiers", "Background_Name");
            AddForeignKey("dbo.EonIvCharacters", "Archetype_Name", "dbo.Archetypes", "Name");
            AddForeignKey("dbo.EonIVCharacterModifiers", "Background_Name", "dbo.Backgrounds", "Name");
            AddForeignKey("dbo.EonIvCharacters", "Background_Name", "dbo.Backgrounds", "Name");
            AddForeignKey("dbo.EonIvCharacters", "Environment_Name", "dbo.Environments", "Name");
            AddForeignKey("dbo.EonIvCharacters", "Race_Name", "dbo.Races", "Name");
            DropColumn("dbo.EonIvCharacters", "Basics_Background");
            DropColumn("dbo.EonIvCharacters", "Basics_Archetype");
            DropColumn("dbo.EonIvCharacters", "Basics_Race");
            DropColumn("dbo.EonIvCharacters", "Basics_Environment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EonIvCharacters", "Basics_Environment", c => c.String());
            AddColumn("dbo.EonIvCharacters", "Basics_Race", c => c.String());
            AddColumn("dbo.EonIvCharacters", "Basics_Archetype", c => c.String());
            AddColumn("dbo.EonIvCharacters", "Basics_Background", c => c.String());
            DropForeignKey("dbo.EonIvCharacters", "Race_Name", "dbo.Races");
            DropForeignKey("dbo.EonIvCharacters", "Environment_Name", "dbo.Environments");
            DropForeignKey("dbo.EonIvCharacters", "Background_Name", "dbo.Backgrounds");
            DropForeignKey("dbo.EonIVCharacterModifiers", "Background_Name", "dbo.Backgrounds");
            DropForeignKey("dbo.EonIvCharacters", "Archetype_Name", "dbo.Archetypes");
            DropIndex("dbo.EonIVCharacterModifiers", new[] { "Background_Name" });
            DropIndex("dbo.EonIvCharacters", new[] { "Race_Name" });
            DropIndex("dbo.EonIvCharacters", new[] { "Environment_Name" });
            DropIndex("dbo.EonIvCharacters", new[] { "Background_Name" });
            DropIndex("dbo.EonIvCharacters", new[] { "Archetype_Name" });
            AlterColumn("dbo.Events", "Description", c => c.String());
            AlterColumn("dbo.Events", "Name", c => c.String());
            DropColumn("dbo.EonIVCharacterModifiers", "Background_Name");
            DropColumn("dbo.EonIVCharacterModifiers", "LearningModifier");
            DropColumn("dbo.EonIVCharacterModifiers", "Value_Value");
            DropColumn("dbo.EonIVCharacterModifiers", "Name");
            DropColumn("dbo.EonIVCharacterModifiers", "Description");
            DropColumn("dbo.EonIVCharacterModifiers", "Value1");
            DropColumn("dbo.EonIVCharacterModifiers", "Condition");
            DropColumn("dbo.Events", "Category");
            DropColumn("dbo.EonIvCharacters", "Race_Name");
            DropColumn("dbo.EonIvCharacters", "Environment_Name");
            DropColumn("dbo.EonIvCharacters", "Background_Name");
            DropColumn("dbo.EonIvCharacters", "Archetype_Name");
            DropTable("dbo.Backgrounds");
            RenameTable(name: "dbo.CharacterSkills", newName: "Skills");
        }
    }
}

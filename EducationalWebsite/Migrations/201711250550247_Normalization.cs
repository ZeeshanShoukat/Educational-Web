namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Normalization : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ClassCode", "dbo.Classes");
            DropForeignKey("dbo.Students", "SectionId", "dbo.ClassSections");
            DropIndex("dbo.Students", new[] { "ClassCode" });
            DropIndex("dbo.Students", new[] { "SectionId" });
            DropColumn("dbo.ClassDetails", "Strength");
            DropColumn("dbo.Students", "Roll_No");
            DropColumn("dbo.Students", "ClassCode");
            DropColumn("dbo.Students", "SectionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "SectionId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "ClassCode", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Roll_No", c => c.String());
            AddColumn("dbo.ClassDetails", "Strength", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "SectionId");
            CreateIndex("dbo.Students", "ClassCode");
            AddForeignKey("dbo.Students", "SectionId", "dbo.ClassSections", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "ClassCode", "dbo.Classes", "Id", cascadeDelete: true);
        }
    }
}

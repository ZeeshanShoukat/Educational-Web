namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationsectionstudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Students", "SectionId");
            AddForeignKey("dbo.Students", "SectionId", "dbo.ClassSections", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "SectionId", "dbo.ClassSections");
            DropIndex("dbo.Students", new[] { "SectionId" });
            DropTable("dbo.ClassSections");
        }
    }
}

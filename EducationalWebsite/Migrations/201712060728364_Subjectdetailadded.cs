namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subjectdetailadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.ClassId)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectDetails", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.SubjectDetails", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectDetails", "ClassId", "dbo.Classes");
            DropIndex("dbo.SubjectDetails", new[] { "TeacherId" });
            DropIndex("dbo.SubjectDetails", new[] { "ClassId" });
            DropIndex("dbo.SubjectDetails", new[] { "SubjectId" });
            DropTable("dbo.SubjectDetails");
        }
    }
}

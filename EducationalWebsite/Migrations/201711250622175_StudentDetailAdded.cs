namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentDetailAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        Roll_No = c.String(),
                        ClassCode = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                        SessionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassCode, cascadeDelete: true)
                .ForeignKey("dbo.ClassSections", t => t.SectionId, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.ClassCode)
                .Index(t => t.SectionId)
                .Index(t => t.SessionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentDetails", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentDetails", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.StudentDetails", "SectionId", "dbo.ClassSections");
            DropForeignKey("dbo.StudentDetails", "ClassCode", "dbo.Classes");
            DropIndex("dbo.StudentDetails", new[] { "SessionId" });
            DropIndex("dbo.StudentDetails", new[] { "SectionId" });
            DropIndex("dbo.StudentDetails", new[] { "ClassCode" });
            DropIndex("dbo.StudentDetails", new[] { "StudentID" });
            DropTable("dbo.StudentDetails");
        }
    }
}

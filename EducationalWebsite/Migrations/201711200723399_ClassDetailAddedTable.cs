namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassDetailAddedTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(nullable: false),
                        ClassSctionId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.ClassSections", t => t.ClassSctionId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.ClassSctionId)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassDetails", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.ClassDetails", "ClassSctionId", "dbo.ClassSections");
            DropForeignKey("dbo.ClassDetails", "ClassId", "dbo.Classes");
            DropIndex("dbo.ClassDetails", new[] { "TeacherId" });
            DropIndex("dbo.ClassDetails", new[] { "ClassSctionId" });
            DropIndex("dbo.ClassDetails", new[] { "ClassId" });
            DropTable("dbo.ClassDetails");
        }
    }
}

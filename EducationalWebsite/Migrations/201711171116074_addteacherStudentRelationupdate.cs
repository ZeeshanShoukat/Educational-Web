namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addteacherStudentRelationupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "TeacherId");
            AddForeignKey("dbo.Students", "TeacherId", "dbo.Teachers", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Students", new[] { "TeacherId" });
            DropColumn("dbo.Students", "TeacherId");
        }
    }
}

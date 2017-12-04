namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "GenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "GenderId");
            AddForeignKey("dbo.Teachers", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
            DropColumn("dbo.Teachers", "EmployeeCode");
            DropColumn("dbo.Teachers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Email", c => c.String());
            AddColumn("dbo.Teachers", "EmployeeCode", c => c.String());
            DropForeignKey("dbo.Teachers", "GenderId", "dbo.Genders");
            DropIndex("dbo.Teachers", new[] { "GenderId" });
            DropColumn("dbo.Teachers", "GenderId");
        }
    }
}

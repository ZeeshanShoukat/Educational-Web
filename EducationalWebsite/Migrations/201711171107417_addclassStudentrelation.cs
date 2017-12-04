namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addclassStudentrelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ClassCode", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "ClassCode");
            AddForeignKey("dbo.Students", "ClassCode", "dbo.Classes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ClassCode", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "ClassCode" });
            DropColumn("dbo.Students", "ClassCode");
        }
    }
}

namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentTeacherRelatio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Students", new[] { "TeacherId" });
            AddColumn("dbo.Classes", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Classes", "TeacherId");
            AddForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers", "id", cascadeDelete: true);
            DropColumn("dbo.Students", "TeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "TeacherId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropColumn("dbo.Classes", "TeacherId");
            CreateIndex("dbo.Students", "TeacherId");
            AddForeignKey("dbo.Students", "TeacherId", "dbo.Teachers", "id", cascadeDelete: true);
        }
    }
}

namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentgenderRelation3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Students", "GenderId");
            AddForeignKey("dbo.Students", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "GenderId", "dbo.Genders");
            DropIndex("dbo.Students", new[] { "GenderId" });
        }
    }
}

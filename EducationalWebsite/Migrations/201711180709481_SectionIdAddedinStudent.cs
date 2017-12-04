namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SectionIdAddedinStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "SectionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "SectionId");
        }
    }
}

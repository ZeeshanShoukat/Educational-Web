namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterationinstudent : DbMigration
    {
        public override void Up()
        {
          //  DropColumn("dbo.Students", "MotherName");
        }
        
        public override void Down()
        {
          //  AddColumn("dbo.Students", "MotherName", c => c.String());
        }
    }
}

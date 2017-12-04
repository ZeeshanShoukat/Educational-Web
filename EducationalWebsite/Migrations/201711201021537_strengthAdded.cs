namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class strengthAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassDetails", "Strength", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassDetails", "Strength");
        }
    }
}

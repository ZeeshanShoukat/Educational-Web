namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentgenderRelation1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "GenderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "GenderId");
        }
    }
}

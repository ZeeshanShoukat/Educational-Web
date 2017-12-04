namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SessionAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ClassDetails", "SessionId", c => c.Int(nullable: false));
            CreateIndex("dbo.ClassDetails", "SessionId");
            AddForeignKey("dbo.ClassDetails", "SessionId", "dbo.Sessions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassDetails", "SessionId", "dbo.Sessions");
            DropIndex("dbo.ClassDetails", new[] { "SessionId" });
            DropColumn("dbo.ClassDetails", "SessionId");
            DropTable("dbo.Sessions");
        }
    }
}

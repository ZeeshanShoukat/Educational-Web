namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabledrop : DbMigration
    {
        public override void Up()
        {
          // DropTable("dbo.Classes");
            //DropTable("dbo.Teachers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        EmployeeCode = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FatherName = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        CNIC = c.String(),
                        Email = c.String(),
                        ContactNumber = c.String(),
                        PresentAddress = c.String(),
                        PermenentAddress = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

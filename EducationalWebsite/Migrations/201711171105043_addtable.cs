namespace EducationalWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
        }
    }
}

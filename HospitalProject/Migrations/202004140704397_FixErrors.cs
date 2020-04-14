namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixErrors : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Donations", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Donations", "DesignationId", "dbo.Provinces");
            DropIndex("dbo.Donations", new[] { "DesignationId" });
            DropTable("dbo.Donations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        DesignationId = c.Int(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        City = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Donations", "DesignationId");
            AddForeignKey("dbo.Donations", "DesignationId", "dbo.Provinces", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Donations", "DesignationId", "dbo.Designations", "Id", cascadeDelete: true);
        }
    }
}

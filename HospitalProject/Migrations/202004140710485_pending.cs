namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pending : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.DesignationId)
                .Index(t => t.ProvinceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Donations", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Donations", new[] { "ProvinceId" });
            DropIndex("dbo.Donations", new[] { "DesignationId" });
            DropTable("dbo.Donations");
        }
    }
}

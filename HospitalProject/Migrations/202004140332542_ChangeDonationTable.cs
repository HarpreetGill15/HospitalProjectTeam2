namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDonationTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Donations", "DonorId", "dbo.Donors");
            DropIndex("dbo.Donations", new[] { "DonorId" });
            DropPrimaryKey("dbo.Donations");
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Initials = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Donations", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.Donations", "FirstName", c => c.String());
            AddColumn("dbo.Donations", "LastName", c => c.String());
            AddColumn("dbo.Donations", "Email", c => c.String());
            AddColumn("dbo.Donations", "Phone", c => c.String());
            AddColumn("dbo.Donations", "DesignationId", c => c.Int(nullable: false));
            AddColumn("dbo.Donations", "ProvinceId", c => c.Int(nullable: false));
            AddColumn("dbo.Donations", "City", c => c.String());
            AddColumn("dbo.Donations", "ZipCode", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Donations", "Id");
            CreateIndex("dbo.Donations", "Id");
            AddForeignKey("dbo.Donations", "Id", "dbo.Designations", "Id");
            AddForeignKey("dbo.Donations", "Id", "dbo.Provinces", "Id");
            DropColumn("dbo.Donations", "DonationId");
            DropColumn("dbo.Donations", "DonorId");
            DropTable("dbo.Donors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        DonorId = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        PCode = c.String(),
                    })
                .PrimaryKey(t => t.DonorId);
            
            AddColumn("dbo.Donations", "DonorId", c => c.Int(nullable: false));
            AddColumn("dbo.Donations", "DonationId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Donations", "Id", "dbo.Provinces");
            DropForeignKey("dbo.Donations", "Id", "dbo.Designations");
            DropIndex("dbo.Donations", new[] { "Id" });
            DropPrimaryKey("dbo.Donations");
            DropColumn("dbo.Donations", "ZipCode");
            DropColumn("dbo.Donations", "City");
            DropColumn("dbo.Donations", "ProvinceId");
            DropColumn("dbo.Donations", "DesignationId");
            DropColumn("dbo.Donations", "Phone");
            DropColumn("dbo.Donations", "Email");
            DropColumn("dbo.Donations", "LastName");
            DropColumn("dbo.Donations", "FirstName");
            DropColumn("dbo.Donations", "Id");
            DropTable("dbo.Provinces");
            DropTable("dbo.Designations");
            AddPrimaryKey("dbo.Donations", "DonationId");
            CreateIndex("dbo.Donations", "DonorId");
            AddForeignKey("dbo.Donations", "DonorId", "dbo.Donors", "DonorId", cascadeDelete: true);
        }
    }
}

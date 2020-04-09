namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDonorDonation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        DonationId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        DonorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DonationId)
                .ForeignKey("dbo.Donors", t => t.DonorId, cascadeDelete: true)
                .Index(t => t.DonorId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "DonorId", "dbo.Donors");
            DropIndex("dbo.Donations", new[] { "DonorId" });
            DropTable("dbo.Donors");
            DropTable("dbo.Donations");
        }
    }
}

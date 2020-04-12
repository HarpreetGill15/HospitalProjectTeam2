namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notifications : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applications", "JobId", "dbo.Jobs");
            DropIndex("dbo.Applications", new[] { "JobId" });
            DropColumn("dbo.Blogs", "DateCreated");
            DropTable("dbo.Applications");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        applicationId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        emailId = c.String(),
                        coverLetter = c.String(),
                        JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.applicationId);
            
            AddColumn("dbo.Blogs", "DateCreated", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Applications", "JobId");
            AddForeignKey("dbo.Applications", "JobId", "dbo.Jobs", "jobId", cascadeDelete: true);
        }
    }
}

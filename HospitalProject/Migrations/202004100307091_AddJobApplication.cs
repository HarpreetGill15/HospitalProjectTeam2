namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobApplication : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.applicationId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        jobId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        skill = c.String(),
                        description = c.String(),
                        type = c.String(),
                        salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.jobId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "JobId", "dbo.Jobs");
            DropIndex("dbo.Applications", new[] { "JobId" });
            DropTable("dbo.Jobs");
            DropTable("dbo.Applications");
        }
    }
}

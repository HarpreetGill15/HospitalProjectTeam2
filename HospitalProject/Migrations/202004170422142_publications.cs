namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        TitleImage = c.String(),
                        Body = c.String(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publications", t => t.ParentId)
                .Index(t => t.ParentId);
            Sql("INSERT INTO Publications(Title) VALUES ('Patients');");
            Sql("INSERT INTO Publications(Title) VALUES ('Visitors');");

            Sql("INSERT INTO Publications(Title, Body, ParentId) SELECT 'No Visitor Policy - March 2020', 'Commencing March 16, 2020, visitors are currently restricted. Exceptions will be considered for compassionate care, when assisting a minor or special circumstances (one visitor per family, per patient).', Id FROM Publications WHERE Title = 'Patients';");
            Sql("INSERT INTO Publications(Title, Body, ParentId) SELECT 'Safe Care... What is Your Role', 'What is your role and responsibility as a patient coming to, or leaving the Collingwood G&M Hospital. Find out what questions you should ask, what medications you should bring, what you should share with your healthcare team', Id FROM Publications WHERE Title = 'Patients';");
            Sql("INSERT INTO Publications(Title, Body, ParentId) SELECT 'What to bring', 'Please bring the following items when you are coming to be admitted to the hospital: Ontario Health Card; Proof of additional health insurance coverage for preferred hospital accommodations(if you have this)', Id FROM Publications WHERE Title = 'Patients';");

            Sql("INSERT INTO Publications(Title, Body, ParentId) SELECT 'Smoke Free / Scent Free Campus', 'CGMH is a Smoke Free Environment as of May 31, 2008. The smoke free environment includes all buildings and grounds.', Id FROM Publications WHERE Title = 'Visitors';");
            Sql("INSERT INTO Publications(Title, Body, ParentId) SELECT 'Map, Directions & Transit', 'Collingwood General Hospital is conveniently located at 459 Hume Street, Collingwood, Ontario.', Id FROM Publications WHERE Title = 'Visitors';");
            Sql("INSERT INTO Publications(Title, Body, ParentId) SELECT 'Respecting Privacy', 'As a visitor at CGMH you adhere to respecting the privacy of patients and visitors. Photography, videography and audio recording is not permitted while inside CGMH. We also kindly ask you set your cell phones to vibrate.', Id FROM Publications WHERE Title = 'Visitors';");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Publications", "ParentId", "dbo.Publications");
            DropIndex("dbo.Publications", new[] { "ParentId" });
            DropTable("dbo.Publications");
        }
    }
}

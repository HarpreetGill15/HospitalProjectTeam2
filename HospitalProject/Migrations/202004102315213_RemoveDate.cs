namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blogs", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}

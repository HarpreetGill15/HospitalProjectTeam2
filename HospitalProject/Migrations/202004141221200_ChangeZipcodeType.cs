namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeZipcodeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donations", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donations", "ZipCode", c => c.Int(nullable: false));
        }
    }
}

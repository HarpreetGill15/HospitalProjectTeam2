namespace HospitalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificationsandfeedbacks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.FeedbackTypes",
                c => new
                    {
                        typeId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.typeId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Feedback = c.String(),
                        typeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.FeedbackTypes", t => t.typeId, cascadeDelete: true)
                .Index(t => t.typeId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        headline = c.String(),
                        content = c.String(),
                        active = c.Int(nullable: false),
                        typeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.NotificationTypes", t => t.typeId, cascadeDelete: true)
                .Index(t => t.typeId);
            
            CreateTable(
                "dbo.NotificationTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.FeedbackTypesDepartments",
                c => new
                    {
                        FeedbackTypes_typeId = c.Int(nullable: false),
                        Departments_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FeedbackTypes_typeId, t.Departments_id })
                .ForeignKey("dbo.FeedbackTypes", t => t.FeedbackTypes_typeId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Departments_id, cascadeDelete: true)
                .Index(t => t.FeedbackTypes_typeId)
                .Index(t => t.Departments_id);
            
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Notifications", "typeId", "dbo.NotificationTypes");
            DropForeignKey("dbo.Feedbacks", "typeId", "dbo.FeedbackTypes");
            DropForeignKey("dbo.FeedbackTypesDepartments", "Departments_id", "dbo.Departments");
            DropForeignKey("dbo.FeedbackTypesDepartments", "FeedbackTypes_typeId", "dbo.FeedbackTypes");
            DropIndex("dbo.FeedbackTypesDepartments", new[] { "Departments_id" });
            DropIndex("dbo.FeedbackTypesDepartments", new[] { "FeedbackTypes_typeId" });
            DropIndex("dbo.Notifications", new[] { "typeId" });
            DropIndex("dbo.Feedbacks", new[] { "typeId" });
            DropTable("dbo.FeedbackTypesDepartments");
            DropTable("dbo.NotificationTypes");
            DropTable("dbo.Notifications");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.FeedbackTypes");
            DropTable("dbo.Departments");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}

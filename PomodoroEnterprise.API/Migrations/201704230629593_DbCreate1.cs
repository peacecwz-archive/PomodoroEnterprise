namespace PomodoroEnterprise.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Users", new[] { "OrganizationId" });
            AlterColumn("dbo.Users", "OrganizationId", c => c.Int());
            CreateIndex("dbo.Users", "OrganizationId");
            AddForeignKey("dbo.Users", "OrganizationId", "dbo.Organizations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Users", new[] { "OrganizationId" });
            AlterColumn("dbo.Users", "OrganizationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "OrganizationId");
            AddForeignKey("dbo.Users", "OrganizationId", "dbo.Organizations", "Id", cascadeDelete: true);
        }
    }
}

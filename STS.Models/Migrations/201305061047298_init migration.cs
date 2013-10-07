namespace STS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initmigration : DbMigration
    {
        public override void Up()
        {
            
           
            AlterColumn("dbo.Users", "UserId", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "RoleDescription", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "GeoDescription", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "GeoCode", c => c.String(maxLength: 100));
            AlterColumn("dbo.Roles", "Description", c => c.String(maxLength: 100));
           
        }
        
        public override void Down()
        {
            
            AlterColumn("dbo.Roles", "Description", c => c.String());
            AlterColumn("dbo.Users", "GeoCode", c => c.String());
            AlterColumn("dbo.Users", "GeoDescription", c => c.String());
            AlterColumn("dbo.Users", "RoleDescription", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserId", c => c.String(nullable: false, maxLength: 128));
         
        }
    }
}

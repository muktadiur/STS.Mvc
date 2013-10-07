namespace STS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultNavnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "DefaultNav", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "DefaultNav", c => c.Int(nullable: false));
        }
    }
}

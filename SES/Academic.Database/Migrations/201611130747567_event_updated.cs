namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class event_updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "PostedById", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "PostToPublic", c => c.Boolean(nullable: false));
            AddForeignKey("dbo.Event", "PostedById", "dbo.Users", "Id");
            CreateIndex("dbo.Event", "PostedById");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Event", new[] { "PostedById" });
            DropForeignKey("dbo.Event", "PostedById", "dbo.Users");
            DropColumn("dbo.Event", "PostToPublic");
            DropColumn("dbo.Event", "PostedById");
        }
    }
}

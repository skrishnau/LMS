namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class column_added_discussion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ForumDiscussion", "Pinned", c => c.Boolean(nullable: false));
            AddColumn("dbo.ForumDiscussion", "SubscribeToDiscussion", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ForumDiscussion", "SubscribeToDiscussion");
            DropColumn("dbo.ForumDiscussion", "Pinned");
        }
    }
}

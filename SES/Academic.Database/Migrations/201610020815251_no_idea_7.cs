namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no_idea_7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ForumDiscussion", "LastPostById", c => c.Int(nullable: false));
            AddColumn("dbo.ForumDiscussion", "LastPostDate", c => c.DateTime(nullable: false));
            AddForeignKey("dbo.ForumDiscussion", "LastPostById", "dbo.Users", "Id");
            CreateIndex("dbo.ForumDiscussion", "LastPostById");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ForumDiscussion", new[] { "LastPostById" });
            DropForeignKey("dbo.ForumDiscussion", "LastPostById", "dbo.Users");
            DropColumn("dbo.ForumDiscussion", "LastPostDate");
            DropColumn("dbo.ForumDiscussion", "LastPostById");
        }
    }
}

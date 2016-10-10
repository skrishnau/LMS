namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forum_added_modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ForumDiscussion", "LastUpdateDate", c => c.DateTime());
            AddColumn("dbo.ForumDiscussion", "UpdatedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ForumDiscussion", "UpdatedBy");
            DropColumn("dbo.ForumDiscussion", "LastUpdateDate");
        }
    }
}

namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forum_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ForumActivity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DisplayDescriptionOnCoursePage = c.Boolean(nullable: false),
                        ForumType = c.Byte(nullable: false),
                        MaximumAttachmentSize = c.Int(nullable: false),
                        MaximumNoOfAttachments = c.Int(nullable: false),
                        DisplayWordCount = c.Boolean(nullable: false),
                        SubscriptionMode = c.Byte(nullable: false),
                        ReadTracking = c.Boolean(nullable: false),
                        TimePeriodForBlocking = c.Byte(nullable: false),
                        PostThresholdForBlocking = c.Int(nullable: false),
                        PostThresholdForWarning = c.Int(nullable: false),
                        RestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.ForumDiscussion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Message = c.String(),
                        ParentDiscussionId = c.Int(nullable: false),
                        ForumActivityId = c.Int(nullable: false),
                        PostedById = c.Int(nullable: false),
                        PostedDate = c.DateTime(nullable: false),
                        Closed = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForumDiscussion", t => t.ParentDiscussionId)
                .ForeignKey("dbo.ForumActivity", t => t.ForumActivityId)
                .ForeignKey("dbo.Users", t => t.PostedById)
                .Index(t => t.ParentDiscussionId)
                .Index(t => t.ForumActivityId)
                .Index(t => t.PostedById);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ForumDiscussion", new[] { "PostedById" });
            DropIndex("dbo.ForumDiscussion", new[] { "ForumActivityId" });
            DropIndex("dbo.ForumDiscussion", new[] { "ParentDiscussionId" });
            DropIndex("dbo.ForumActivity", new[] { "RestrictionId" });
            DropForeignKey("dbo.ForumDiscussion", "PostedById", "dbo.Users");
            DropForeignKey("dbo.ForumDiscussion", "ForumActivityId", "dbo.ForumActivity");
            DropForeignKey("dbo.ForumDiscussion", "ParentDiscussionId", "dbo.ForumDiscussion");
            DropForeignKey("dbo.ForumActivity", "RestrictionId", "dbo.Restriction");
            DropTable("dbo.ForumDiscussion");
            DropTable("dbo.ForumActivity");
        }
    }
}

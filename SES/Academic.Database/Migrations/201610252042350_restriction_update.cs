namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restriction_update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assignment", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.ChoiceActivity", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.ForumActivity", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.BookResource", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.UrlResource", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.FileResource", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.PageResource", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.LabelResource", "RestrictionId", "dbo.Restriction");
            DropIndex("dbo.Assignment", new[] { "RestrictionId" });
            DropIndex("dbo.ChoiceActivity", new[] { "RestrictionId" });
            DropIndex("dbo.ForumActivity", new[] { "RestrictionId" });
            DropIndex("dbo.BookResource", new[] { "RestrictionId" });
            DropIndex("dbo.UrlResource", new[] { "RestrictionId" });
            DropIndex("dbo.FileResource", new[] { "RestrictionId" });
            DropIndex("dbo.PageResource", new[] { "RestrictionId" });
            DropIndex("dbo.LabelResource", new[] { "RestrictionId" });
            AddColumn("dbo.ActivityResource", "RestrictionId", c => c.Int());
            AddColumn("dbo.UserProfileRestriction", "RestrictionId", c => c.Int(nullable: false));
            AddForeignKey("dbo.ActivityResource", "RestrictionId", "dbo.Restriction", "Id");
            AddForeignKey("dbo.UserProfileRestriction", "RestrictionId", "dbo.Restriction", "Id");
            CreateIndex("dbo.ActivityResource", "RestrictionId");
            CreateIndex("dbo.UserProfileRestriction", "RestrictionId");
            DropColumn("dbo.Assignment", "RestrictionId");
            DropColumn("dbo.ChoiceActivity", "RestrictionId");
            DropColumn("dbo.ForumActivity", "RestrictionId");
            DropColumn("dbo.BookResource", "RestrictionId");
            DropColumn("dbo.UrlResource", "RestrictionId");
            DropColumn("dbo.FileResource", "RestrictionId");
            DropColumn("dbo.PageResource", "RestrictionId");
            DropColumn("dbo.LabelResource", "RestrictionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LabelResource", "RestrictionId", c => c.Int(nullable: false));
            AddColumn("dbo.PageResource", "RestrictionId", c => c.Int(nullable: false));
            AddColumn("dbo.FileResource", "RestrictionId", c => c.Int(nullable: false));
            AddColumn("dbo.UrlResource", "RestrictionId", c => c.Int(nullable: false));
            AddColumn("dbo.BookResource", "RestrictionId", c => c.Int(nullable: false));
            AddColumn("dbo.ForumActivity", "RestrictionId", c => c.Int(nullable: false));
            AddColumn("dbo.ChoiceActivity", "RestrictionId", c => c.Int(nullable: false));
            AddColumn("dbo.Assignment", "RestrictionId", c => c.Int());
            DropIndex("dbo.UserProfileRestriction", new[] { "RestrictionId" });
            DropIndex("dbo.ActivityResource", new[] { "RestrictionId" });
            DropForeignKey("dbo.UserProfileRestriction", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.ActivityResource", "RestrictionId", "dbo.Restriction");
            DropColumn("dbo.UserProfileRestriction", "RestrictionId");
            DropColumn("dbo.ActivityResource", "RestrictionId");
            CreateIndex("dbo.LabelResource", "RestrictionId");
            CreateIndex("dbo.PageResource", "RestrictionId");
            CreateIndex("dbo.FileResource", "RestrictionId");
            CreateIndex("dbo.UrlResource", "RestrictionId");
            CreateIndex("dbo.BookResource", "RestrictionId");
            CreateIndex("dbo.ForumActivity", "RestrictionId");
            CreateIndex("dbo.ChoiceActivity", "RestrictionId");
            CreateIndex("dbo.Assignment", "RestrictionId");
            AddForeignKey("dbo.LabelResource", "RestrictionId", "dbo.Restriction", "Id");
            AddForeignKey("dbo.PageResource", "RestrictionId", "dbo.Restriction", "Id");
            AddForeignKey("dbo.FileResource", "RestrictionId", "dbo.Restriction", "Id");
            AddForeignKey("dbo.UrlResource", "RestrictionId", "dbo.Restriction", "Id");
            AddForeignKey("dbo.BookResource", "RestrictionId", "dbo.Restriction", "Id");
            AddForeignKey("dbo.ForumActivity", "RestrictionId", "dbo.Restriction", "Id");
            AddForeignKey("dbo.ChoiceActivity", "RestrictionId", "dbo.Restriction", "Id");
            AddForeignKey("dbo.Assignment", "RestrictionId", "dbo.Restriction", "Id");
        }
    }
}

namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class act_res_id_deleted_to_all : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assignment", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.ChoiceActivity", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.ForumActivity", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.BookResource", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.UrlResource", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.FileResource", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.PageResource", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.LabelResource", "ActivityResourceId", "dbo.ActivityResource");
            DropIndex("dbo.Assignment", new[] { "ActivityResourceId" });
            DropIndex("dbo.ChoiceActivity", new[] { "ActivityResourceId" });
            DropIndex("dbo.ForumActivity", new[] { "ActivityResourceId" });
            DropIndex("dbo.BookResource", new[] { "ActivityResourceId" });
            DropIndex("dbo.UrlResource", new[] { "ActivityResourceId" });
            DropIndex("dbo.FileResource", new[] { "ActivityResourceId" });
            DropIndex("dbo.PageResource", new[] { "ActivityResourceId" });
            DropIndex("dbo.LabelResource", new[] { "ActivityResourceId" });
            DropColumn("dbo.Assignment", "ActivityResourceId");
            DropColumn("dbo.ChoiceActivity", "ActivityResourceId");
            DropColumn("dbo.ForumActivity", "ActivityResourceId");
            DropColumn("dbo.BookResource", "ActivityResourceId");
            DropColumn("dbo.UrlResource", "ActivityResourceId");
            DropColumn("dbo.FileResource", "ActivityResourceId");
            DropColumn("dbo.PageResource", "ActivityResourceId");
            DropColumn("dbo.LabelResource", "ActivityResourceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LabelResource", "ActivityResourceId", c => c.Int(nullable: false));
            AddColumn("dbo.PageResource", "ActivityResourceId", c => c.Int(nullable: false));
            AddColumn("dbo.FileResource", "ActivityResourceId", c => c.Int(nullable: false));
            AddColumn("dbo.UrlResource", "ActivityResourceId", c => c.Int(nullable: false));
            AddColumn("dbo.BookResource", "ActivityResourceId", c => c.Int(nullable: false));
            AddColumn("dbo.ForumActivity", "ActivityResourceId", c => c.Int(nullable: false));
            AddColumn("dbo.ChoiceActivity", "ActivityResourceId", c => c.Int(nullable: false));
            AddColumn("dbo.Assignment", "ActivityResourceId", c => c.Int(nullable: false));
            CreateIndex("dbo.LabelResource", "ActivityResourceId");
            CreateIndex("dbo.PageResource", "ActivityResourceId");
            CreateIndex("dbo.FileResource", "ActivityResourceId");
            CreateIndex("dbo.UrlResource", "ActivityResourceId");
            CreateIndex("dbo.BookResource", "ActivityResourceId");
            CreateIndex("dbo.ForumActivity", "ActivityResourceId");
            CreateIndex("dbo.ChoiceActivity", "ActivityResourceId");
            CreateIndex("dbo.Assignment", "ActivityResourceId");
            AddForeignKey("dbo.LabelResource", "ActivityResourceId", "dbo.ActivityResource", "Id");
            AddForeignKey("dbo.PageResource", "ActivityResourceId", "dbo.ActivityResource", "Id");
            AddForeignKey("dbo.FileResource", "ActivityResourceId", "dbo.ActivityResource", "Id");
            AddForeignKey("dbo.UrlResource", "ActivityResourceId", "dbo.ActivityResource", "Id");
            AddForeignKey("dbo.BookResource", "ActivityResourceId", "dbo.ActivityResource", "Id");
            AddForeignKey("dbo.ForumActivity", "ActivityResourceId", "dbo.ActivityResource", "Id");
            AddForeignKey("dbo.ChoiceActivity", "ActivityResourceId", "dbo.ActivityResource", "Id");
            AddForeignKey("dbo.Assignment", "ActivityResourceId", "dbo.ActivityResource", "Id");
        }
    }
}

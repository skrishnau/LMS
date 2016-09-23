namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book_created : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DisplayDescriptionOnCourePage = c.Boolean(nullable: false),
                        ChapterFormatting = c.Byte(nullable: false),
                        StyleOfNavigation = c.Byte(nullable: false),
                        CustomTitles = c.Boolean(nullable: false),
                        RestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.BookChapter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Position = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookResource", t => t.BookId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BookChapter", new[] { "BookId" });
            DropIndex("dbo.BookResource", new[] { "RestrictionId" });
            DropForeignKey("dbo.BookChapter", "BookId", "dbo.BookResource");
            DropForeignKey("dbo.BookResource", "RestrictionId", "dbo.Restriction");
            DropTable("dbo.BookChapter");
            DropTable("dbo.BookResource");
        }
    }
}

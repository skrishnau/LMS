namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staticvalues_moved_to_Dbhelper : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UrlResource", "Name", c => c.String());
            AddColumn("dbo.UrlResource", "DisplayDescriptionOnPage", c => c.Boolean(nullable: false));
            AddColumn("dbo.UrlResource", "Display", c => c.Byte(nullable: false));
            AddColumn("dbo.UrlResource", "PopupWidthInPixel", c => c.Int(nullable: false));
            AddColumn("dbo.UrlResource", "PopupHeightInPixel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UrlResource", "PopupHeightInPixel");
            DropColumn("dbo.UrlResource", "PopupWidthInPixel");
            DropColumn("dbo.UrlResource", "Display");
            DropColumn("dbo.UrlResource", "DisplayDescriptionOnPage");
            DropColumn("dbo.UrlResource", "Name");
        }
    }
}

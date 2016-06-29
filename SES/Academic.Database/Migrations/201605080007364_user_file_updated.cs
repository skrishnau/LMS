namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_file_updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResourceFile", "FileSizeInBytes", c => c.Long(nullable: false));
            AddColumn("dbo.ResourceFile", "Void", c => c.Boolean(nullable: false));
            AddColumn("dbo.Photo", "FileSizeInBytes", c => c.Long(nullable: false));
            AddColumn("dbo.Photo", "Void", c => c.Boolean(nullable: false));
            AddColumn("dbo.StudentFile", "FileSizeInBytes", c => c.Long(nullable: false));
            AddColumn("dbo.StudentFile", "Void", c => c.Boolean(nullable: false));
            DropColumn("dbo.ResourceFile", "IsDeleted");
            DropColumn("dbo.Photo", "IsDeleted");
            DropColumn("dbo.StudentFile", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentFile", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Photo", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ResourceFile", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.StudentFile", "Void");
            DropColumn("dbo.StudentFile", "FileSizeInBytes");
            DropColumn("dbo.Photo", "Void");
            DropColumn("dbo.Photo", "FileSizeInBytes");
            DropColumn("dbo.ResourceFile", "Void");
            DropColumn("dbo.ResourceFile", "FileSizeInBytes");
        }
    }
}

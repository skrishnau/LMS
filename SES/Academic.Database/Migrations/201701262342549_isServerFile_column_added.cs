namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isServerFile_column_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserFile", "IsServerFile", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserFile", "IsFolder", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserFile", "FolderId", c => c.Int());
            AddForeignKey("dbo.UserFile", "FolderId", "dbo.UserFile", "Id");
            CreateIndex("dbo.UserFile", "FolderId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserFile", new[] { "FolderId" });
            DropForeignKey("dbo.UserFile", "FolderId", "dbo.UserFile");
            DropColumn("dbo.UserFile", "FolderId");
            DropColumn("dbo.UserFile", "IsFolder");
            DropColumn("dbo.UserFile", "IsServerFile");
        }
    }
}

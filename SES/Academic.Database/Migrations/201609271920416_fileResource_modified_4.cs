namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fileResource_modified_4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileResourceFiles", "SubFileId", c => c.Int(nullable: false));
            AddForeignKey("dbo.FileResourceFiles", "SubFileId", "dbo.UserFile", "Id");
            CreateIndex("dbo.FileResourceFiles", "SubFileId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FileResourceFiles", new[] { "SubFileId" });
            DropForeignKey("dbo.FileResourceFiles", "SubFileId", "dbo.UserFile");
            DropColumn("dbo.FileResourceFiles", "SubFileId");
        }
    }
}

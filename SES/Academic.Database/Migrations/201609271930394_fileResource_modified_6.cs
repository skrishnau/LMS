namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fileResource_modified_6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserFile", "SubjectId", c => c.Int());
            AddForeignKey("dbo.UserFile", "SubjectId", "dbo.Subject", "Id");
            CreateIndex("dbo.UserFile", "SubjectId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserFile", new[] { "SubjectId" });
            DropForeignKey("dbo.UserFile", "SubjectId", "dbo.Subject");
            DropColumn("dbo.UserFile", "SubjectId");
        }
    }
}

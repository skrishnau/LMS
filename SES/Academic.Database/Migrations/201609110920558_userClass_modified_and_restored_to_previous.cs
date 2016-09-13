namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userClass_modified_and_restored_to_previous : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserClass", "StudentBatchId", "dbo.StudentBatch");
            DropIndex("dbo.UserClass", new[] { "StudentBatchId" });
            DropColumn("dbo.UserClass", "IsRegular");
            DropColumn("dbo.UserClass", "StudentBatchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserClass", "StudentBatchId", c => c.Int());
            AddColumn("dbo.UserClass", "IsRegular", c => c.Boolean());
            CreateIndex("dbo.UserClass", "StudentBatchId");
            AddForeignKey("dbo.UserClass", "StudentBatchId", "dbo.StudentBatch", "Id");
        }
    }
}

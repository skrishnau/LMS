namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class act_view1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActivityResourceView", "ActivityResource_Id", "dbo.ActivityResource");
            DropIndex("dbo.ActivityResourceView", new[] { "ActivityResource_Id" });
            DropColumn("dbo.ActivityResourceView", "ActivityResource_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActivityResourceView", "ActivityResource_Id", c => c.Int());
            CreateIndex("dbo.ActivityResourceView", "ActivityResource_Id");
            AddForeignKey("dbo.ActivityResourceView", "ActivityResource_Id", "dbo.ActivityResource", "Id");
        }
    }
}

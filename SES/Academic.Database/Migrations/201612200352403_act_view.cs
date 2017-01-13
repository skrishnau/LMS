namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class act_view : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ActivityResourceView", "UserId", "dbo.Users");
            DropForeignKey("dbo.ActivityResourceView", "ActivityResourceId", "dbo.ActivityResource");
            DropIndex("dbo.ActivityResourceView", new[] { "UserId" });
            DropIndex("dbo.ActivityResourceView", new[] { "ActivityResourceId" });
            AddColumn("dbo.ActivityResourceView", "UserClassId", c => c.Int(nullable: false));
            AddColumn("dbo.ActivityResourceView", "ActivityClassId", c => c.Int(nullable: false));
            AddColumn("dbo.ActivityResourceView", "ActivityResource_Id", c => c.Int());
            AddForeignKey("dbo.ActivityResourceView", "UserClassId", "dbo.UserClass", "Id");
            AddForeignKey("dbo.ActivityResourceView", "ActivityClassId", "dbo.ActivityClass", "Id");
            AddForeignKey("dbo.ActivityResourceView", "ActivityResource_Id", "dbo.ActivityResource", "Id");
            CreateIndex("dbo.ActivityResourceView", "UserClassId");
            CreateIndex("dbo.ActivityResourceView", "ActivityClassId");
            CreateIndex("dbo.ActivityResourceView", "ActivityResource_Id");
            DropColumn("dbo.ActivityResourceView", "UserId");
            DropColumn("dbo.ActivityResourceView", "ActivityResourceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ActivityResourceView", "ActivityResourceId", c => c.Int(nullable: false));
            AddColumn("dbo.ActivityResourceView", "UserId", c => c.Int(nullable: false));
            DropIndex("dbo.ActivityResourceView", new[] { "ActivityResource_Id" });
            DropIndex("dbo.ActivityResourceView", new[] { "ActivityClassId" });
            DropIndex("dbo.ActivityResourceView", new[] { "UserClassId" });
            DropForeignKey("dbo.ActivityResourceView", "ActivityResource_Id", "dbo.ActivityResource");
            DropForeignKey("dbo.ActivityResourceView", "ActivityClassId", "dbo.ActivityClass");
            DropForeignKey("dbo.ActivityResourceView", "UserClassId", "dbo.UserClass");
            DropColumn("dbo.ActivityResourceView", "ActivityResource_Id");
            DropColumn("dbo.ActivityResourceView", "ActivityClassId");
            DropColumn("dbo.ActivityResourceView", "UserClassId");
            CreateIndex("dbo.ActivityResourceView", "ActivityResourceId");
            CreateIndex("dbo.ActivityResourceView", "UserId");
            AddForeignKey("dbo.ActivityResourceView", "ActivityResourceId", "dbo.ActivityResource", "Id");
            AddForeignKey("dbo.ActivityResourceView", "UserId", "dbo.Users", "Id");
        }
    }
}

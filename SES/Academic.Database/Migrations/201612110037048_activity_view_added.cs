namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activity_view_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityResourceView",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserClassId = c.Int(nullable: false),
                        ActivityResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserClassId)
                .ForeignKey("dbo.ActivityResource", t => t.ActivityResourceId)
                .Index(t => t.UserClassId)
                .Index(t => t.ActivityResourceId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ActivityResourceView", new[] { "ActivityResourceId" });
            DropIndex("dbo.ActivityResourceView", new[] { "UserClassId" });
            DropForeignKey("dbo.ActivityResourceView", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.ActivityResourceView", "UserClassId", "dbo.Users");
            DropTable("dbo.ActivityResourceView");
        }
    }
}

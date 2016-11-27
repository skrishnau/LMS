namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rand5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityCompletionRestriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityId = c.Int(nullable: false),
                        Constraint = c.String(),
                        RestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityResource", t => t.ActivityId)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.ActivityId)
                .Index(t => t.RestrictionId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ActivityCompletionRestriction", new[] { "RestrictionId" });
            DropIndex("dbo.ActivityCompletionRestriction", new[] { "ActivityId" });
            DropForeignKey("dbo.ActivityCompletionRestriction", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.ActivityCompletionRestriction", "ActivityId", "dbo.ActivityResource");
            DropTable("dbo.ActivityCompletionRestriction");
        }
    }
}

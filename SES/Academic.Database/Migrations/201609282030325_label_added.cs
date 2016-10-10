namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class label_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LabelResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        RestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.LabelResource", new[] { "RestrictionId" });
            DropForeignKey("dbo.LabelResource", "RestrictionId", "dbo.Restriction");
            DropTable("dbo.LabelResource");
        }
    }
}

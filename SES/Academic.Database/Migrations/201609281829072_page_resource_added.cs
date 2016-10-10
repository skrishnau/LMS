namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class page_resource_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PageContent = c.String(),
                        Description = c.String(),
                        DisplayDescriptionOnPage = c.Boolean(nullable: false),
                        RestrictionId = c.Int(nullable: false),
                        DisplayPageName = c.Boolean(nullable: false),
                        DisplayPageDescription = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PageResource", new[] { "RestrictionId" });
            DropForeignKey("dbo.PageResource", "RestrictionId", "dbo.Restriction");
            DropTable("dbo.PageResource");
        }
    }
}

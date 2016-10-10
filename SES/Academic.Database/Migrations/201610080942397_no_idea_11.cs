namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no_idea_11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChoiceActivity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DisplayDescriptionOnCoursePage = c.Boolean(nullable: false),
                        DisplayModeForOptions = c.Boolean(nullable: false),
                        AllowChoiceTobeUpdated = c.Boolean(nullable: false),
                        AllowMoreThanOneChoiceToBeSelected = c.Boolean(nullable: false),
                        LimitTheNumberOfResponsesAllowed = c.Boolean(nullable: false),
                        RestrictTimePeriod = c.Boolean(nullable: false),
                        OpenDate = c.DateTime(),
                        UntilDate = c.DateTime(),
                        ShowPreview = c.Boolean(nullable: false),
                        PublishResults = c.Byte(nullable: false),
                        PrivacyOfResults = c.Boolean(nullable: false),
                        ShowColumnForUnAnswered = c.Boolean(nullable: false),
                        IncludeResponsesFromInactiveUsers = c.Boolean(nullable: false),
                        RestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.ChoiceOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Option = c.String(),
                        Limit = c.Long(),
                        ChoiceActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChoiceActivity", t => t.ChoiceActivityId)
                .Index(t => t.ChoiceActivityId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ChoiceOptions", new[] { "ChoiceActivityId" });
            DropIndex("dbo.ChoiceActivity", new[] { "RestrictionId" });
            DropForeignKey("dbo.ChoiceOptions", "ChoiceActivityId", "dbo.ChoiceActivity");
            DropForeignKey("dbo.ChoiceActivity", "RestrictionId", "dbo.Restriction");
            DropTable("dbo.ChoiceOptions");
            DropTable("dbo.ChoiceActivity");
        }
    }
}

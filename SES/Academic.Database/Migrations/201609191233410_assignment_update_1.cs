namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignment_update_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DispalyDescriptionOnPage = c.Boolean(),
                        SubmissionFrom = c.DateTime(),
                        DueDate = c.DateTime(),
                        CutOffDate = c.DateTime(),
                        FileSubmission = c.Boolean(nullable: false),
                        MaximumNoOfUploadedFiles = c.Int(),
                        MaximumSubmissionSize = c.Int(),
                        OnlineText = c.Boolean(nullable: false),
                        WordLimit = c.Int(),
                        GradeTypeId = c.Int(nullable: false),
                        MaximumGrade = c.String(),
                        GradeToPass = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        RestrictionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GradeType", t => t.GradeTypeId)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.GradeTypeId)
                .Index(t => t.RestrictionId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Assignment", new[] { "RestrictionId" });
            DropIndex("dbo.Assignment", new[] { "GradeTypeId" });
            DropForeignKey("dbo.Assignment", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.Assignment", "GradeTypeId", "dbo.GradeType");
            DropTable("dbo.Assignment");
        }
    }
}

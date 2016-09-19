namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignment_temp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Restriction", "SubjectSection_Id", "dbo.SubjectSection");
            DropForeignKey("dbo.SubjectActivityAndResource", "SubjectSectionId", "dbo.SubjectSection");
            DropForeignKey("dbo.Assignment", "SectionId", "dbo.SubjectSection");
            DropForeignKey("dbo.Assignment", "Resource_Id", "dbo.Resource");
            DropForeignKey("dbo.AssignmentAnswer", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.AssignmentAnswer", "StudentId", "dbo.Student");
            DropForeignKey("dbo.AssignmentAnswerFile", "AssignmentAnswerId", "dbo.AssignmentAnswer");
            DropIndex("dbo.Restriction", new[] { "SubjectSection_Id" });
            DropIndex("dbo.SubjectActivityAndResource", new[] { "SubjectSectionId" });
            DropIndex("dbo.Assignment", new[] { "SectionId" });
            DropIndex("dbo.Assignment", new[] { "Resource_Id" });
            DropIndex("dbo.AssignmentAnswer", new[] { "AssignmentId" });
            DropIndex("dbo.AssignmentAnswer", new[] { "StudentId" });
            DropIndex("dbo.AssignmentAnswerFile", new[] { "AssignmentAnswerId" });
            DropColumn("dbo.Restriction", "SubjectSection_Id");
            DropTable("dbo.SubjectActivityAndResource");
            DropTable("dbo.Assignment");
            DropTable("dbo.AssignmentAnswer");
            DropTable("dbo.AssignmentAnswerFile");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AssignmentAnswerFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignmentAnswerId = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssignmentAnswer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignmentId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        StudentGroupId = c.Int(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SectionId = c.Int(nullable: false),
                        DispalyDescriptionOnPage = c.Boolean(),
                        SubmissionFrom = c.DateTime(),
                        DueDate = c.DateTime(),
                        CutOffDate = c.DateTime(),
                        SubmissionType = c.String(),
                        WordLimit = c.Int(),
                        MaximumNoOfUploadedFiles = c.Int(),
                        MaximumSubmissionSize = c.Int(),
                        GradeType = c.String(),
                        MaximumGrade = c.String(),
                        GradeToPass = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        Resource_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectActivityAndResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ShowDesctiptionOnPage = c.Boolean(nullable: false),
                        Void = c.Boolean(),
                        Type = c.String(),
                        SubjectSectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Restriction", "SubjectSection_Id", c => c.Int());
            CreateIndex("dbo.AssignmentAnswerFile", "AssignmentAnswerId");
            CreateIndex("dbo.AssignmentAnswer", "StudentId");
            CreateIndex("dbo.AssignmentAnswer", "AssignmentId");
            CreateIndex("dbo.Assignment", "Resource_Id");
            CreateIndex("dbo.Assignment", "SectionId");
            CreateIndex("dbo.SubjectActivityAndResource", "SubjectSectionId");
            CreateIndex("dbo.Restriction", "SubjectSection_Id");
            AddForeignKey("dbo.AssignmentAnswerFile", "AssignmentAnswerId", "dbo.AssignmentAnswer", "Id");
            AddForeignKey("dbo.AssignmentAnswer", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.AssignmentAnswer", "AssignmentId", "dbo.Assignment", "Id");
            AddForeignKey("dbo.Assignment", "Resource_Id", "dbo.Resource", "Id");
            AddForeignKey("dbo.Assignment", "SectionId", "dbo.SubjectSection", "Id");
            AddForeignKey("dbo.SubjectActivityAndResource", "SubjectSectionId", "dbo.SubjectSection", "Id");
            AddForeignKey("dbo.Restriction", "SubjectSection_Id", "dbo.SubjectSection", "Id");
        }
    }
}

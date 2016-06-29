namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignment_added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assignment", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Task", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.ResourceFileResource", "ResourceFile_Id", "dbo.ResourceFile");
            DropForeignKey("dbo.ResourceFileResource", "Resource_Id", "dbo.Resource");
            DropForeignKey("dbo.ResourceAssignment", "Resource_Id", "dbo.Resource");
            DropForeignKey("dbo.ResourceAssignment", "Assignment_Id", "dbo.Assignment");
            DropIndex("dbo.Assignment", new[] { "SubjectId" });
            DropIndex("dbo.Task", new[] { "AssignmentId" });
            DropIndex("dbo.ResourceFileResource", new[] { "ResourceFile_Id" });
            DropIndex("dbo.ResourceFileResource", new[] { "Resource_Id" });
            DropIndex("dbo.ResourceAssignment", new[] { "Resource_Id" });
            DropIndex("dbo.ResourceAssignment", new[] { "Assignment_Id" });
            CreateTable(
                "dbo.ResourceResourceFile",
                c => new
                    {
                        Resource_Id = c.Int(nullable: false),
                        ResourceFile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Resource_Id, t.ResourceFile_Id })
                .ForeignKey("dbo.Resource", t => t.Resource_Id, cascadeDelete: true)
                .ForeignKey("dbo.ResourceFile", t => t.ResourceFile_Id, cascadeDelete: true)
                .Index(t => t.Resource_Id)
                .Index(t => t.ResourceFile_Id);
            
            AddColumn("dbo.Assignment", "Description", c => c.String());
            AddColumn("dbo.Assignment", "SectionId", c => c.Int(nullable: false));
            AddColumn("dbo.Assignment", "DispalyDescriptionOnPage", c => c.Boolean());
            AddColumn("dbo.Assignment", "SubmissionFrom", c => c.DateTime());
            AddColumn("dbo.Assignment", "DueDate", c => c.DateTime());
            AddColumn("dbo.Assignment", "CutOffDate", c => c.DateTime());
            AddColumn("dbo.Assignment", "SubmissionType", c => c.String());
            AddColumn("dbo.Assignment", "WordLimit", c => c.Int(nullable: false));
            AddColumn("dbo.Assignment", "MaximumNoOfUploadedFiles", c => c.Int(nullable: false));
            AddColumn("dbo.Assignment", "MaximumSubmissionSize", c => c.Int(nullable: false));
            AddColumn("dbo.Assignment", "GradeType", c => c.String());
            AddColumn("dbo.Assignment", "MaximumGrade", c => c.String());
            AddColumn("dbo.Assignment", "GradeToPass", c => c.String());
            AddColumn("dbo.Assignment", "Resource_Id", c => c.Int());
            AddColumn("dbo.AssignmentAnswer", "StudentGroupId", c => c.Int());
            AlterColumn("dbo.Assignment", "ModifiedBy", c => c.Int(nullable: false));
            AddForeignKey("dbo.Assignment", "SectionId", "dbo.SubjectSection", "Id");
            AddForeignKey("dbo.Assignment", "Resource_Id", "dbo.Resource", "Id");
            CreateIndex("dbo.Assignment", "SectionId");
            CreateIndex("dbo.Assignment", "Resource_Id");
            DropColumn("dbo.Assignment", "Remarks");
            DropColumn("dbo.Assignment", "SubjectId");
            DropColumn("dbo.AssignmentAnswer", "Remarks");
            DropTable("dbo.Task");
            DropTable("dbo.ResourceFileResource");
            DropTable("dbo.ResourceAssignment");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ResourceAssignment",
                c => new
                    {
                        Resource_Id = c.Int(nullable: false),
                        Assignment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Resource_Id, t.Assignment_Id });
            
            CreateTable(
                "dbo.ResourceFileResource",
                c => new
                    {
                        ResourceFile_Id = c.Int(nullable: false),
                        Resource_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResourceFile_Id, t.Resource_Id });
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Question = c.String(),
                        Hint = c.String(),
                        Solution = c.String(),
                        AssignmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AssignmentAnswer", "Remarks", c => c.String());
            AddColumn("dbo.Assignment", "SubjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Assignment", "Remarks", c => c.String());
            DropIndex("dbo.ResourceResourceFile", new[] { "ResourceFile_Id" });
            DropIndex("dbo.ResourceResourceFile", new[] { "Resource_Id" });
            DropIndex("dbo.Assignment", new[] { "Resource_Id" });
            DropIndex("dbo.Assignment", new[] { "SectionId" });
            DropForeignKey("dbo.ResourceResourceFile", "ResourceFile_Id", "dbo.ResourceFile");
            DropForeignKey("dbo.ResourceResourceFile", "Resource_Id", "dbo.Resource");
            DropForeignKey("dbo.Assignment", "Resource_Id", "dbo.Resource");
            DropForeignKey("dbo.Assignment", "SectionId", "dbo.SubjectSection");
            AlterColumn("dbo.Assignment", "ModifiedBy", c => c.Int());
            DropColumn("dbo.AssignmentAnswer", "StudentGroupId");
            DropColumn("dbo.Assignment", "Resource_Id");
            DropColumn("dbo.Assignment", "GradeToPass");
            DropColumn("dbo.Assignment", "MaximumGrade");
            DropColumn("dbo.Assignment", "GradeType");
            DropColumn("dbo.Assignment", "MaximumSubmissionSize");
            DropColumn("dbo.Assignment", "MaximumNoOfUploadedFiles");
            DropColumn("dbo.Assignment", "WordLimit");
            DropColumn("dbo.Assignment", "SubmissionType");
            DropColumn("dbo.Assignment", "CutOffDate");
            DropColumn("dbo.Assignment", "DueDate");
            DropColumn("dbo.Assignment", "SubmissionFrom");
            DropColumn("dbo.Assignment", "DispalyDescriptionOnPage");
            DropColumn("dbo.Assignment", "SectionId");
            DropColumn("dbo.Assignment", "Description");
            DropTable("dbo.ResourceResourceFile");
            CreateIndex("dbo.ResourceAssignment", "Assignment_Id");
            CreateIndex("dbo.ResourceAssignment", "Resource_Id");
            CreateIndex("dbo.ResourceFileResource", "Resource_Id");
            CreateIndex("dbo.ResourceFileResource", "ResourceFile_Id");
            CreateIndex("dbo.Task", "AssignmentId");
            CreateIndex("dbo.Assignment", "SubjectId");
            AddForeignKey("dbo.ResourceAssignment", "Assignment_Id", "dbo.Assignment", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ResourceAssignment", "Resource_Id", "dbo.Resource", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ResourceFileResource", "Resource_Id", "dbo.Resource", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ResourceFileResource", "ResourceFile_Id", "dbo.ResourceFile", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Task", "AssignmentId", "dbo.Assignment", "Id");
            AddForeignKey("dbo.Assignment", "SubjectId", "dbo.Subject", "Id");
        }
    }
}

namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activity_class_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignmentSubmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubmissionText = c.String(),
                        SubmittedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        UserClassId = c.Int(nullable: false),
                        AssignmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserClass", t => t.UserClassId)
                .ForeignKey("dbo.Assignment", t => t.AssignmentId)
                .Index(t => t.UserClassId)
                .Index(t => t.AssignmentId);
            
            CreateTable(
                "dbo.AssignmentSubmissionFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignmentSubmissionsId = c.Int(nullable: false),
                        UserFileId = c.Int(nullable: false),
                        FileSubmittedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssignmentSubmissions", t => t.AssignmentSubmissionsId)
                .ForeignKey("dbo.UserFile", t => t.UserFileId)
                .Index(t => t.AssignmentSubmissionsId)
                .Index(t => t.UserFileId);
            
            CreateTable(
                "dbo.ActivityClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityResourceId = c.Int(nullable: false),
                        SubjectClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityResource", t => t.ActivityResourceId)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .Index(t => t.ActivityResourceId)
                .Index(t => t.SubjectClassId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ActivityClass", new[] { "SubjectClassId" });
            DropIndex("dbo.ActivityClass", new[] { "ActivityResourceId" });
            DropIndex("dbo.AssignmentSubmissionFiles", new[] { "UserFileId" });
            DropIndex("dbo.AssignmentSubmissionFiles", new[] { "AssignmentSubmissionsId" });
            DropIndex("dbo.AssignmentSubmissions", new[] { "AssignmentId" });
            DropIndex("dbo.AssignmentSubmissions", new[] { "UserClassId" });
            DropForeignKey("dbo.ActivityClass", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.ActivityClass", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.AssignmentSubmissionFiles", "UserFileId", "dbo.UserFile");
            DropForeignKey("dbo.AssignmentSubmissionFiles", "AssignmentSubmissionsId", "dbo.AssignmentSubmissions");
            DropForeignKey("dbo.AssignmentSubmissions", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.AssignmentSubmissions", "UserClassId", "dbo.UserClass");
            DropTable("dbo.ActivityClass");
            DropTable("dbo.AssignmentSubmissionFiles");
            DropTable("dbo.AssignmentSubmissions");
        }
    }
}

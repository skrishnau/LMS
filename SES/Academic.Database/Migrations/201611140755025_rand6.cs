namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rand6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExamStudent", "PostedById", "dbo.Users");
            DropForeignKey("dbo.ExamMarks", "SubjectExamId", "dbo.ExamSubject");
            DropForeignKey("dbo.ExamMarks", "StudentId", "dbo.Student");
            DropIndex("dbo.ExamStudent", new[] { "PostedById" });
            DropIndex("dbo.ExamMarks", new[] { "SubjectExamId" });
            DropIndex("dbo.ExamMarks", new[] { "StudentId" });
            DropColumn("dbo.ExamStudent", "PostedById");
            DropTable("dbo.ExamMarks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExamMarks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectExamId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Marks = c.Single(),
                        IsGradeSystem = c.Boolean(nullable: false),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ExamStudent", "PostedById", c => c.Int());
            CreateIndex("dbo.ExamMarks", "StudentId");
            CreateIndex("dbo.ExamMarks", "SubjectExamId");
            CreateIndex("dbo.ExamStudent", "PostedById");
            AddForeignKey("dbo.ExamMarks", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.ExamMarks", "SubjectExamId", "dbo.ExamSubject", "Id");
            AddForeignKey("dbo.ExamStudent", "PostedById", "dbo.Users", "Id");
        }
    }
}

namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exam_all_changes_remaining_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExamSubjectTeacher", "ExamSubjectId", "dbo.ExamSubject");
            DropForeignKey("dbo.ExamSubjectTeacher", "ExaminerId", "dbo.Users");
           // DropForeignKey("dbo.ExamSubjectTeacher", "TeacherClass_Id", "dbo.TeacherClass");
            DropIndex("dbo.ExamSubjectTeacher", new[] { "ExamSubjectId" });
            DropIndex("dbo.ExamSubjectTeacher", new[] { "ExaminerId" });
           // DropIndex("dbo.ExamSubjectTeacher", new[] { "TeacherClass_Id" });
            CreateTable(
                "dbo.ExamSubjectExaminer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamSubjectId = c.Int(nullable: false),
                        ExaminerId = c.Int(nullable: false),
                        TeacherClass_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamSubject", t => t.ExamSubjectId)
                .ForeignKey("dbo.Users", t => t.ExaminerId)
                .ForeignKey("dbo.TeacherClass", t => t.TeacherClass_Id)
                .Index(t => t.ExamSubjectId)
                .Index(t => t.ExaminerId)
                .Index(t => t.TeacherClass_Id);
            
            DropTable("dbo.ExamSubjectTeacher");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExamSubjectTeacher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamSubjectId = c.Int(nullable: false),
                        ExaminerId = c.Int(nullable: false),
                        TeacherClass_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.ExamSubjectExaminer", new[] { "TeacherClass_Id" });
            DropIndex("dbo.ExamSubjectExaminer", new[] { "ExaminerId" });
            DropIndex("dbo.ExamSubjectExaminer", new[] { "ExamSubjectId" });
            DropForeignKey("dbo.ExamSubjectExaminer", "TeacherClass_Id", "dbo.TeacherClass");
            DropForeignKey("dbo.ExamSubjectExaminer", "ExaminerId", "dbo.Users");
            DropForeignKey("dbo.ExamSubjectExaminer", "ExamSubjectId", "dbo.ExamSubject");
            DropTable("dbo.ExamSubjectExaminer");
            CreateIndex("dbo.ExamSubjectTeacher", "TeacherClass_Id");
            CreateIndex("dbo.ExamSubjectTeacher", "ExaminerId");
            CreateIndex("dbo.ExamSubjectTeacher", "ExamSubjectId");
            AddForeignKey("dbo.ExamSubjectTeacher", "TeacherClass_Id", "dbo.TeacherClass", "Id");
            AddForeignKey("dbo.ExamSubjectTeacher", "ExaminerId", "dbo.Users", "Id");
            AddForeignKey("dbo.ExamSubjectTeacher", "ExamSubjectId", "dbo.ExamSubject", "Id");
        }
    }
}

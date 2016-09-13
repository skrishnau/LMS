namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additional_changes_for_exam_overall : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExamStudent", "StudentClassId", "dbo.UserClass");
            DropForeignKey("dbo.ExamSubject", "ExamId", "dbo.Exam");
            DropIndex("dbo.ExamStudent", new[] { "StudentClassId" });
            DropIndex("dbo.ExamSubject", new[] { "ExamId" });
            RenameColumn(table: "dbo.ExamStudent", name: "StudentClassId", newName: "StudentClass_Id");
            CreateTable(
                "dbo.ExamOfClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        RunningClassId = c.Int(nullable: false),
                        SettingsUsedFromExam = c.Boolean(nullable: false),
                        IsPercent = c.Boolean(),
                        Weight = c.Single(),
                        FullMarks = c.Int(),
                        PassMarks = c.Int(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exam", t => t.ExamId)
                .ForeignKey("dbo.RunningClass", t => t.RunningClassId)
                .Index(t => t.ExamId)
                .Index(t => t.RunningClassId);
            
            AddColumn("dbo.ExamStudent", "UserClassId", c => c.Int(nullable: false));
            AddColumn("dbo.ExamSubject", "ExamOfClassId", c => c.Int(nullable: false));
            AddColumn("dbo.ExamSubject", "SettingsUsedFromExamClass", c => c.Boolean(nullable: false));
            AddColumn("dbo.ExamSubject", "Exam_Id", c => c.Int());
            AlterColumn("dbo.ExamSubject", "IsPercent", c => c.Boolean());
            AddForeignKey("dbo.ExamStudent", "UserClassId", "dbo.UserClass", "Id");
            AddForeignKey("dbo.ExamSubject", "ExamOfClassId", "dbo.ExamOfClass", "Id");
            AddForeignKey("dbo.ExamSubject", "Exam_Id", "dbo.Exam", "Id");
            CreateIndex("dbo.ExamStudent", "UserClassId");
            CreateIndex("dbo.ExamSubject", "ExamOfClassId");
            CreateIndex("dbo.ExamSubject", "Exam_Id");
            DropColumn("dbo.ExamSubject", "ExamId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExamSubject", "ExamId", c => c.Int(nullable: false));
            DropIndex("dbo.ExamOfClass", new[] { "RunningClassId" });
            DropIndex("dbo.ExamOfClass", new[] { "ExamId" });
            DropIndex("dbo.ExamSubject", new[] { "Exam_Id" });
            DropIndex("dbo.ExamSubject", new[] { "ExamOfClassId" });
            DropIndex("dbo.ExamStudent", new[] { "UserClassId" });
            DropForeignKey("dbo.ExamOfClass", "RunningClassId", "dbo.RunningClass");
            DropForeignKey("dbo.ExamOfClass", "ExamId", "dbo.Exam");
            DropForeignKey("dbo.ExamSubject", "Exam_Id", "dbo.Exam");
            DropForeignKey("dbo.ExamSubject", "ExamOfClassId", "dbo.ExamOfClass");
            DropForeignKey("dbo.ExamStudent", "UserClassId", "dbo.UserClass");
            AlterColumn("dbo.ExamSubject", "IsPercent", c => c.Boolean(nullable: false));
            DropColumn("dbo.ExamSubject", "Exam_Id");
            DropColumn("dbo.ExamSubject", "SettingsUsedFromExamClass");
            DropColumn("dbo.ExamSubject", "ExamOfClassId");
            DropColumn("dbo.ExamStudent", "UserClassId");
            DropTable("dbo.ExamOfClass");
            RenameColumn(table: "dbo.ExamStudent", name: "StudentClass_Id", newName: "StudentClassId");
            CreateIndex("dbo.ExamSubject", "ExamId");
            CreateIndex("dbo.ExamStudent", "StudentClassId");
            AddForeignKey("dbo.ExamSubject", "ExamId", "dbo.Exam", "Id");
            AddForeignKey("dbo.ExamStudent", "StudentClassId", "dbo.UserClass", "Id");
        }
    }
}

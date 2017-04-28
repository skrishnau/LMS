namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rand61 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamStudent", "ExamSubjectExaminerId", c => c.Int());
            AddForeignKey("dbo.ExamStudent", "ExamSubjectExaminerId", "dbo.ExamSubjectExaminer", "Id");
            CreateIndex("dbo.ExamStudent", "ExamSubjectExaminerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ExamStudent", new[] { "ExamSubjectExaminerId" });
            DropForeignKey("dbo.ExamStudent", "ExamSubjectExaminerId", "dbo.ExamSubjectExaminer");
            DropColumn("dbo.ExamStudent", "ExamSubjectExaminerId");
        }
    }
}

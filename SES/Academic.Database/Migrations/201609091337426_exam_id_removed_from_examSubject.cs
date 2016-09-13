namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exam_id_removed_from_examSubject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExamSubject", "Exam_Id", "dbo.Exam");
            DropIndex("dbo.ExamSubject", new[] { "Exam_Id" });
            DropColumn("dbo.ExamSubject", "Exam_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExamSubject", "Exam_Id", c => c.Int());
            CreateIndex("dbo.ExamSubject", "Exam_Id");
            AddForeignKey("dbo.ExamSubject", "Exam_Id", "dbo.Exam", "Id");
        }
    }
}

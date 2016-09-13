namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class column_name_changed1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamStudent", "IsGrade", c => c.Boolean());
            AddColumn("dbo.ExamStudent", "ObtainedGradeId", c => c.Int());
            AddColumn("dbo.ExamStudent", "IsPercent", c => c.Boolean());
            AddColumn("dbo.ExamStudent", "ObtainedMarks", c => c.Single());
            AddColumn("dbo.ExamStudent", "Void", c => c.Boolean());
            AlterColumn("dbo.ExamStudent", "PostedById", c => c.Int());
            AddForeignKey("dbo.ExamStudent", "ObtainedGradeId", "dbo.Grade", "Id");
            CreateIndex("dbo.ExamStudent", "ObtainedGradeId");
            DropColumn("dbo.ExamStudent", "ObtainedMarksInPercent");
            DropColumn("dbo.ExamStudent", "ObtainedMarksInGrade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExamStudent", "ObtainedMarksInGrade", c => c.String());
            AddColumn("dbo.ExamStudent", "ObtainedMarksInPercent", c => c.Single(nullable: false));
            DropIndex("dbo.ExamStudent", new[] { "ObtainedGradeId" });
            DropForeignKey("dbo.ExamStudent", "ObtainedGradeId", "dbo.Grade");
            AlterColumn("dbo.ExamStudent", "PostedById", c => c.Int(nullable: false));
            DropColumn("dbo.ExamStudent", "Void");
            DropColumn("dbo.ExamStudent", "ObtainedMarks");
            DropColumn("dbo.ExamStudent", "IsPercent");
            DropColumn("dbo.ExamStudent", "ObtainedGradeId");
            DropColumn("dbo.ExamStudent", "IsGrade");
        }
    }
}

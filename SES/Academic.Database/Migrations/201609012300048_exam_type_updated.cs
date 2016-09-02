namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exam_type_updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exam", "IsPercent", c => c.Boolean(nullable: false));
            AddColumn("dbo.Exam", "WeightMarks", c => c.Single());
            AddColumn("dbo.ExamType", "IsPercent", c => c.Boolean(nullable: false));
            AddColumn("dbo.ExamType", "WeightPercent", c => c.Single());
            AddColumn("dbo.ExamType", "WeightMarks", c => c.Single());
            AlterColumn("dbo.Exam", "ExamTypeId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exam", "ExamTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.ExamType", "WeightMarks");
            DropColumn("dbo.ExamType", "WeightPercent");
            DropColumn("dbo.ExamType", "IsPercent");
            DropColumn("dbo.Exam", "WeightMarks");
            DropColumn("dbo.Exam", "IsPercent");
        }
    }
}

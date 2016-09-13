namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no_idea4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ExamOfClass", "SettingsUsedFromExam");
            DropColumn("dbo.ExamOfClass", "IsPercent");
            DropColumn("dbo.ExamOfClass", "Weight");
            DropColumn("dbo.ExamOfClass", "FullMarks");
            DropColumn("dbo.ExamOfClass", "PassMarks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExamOfClass", "PassMarks", c => c.Int());
            AddColumn("dbo.ExamOfClass", "FullMarks", c => c.Int());
            AddColumn("dbo.ExamOfClass", "Weight", c => c.Single());
            AddColumn("dbo.ExamOfClass", "IsPercent", c => c.Boolean());
            AddColumn("dbo.ExamOfClass", "SettingsUsedFromExam", c => c.Boolean(nullable: false));
        }
    }
}

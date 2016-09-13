namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class column_name_changed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamSubject", "SettingsUsedFromExam", c => c.Boolean(nullable: false));
            DropColumn("dbo.ExamSubject", "SettingsUsedFromExamClass");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExamSubject", "SettingsUsedFromExamClass", c => c.Boolean(nullable: false));
            DropColumn("dbo.ExamSubject", "SettingsUsedFromExam");
        }
    }
}

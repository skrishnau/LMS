namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course_modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subject", "FullName", c => c.String());
            AddColumn("dbo.Subject", "CreatedById", c => c.Int(nullable: false));
            DropColumn("dbo.Subject", "Name");
            DropColumn("dbo.Subject", "Credit");
            DropColumn("dbo.Subject", "CompletionHours");
            DropColumn("dbo.Subject", "FullMarks");
            DropColumn("dbo.Subject", "PassPercentage");
            DropColumn("dbo.Subject", "IsActive");
            DropColumn("dbo.Subject", "HasLab");
            DropColumn("dbo.Subject", "HasTheory");
            DropColumn("dbo.Subject", "HasProject");
            DropColumn("dbo.Subject", "HasTutorial");
            DropColumn("dbo.Subject", "IsElective");
            DropColumn("dbo.Subject", "IsOutOfSyllabus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subject", "IsOutOfSyllabus", c => c.Boolean());
            AddColumn("dbo.Subject", "IsElective", c => c.Boolean());
            AddColumn("dbo.Subject", "HasTutorial", c => c.Boolean());
            AddColumn("dbo.Subject", "HasProject", c => c.Boolean());
            AddColumn("dbo.Subject", "HasTheory", c => c.Boolean());
            AddColumn("dbo.Subject", "HasLab", c => c.Boolean());
            AddColumn("dbo.Subject", "IsActive", c => c.Boolean());
            AddColumn("dbo.Subject", "PassPercentage", c => c.Byte());
            AddColumn("dbo.Subject", "FullMarks", c => c.Int());
            AddColumn("dbo.Subject", "CompletionHours", c => c.Short());
            AddColumn("dbo.Subject", "Credit", c => c.Byte());
            AddColumn("dbo.Subject", "Name", c => c.String());
            DropColumn("dbo.Subject", "CreatedById");
            DropColumn("dbo.Subject", "FullName");
        }
    }
}

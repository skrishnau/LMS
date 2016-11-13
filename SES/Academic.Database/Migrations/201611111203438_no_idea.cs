namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no_idea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcademicYear", "ActiveMarkedDate", c => c.DateTime());
            AddColumn("dbo.AcademicYear", "ActiveMarkedById", c => c.Int());
            AddColumn("dbo.AcademicYear", "CompleteMarkedDate", c => c.DateTime());
            AddColumn("dbo.AcademicYear", "CompleteMarkedById", c => c.Int());
            AddColumn("dbo.Session", "CompleteMarkedDate", c => c.DateTime());
            AddColumn("dbo.Session", "CompleteMarkedById", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Session", "CompleteMarkedById");
            DropColumn("dbo.Session", "CompleteMarkedDate");
            DropColumn("dbo.AcademicYear", "CompleteMarkedById");
            DropColumn("dbo.AcademicYear", "CompleteMarkedDate");
            DropColumn("dbo.AcademicYear", "ActiveMarkedById");
            DropColumn("dbo.AcademicYear", "ActiveMarkedDate");
        }
    }
}

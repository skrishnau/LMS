namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class position_added_in_academicYear_and_session : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcademicYear", "Position", c => c.Int(nullable: false));
            AddColumn("dbo.AcademicYear", "Completed", c => c.Boolean());
            AddColumn("dbo.Session", "Position", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Session", "Position");
            DropColumn("dbo.AcademicYear", "Completed");
            DropColumn("dbo.AcademicYear", "Position");
        }
    }
}

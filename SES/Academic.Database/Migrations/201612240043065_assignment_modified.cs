namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignment_modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "ShowGradeToStudents", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignment", "ShowGradeToStudents");
        }
    }
}

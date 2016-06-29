namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class void_add_in_student_group : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcademicYear", "Void", c => c.Boolean());
            AlterColumn("dbo.StudentGroup", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentGroup", "CreatedDate", c => c.DateTime());
            DropColumn("dbo.AcademicYear", "Void");
        }
    }
}

namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enrollment_is_now_int_in_subjectsessionUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SubjectSessionUser", "EnrollmentDuration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubjectSessionUser", "EnrollmentDuration", c => c.String());
        }
    }
}

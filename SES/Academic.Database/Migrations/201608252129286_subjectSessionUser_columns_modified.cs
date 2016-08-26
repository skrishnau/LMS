namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subjectSessionUser_columns_modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectSessionUser", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SubjectSessionUser", "StartDate", c => c.DateTime());
            AddColumn("dbo.SubjectSessionUser", "EndDate", c => c.DateTime());
            AddColumn("dbo.SubjectSessionUser", "EnrollmentDuration", c => c.String());
            DropColumn("dbo.SubjectSessionUser", "JoinedDate");
            DropColumn("dbo.SubjectSessionUser", "WithdrawDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubjectSessionUser", "WithdrawDate", c => c.DateTime());
            AddColumn("dbo.SubjectSessionUser", "JoinedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.SubjectSessionUser", "EnrollmentDuration");
            DropColumn("dbo.SubjectSessionUser", "EndDate");
            DropColumn("dbo.SubjectSessionUser", "StartDate");
            DropColumn("dbo.SubjectSessionUser", "CreatedDate");
        }
    }
}

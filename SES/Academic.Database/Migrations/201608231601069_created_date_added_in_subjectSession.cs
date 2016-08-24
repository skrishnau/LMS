namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class created_date_added_in_subjectSession : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectSession", "CreatedTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubjectSession", "CreatedTime");
        }
    }
}

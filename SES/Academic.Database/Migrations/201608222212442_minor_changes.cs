namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minor_changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectSession", "StartDate", c => c.DateTime());
            AddColumn("dbo.SubjectSession", "EndDate", c => c.DateTime());
            AddColumn("dbo.SubjectSession", "SessionComplete", c => c.Boolean());
            AddColumn("dbo.SubjectSession", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SubjectSession", "CompletionMarkedDate", c => c.DateTime());
            DropColumn("dbo.SubjectSession", "CompleteForThisTime");
            DropColumn("dbo.SubjectSession", "OpenedDate");
            DropColumn("dbo.SubjectSession", "CompleteDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubjectSession", "CompleteDate", c => c.DateTime());
            AddColumn("dbo.SubjectSession", "OpenedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SubjectSession", "CompleteForThisTime", c => c.Boolean());
            DropColumn("dbo.SubjectSession", "CompletionMarkedDate");
            DropColumn("dbo.SubjectSession", "CreatedDate");
            DropColumn("dbo.SubjectSession", "SessionComplete");
            DropColumn("dbo.SubjectSession", "EndDate");
            DropColumn("dbo.SubjectSession", "StartDate");
        }
    }
}

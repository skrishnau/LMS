namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minor_changes_no_idea_what : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectSession", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubjectSession", "Name");
        }
    }
}

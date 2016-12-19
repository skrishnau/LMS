namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no_idea3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityGrading", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActivityGrading", "Remarks");
        }
    }
}

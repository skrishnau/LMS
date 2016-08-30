namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minor_changes1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Session", "SessionType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Session", "SessionType", c => c.String());
        }
    }
}

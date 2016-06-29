namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commenceDateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batch", "ClassCommenceDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Batch", "ClassCommenceDate");
        }
    }
}

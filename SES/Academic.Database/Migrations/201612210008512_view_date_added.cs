namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class view_date_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityResourceView", "ViewedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActivityResourceView", "ViewedDate");
        }
    }
}

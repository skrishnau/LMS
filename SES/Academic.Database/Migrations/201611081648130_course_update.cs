namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subject", "Credit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subject", "Credit");
        }
    }
}

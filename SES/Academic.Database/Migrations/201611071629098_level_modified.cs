namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class level_modified : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Level", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Level", "IsActive", c => c.Boolean());
        }
    }
}

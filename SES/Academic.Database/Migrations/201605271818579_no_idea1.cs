namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no_idea1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Role", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Role", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}

namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isActive_removed_from_structure : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Year", "IsActive");
            DropColumn("dbo.Program", "IsActive");
            DropColumn("dbo.Faculty", "IsActive");
            DropColumn("dbo.SubYear", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubYear", "IsActive", c => c.Boolean());
            AddColumn("dbo.Faculty", "IsActive", c => c.Boolean());
            AddColumn("dbo.Program", "IsActive", c => c.Boolean());
            AddColumn("dbo.Year", "IsActive", c => c.Boolean());
        }
    }
}

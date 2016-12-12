namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class class_removed_from_classRestriction : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GroupRestriction", "ClassOrGroup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GroupRestriction", "ClassOrGroup", c => c.Boolean(nullable: false));
        }
    }
}

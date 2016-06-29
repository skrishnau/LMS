namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class void_added_in_Notice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notice", "Void", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notice", "Void");
        }
    }
}

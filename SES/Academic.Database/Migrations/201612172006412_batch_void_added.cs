namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class batch_void_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batch", "Void", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Batch", "Void");
        }
    }
}

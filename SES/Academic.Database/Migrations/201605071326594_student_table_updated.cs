namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student_table_updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "BatchAssigned", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "BatchAssigned");
        }
    }
}

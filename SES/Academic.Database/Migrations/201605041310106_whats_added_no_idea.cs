namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whats_added_no_idea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProgramBatch", "StartedStudying", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProgramBatch", "StartedStudying");
        }
    }
}

namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pass_out_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProgramBatch", "PassOut", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProgramBatch", "PassOut");
        }
    }
}

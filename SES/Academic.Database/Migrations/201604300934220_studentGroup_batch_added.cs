namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentGroup_batch_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentGroup", "BatchId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentGroup", "BatchId");
        }
    }
}

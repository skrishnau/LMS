namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class __void_added_in_studentBatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentBatch", "Void", c => c.Boolean());
            AddColumn("dbo.StudentBatch", "AddedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentBatch", "AddedDate");
            DropColumn("dbo.StudentBatch", "Void");
        }
    }
}

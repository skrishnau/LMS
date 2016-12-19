namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jpt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssignmentSubmissions", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssignmentSubmissions", "ModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}

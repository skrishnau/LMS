namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentGroup_StaratedStudying_field_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentGroup", "StartedStudying", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentGroup", "StartedStudying");
        }
    }
}

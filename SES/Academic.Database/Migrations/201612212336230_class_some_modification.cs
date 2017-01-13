namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class class_some_modification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectClass", "EnrollmentMethod", c => c.Byte(nullable: false));
            DropColumn("dbo.SubjectClass", "UseDefaultGrouping");
            DropColumn("dbo.SubjectClass", "CreatedTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubjectClass", "CreatedTime", c => c.String());
            AddColumn("dbo.SubjectClass", "UseDefaultGrouping", c => c.Boolean());
            DropColumn("dbo.SubjectClass", "EnrollmentMethod");
        }
    }
}

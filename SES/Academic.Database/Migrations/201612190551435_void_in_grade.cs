namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class void_in_grade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grade", "Void", c => c.Boolean());
            AddColumn("dbo.GradeValue", "Void", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GradeValue", "Void");
            DropColumn("dbo.Grade", "Void");
        }
    }
}

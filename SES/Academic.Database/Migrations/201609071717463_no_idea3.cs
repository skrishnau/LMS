namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no_idea3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamOfClass", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.ExamOfClass", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ExamOfClass", "UpdatedBy", c => c.Int());
            AddColumn("dbo.ExamOfClass", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExamOfClass", "UpdatedDate");
            DropColumn("dbo.ExamOfClass", "UpdatedBy");
            DropColumn("dbo.ExamOfClass", "CreatedDate");
            DropColumn("dbo.ExamOfClass", "CreatedBy");
        }
    }
}

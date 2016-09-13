namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class examType_Notice_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamType", "Notice", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExamType", "Notice");
        }
    }
}

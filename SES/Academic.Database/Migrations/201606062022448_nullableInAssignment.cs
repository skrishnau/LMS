namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableInAssignment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assignment", "WordLimit", c => c.Int());
            AlterColumn("dbo.Assignment", "MaximumNoOfUploadedFiles", c => c.Int());
            AlterColumn("dbo.Assignment", "MaximumSubmissionSize", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Assignment", "MaximumSubmissionSize", c => c.Int(nullable: false));
            AlterColumn("dbo.Assignment", "MaximumNoOfUploadedFiles", c => c.Int(nullable: false));
            AlterColumn("dbo.Assignment", "WordLimit", c => c.Int(nullable: false));
        }
    }
}

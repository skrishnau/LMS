namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coulumn_added_batch_academicYearId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batch", "AcademicYearId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Batch", "AcademicYearId", "dbo.AcademicYear", "Id");
            CreateIndex("dbo.Batch", "AcademicYearId");
            DropColumn("dbo.Batch", "ClassCommenceDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Batch", "ClassCommenceDate", c => c.DateTime());
            DropIndex("dbo.Batch", new[] { "AcademicYearId" });
            DropForeignKey("dbo.Batch", "AcademicYearId", "dbo.AcademicYear");
            DropColumn("dbo.Batch", "AcademicYearId");
        }
    }
}

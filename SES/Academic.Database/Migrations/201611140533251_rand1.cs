namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rand1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubjectStructure", "RemovedInAcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.SubjectStructure", "LastActiveInAcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.SubjectStructure", "WillNotBeActiveFromAcademicYearId", "dbo.AcademicYear");
            DropIndex("dbo.SubjectStructure", new[] { "RemovedInAcademicYearId" });
            DropIndex("dbo.SubjectStructure", new[] { "LastActiveInAcademicYearId" });
            DropIndex("dbo.SubjectStructure", new[] { "WillNotBeActiveFromAcademicYearId" });
            DropColumn("dbo.SubjectStructure", "RemovedInAcademicYearId");
            DropColumn("dbo.SubjectStructure", "LastActiveInAcademicYearId");
            DropColumn("dbo.SubjectStructure", "WillNotBeActiveFromAcademicYearId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubjectStructure", "WillNotBeActiveFromAcademicYearId", c => c.Int());
            AddColumn("dbo.SubjectStructure", "LastActiveInAcademicYearId", c => c.Int());
            AddColumn("dbo.SubjectStructure", "RemovedInAcademicYearId", c => c.Int());
            CreateIndex("dbo.SubjectStructure", "WillNotBeActiveFromAcademicYearId");
            CreateIndex("dbo.SubjectStructure", "LastActiveInAcademicYearId");
            CreateIndex("dbo.SubjectStructure", "RemovedInAcademicYearId");
            AddForeignKey("dbo.SubjectStructure", "WillNotBeActiveFromAcademicYearId", "dbo.AcademicYear", "Id");
            AddForeignKey("dbo.SubjectStructure", "LastActiveInAcademicYearId", "dbo.AcademicYear", "Id");
            AddForeignKey("dbo.SubjectStructure", "RemovedInAcademicYearId", "dbo.AcademicYear", "Id");
        }
    }
}

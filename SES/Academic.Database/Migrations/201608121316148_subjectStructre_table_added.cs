namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subjectStructre_table_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectStructure",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YearId = c.Int(nullable: false),
                        SubYearId = c.Int(),
                        SubjectId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        CreatedBy = c.Int(nullable: false),
                        VoidBy = c.Int(),
                        UpdatedBy = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        VoidDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        RemovedInAcademicYearId = c.Int(),
                        LastActiveInAcademicYearId = c.Int(),
                        WillNotBeActiveFromAcademicYearId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Year", t => t.YearId)
                .ForeignKey("dbo.SubYear", t => t.SubYearId)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.AcademicYear", t => t.RemovedInAcademicYearId)
                .ForeignKey("dbo.AcademicYear", t => t.LastActiveInAcademicYearId)
                .ForeignKey("dbo.AcademicYear", t => t.WillNotBeActiveFromAcademicYearId)
                .Index(t => t.YearId)
                .Index(t => t.SubYearId)
                .Index(t => t.SubjectId)
                .Index(t => t.RemovedInAcademicYearId)
                .Index(t => t.LastActiveInAcademicYearId)
                .Index(t => t.WillNotBeActiveFromAcademicYearId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SubjectStructure", new[] { "WillNotBeActiveFromAcademicYearId" });
            DropIndex("dbo.SubjectStructure", new[] { "LastActiveInAcademicYearId" });
            DropIndex("dbo.SubjectStructure", new[] { "RemovedInAcademicYearId" });
            DropIndex("dbo.SubjectStructure", new[] { "SubjectId" });
            DropIndex("dbo.SubjectStructure", new[] { "SubYearId" });
            DropIndex("dbo.SubjectStructure", new[] { "YearId" });
            DropForeignKey("dbo.SubjectStructure", "WillNotBeActiveFromAcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.SubjectStructure", "LastActiveInAcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.SubjectStructure", "RemovedInAcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.SubjectStructure", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectStructure", "SubYearId", "dbo.SubYear");
            DropForeignKey("dbo.SubjectStructure", "YearId", "dbo.Year");
            DropTable("dbo.SubjectStructure");
        }
    }
}

namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table_rename : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegularSubjectsGrouping", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.RegularSubjectsGrouping", "YearId", "dbo.Year");
            DropForeignKey("dbo.RegularSubjectsGrouping", "SubYearId", "dbo.SubYear");
            DropForeignKey("dbo.RegularSubjectClass", "RegularSubjectId", "dbo.RegularSubjectsGrouping");
            DropIndex("dbo.RegularSubjectsGrouping", new[] { "SubjectId" });
            DropIndex("dbo.RegularSubjectsGrouping", new[] { "YearId" });
            DropIndex("dbo.RegularSubjectsGrouping", new[] { "SubYearId" });
            DropIndex("dbo.RegularSubjectClass", new[] { "RegularSubjectId" });
            CreateTable(
                "dbo.RegularSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                        SubYearId = c.Int(),
                        AssignedDate = c.DateTime(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.Year", t => t.YearId)
                .ForeignKey("dbo.SubYear", t => t.SubYearId)
                .Index(t => t.SubjectId)
                .Index(t => t.YearId)
                .Index(t => t.SubYearId);
            
            DropColumn("dbo.RegularSubjectClass", "RegularSubjectId");
            DropTable("dbo.RegularSubjectsGrouping");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegularSubjectsGrouping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                        SubYearId = c.Int(),
                        AssignedDate = c.DateTime(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.RegularSubjectClass", "RegularSubjectId", c => c.Int(nullable: false));
            DropIndex("dbo.RegularSubject", new[] { "SubYearId" });
            DropIndex("dbo.RegularSubject", new[] { "YearId" });
            DropIndex("dbo.RegularSubject", new[] { "SubjectId" });
            DropForeignKey("dbo.RegularSubject", "SubYearId", "dbo.SubYear");
            DropForeignKey("dbo.RegularSubject", "YearId", "dbo.Year");
            DropForeignKey("dbo.RegularSubject", "SubjectId", "dbo.Subject");
            DropTable("dbo.RegularSubject");
            CreateIndex("dbo.RegularSubjectClass", "RegularSubjectId");
            CreateIndex("dbo.RegularSubjectsGrouping", "SubYearId");
            CreateIndex("dbo.RegularSubjectsGrouping", "YearId");
            CreateIndex("dbo.RegularSubjectsGrouping", "SubjectId");
            AddForeignKey("dbo.RegularSubjectClass", "RegularSubjectId", "dbo.RegularSubjectsGrouping", "Id");
            AddForeignKey("dbo.RegularSubjectsGrouping", "SubYearId", "dbo.SubYear", "Id");
            AddForeignKey("dbo.RegularSubjectsGrouping", "YearId", "dbo.Year", "Id");
            AddForeignKey("dbo.RegularSubjectsGrouping", "SubjectId", "dbo.Subject", "Id");
        }
    }
}

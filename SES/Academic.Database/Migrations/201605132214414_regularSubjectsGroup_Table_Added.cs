namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regularSubjectsGroup_Table_Added : DbMigration
    {
        public override void Up()
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
                        Program_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.Program", t => t.Program_Id)
                .ForeignKey("dbo.Year", t => t.YearId)
                .ForeignKey("dbo.SubYear", t => t.SubYearId)
                .Index(t => t.SubjectId)
                .Index(t => t.Program_Id)
                .Index(t => t.YearId)
                .Index(t => t.SubYearId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.RegularSubjectsGrouping", new[] { "SubYearId" });
            DropIndex("dbo.RegularSubjectsGrouping", new[] { "YearId" });
            DropIndex("dbo.RegularSubjectsGrouping", new[] { "Program_Id" });
            DropIndex("dbo.RegularSubjectsGrouping", new[] { "SubjectId" });
            DropForeignKey("dbo.RegularSubjectsGrouping", "SubYearId", "dbo.SubYear");
            DropForeignKey("dbo.RegularSubjectsGrouping", "YearId", "dbo.Year");
            DropForeignKey("dbo.RegularSubjectsGrouping", "Program_Id", "dbo.Program");
            DropForeignKey("dbo.RegularSubjectsGrouping", "SubjectId", "dbo.Subject");
            DropTable("dbo.RegularSubjectsGrouping");
        }
    }
}

namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regularSubjectTecher_table_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegularSubjectsTeacher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegularSubjectsGroupingId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        JoinedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        LeftDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RegularSubjectsGrouping", t => t.RegularSubjectsGroupingId)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.RegularSubjectsGroupingId)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.RegularSubjectsTeacher", new[] { "TeacherId" });
            DropIndex("dbo.RegularSubjectsTeacher", new[] { "RegularSubjectsGroupingId" });
            DropForeignKey("dbo.RegularSubjectsTeacher", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.RegularSubjectsTeacher", "RegularSubjectsGroupingId", "dbo.RegularSubjectsGrouping");
            DropTable("dbo.RegularSubjectsTeacher");
        }
    }
}

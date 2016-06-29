namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tables_added_RegularSubjectClass_and_UserClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegularSubjectsTeacher", "RegularSubjectsGroupingId", "dbo.RegularSubjectsGrouping");
            DropForeignKey("dbo.RegularSubjectsTeacher", "TeacherId", "dbo.Teacher");
            DropIndex("dbo.RegularSubjectsTeacher", new[] { "RegularSubjectsGroupingId" });
            DropIndex("dbo.RegularSubjectsTeacher", new[] { "TeacherId" });
            CreateTable(
                "dbo.RegularSubjectClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RunningClassId = c.Int(nullable: false),
                        RegularSubjectId = c.Int(nullable: false),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RunningClass", t => t.RunningClassId)
                .ForeignKey("dbo.RegularSubjectsGrouping", t => t.RegularSubjectId)
                .Index(t => t.RunningClassId)
                .Index(t => t.RegularSubjectId);
            
            CreateTable(
                "dbo.UserClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegularSubjectClassId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        JoinedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        LeftDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RegularSubjectClass", t => t.RegularSubjectClassId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.RegularSubjectClassId)
                .Index(t => t.UserId);
            
            DropTable("dbo.RegularSubjectsTeacher");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.UserClass", new[] { "UserId" });
            DropIndex("dbo.UserClass", new[] { "RegularSubjectClassId" });
            DropIndex("dbo.RegularSubjectClass", new[] { "RegularSubjectId" });
            DropIndex("dbo.RegularSubjectClass", new[] { "RunningClassId" });
            DropForeignKey("dbo.UserClass", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClass", "RegularSubjectClassId", "dbo.RegularSubjectClass");
            DropForeignKey("dbo.RegularSubjectClass", "RegularSubjectId", "dbo.RegularSubjectsGrouping");
            DropForeignKey("dbo.RegularSubjectClass", "RunningClassId", "dbo.RunningClass");
            DropTable("dbo.UserClass");
            DropTable("dbo.RegularSubjectClass");
            CreateIndex("dbo.RegularSubjectsTeacher", "TeacherId");
            CreateIndex("dbo.RegularSubjectsTeacher", "RegularSubjectsGroupingId");
            AddForeignKey("dbo.RegularSubjectsTeacher", "TeacherId", "dbo.Teacher", "Id");
            AddForeignKey("dbo.RegularSubjectsTeacher", "RegularSubjectsGroupingId", "dbo.RegularSubjectsGrouping", "Id");
        }
    }
}

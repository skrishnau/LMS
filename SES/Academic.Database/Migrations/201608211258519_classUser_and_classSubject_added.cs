namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classUser_and_classSubject_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassSubjectId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassSubject", t => t.ClassSubjectId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.ClassSubjectId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ClassSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsRegular = c.Boolean(nullable: false),
                        SubjectStructureId = c.Int(),
                        ProgramBatchId = c.Int(),
                        AcademicYearId = c.Int(),
                        SessionId = c.Int(),
                        SubjectId = c.Int(),
                        Void = c.Boolean(),
                        VoidBy = c.Int(),
                        VoidDate = c.DateTime(),
                        CompleteForThisTime = c.Boolean(),
                        OpenedDate = c.DateTime(nullable: false),
                        CompleteDate = c.DateTime(),
                        CompleteMarkedByUserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectStructure", t => t.SubjectStructureId)
                .ForeignKey("dbo.ProgramBatch", t => t.ProgramBatchId)
                .ForeignKey("dbo.AcademicYear", t => t.AcademicYearId)
                .ForeignKey("dbo.Session", t => t.SessionId)
                .Index(t => t.SubjectStructureId)
                .Index(t => t.ProgramBatchId)
                .Index(t => t.AcademicYearId)
                .Index(t => t.SessionId);
            
            AddColumn("dbo.SubjectStructure", "Obsolete", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropIndex("dbo.ClassSubject", new[] { "SessionId" });
            DropIndex("dbo.ClassSubject", new[] { "AcademicYearId" });
            DropIndex("dbo.ClassSubject", new[] { "ProgramBatchId" });
            DropIndex("dbo.ClassSubject", new[] { "SubjectStructureId" });
            DropIndex("dbo.ClassUser", new[] { "RoleId" });
            DropIndex("dbo.ClassUser", new[] { "UserId" });
            DropIndex("dbo.ClassUser", new[] { "ClassSubjectId" });
            DropForeignKey("dbo.ClassSubject", "SessionId", "dbo.Session");
            DropForeignKey("dbo.ClassSubject", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.ClassSubject", "ProgramBatchId", "dbo.ProgramBatch");
            DropForeignKey("dbo.ClassSubject", "SubjectStructureId", "dbo.SubjectStructure");
            DropForeignKey("dbo.ClassUser", "RoleId", "dbo.Role");
            DropForeignKey("dbo.ClassUser", "UserId", "dbo.Users");
            DropForeignKey("dbo.ClassUser", "ClassSubjectId", "dbo.ClassSubject");
            DropColumn("dbo.SubjectStructure", "Obsolete");
            DropTable("dbo.ClassSubject");
            DropTable("dbo.ClassUser");
        }
    }
}

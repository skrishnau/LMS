namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamingOf_SubjectSession_and_SubjectSessionUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassUser", "ClassSubjectId", "dbo.ClassSubject");
            DropForeignKey("dbo.ClassUser", "UserId", "dbo.Users");
            DropForeignKey("dbo.ClassUser", "RoleId", "dbo.Role");
            DropForeignKey("dbo.ClassSubject", "SubjectStructureId", "dbo.SubjectStructure");
            DropForeignKey("dbo.ClassSubject", "ProgramBatchId", "dbo.ProgramBatch");
            DropForeignKey("dbo.ClassSubject", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.ClassSubject", "SessionId", "dbo.Session");
            DropIndex("dbo.ClassUser", new[] { "ClassSubjectId" });
            DropIndex("dbo.ClassUser", new[] { "UserId" });
            DropIndex("dbo.ClassUser", new[] { "RoleId" });
            DropIndex("dbo.ClassSubject", new[] { "SubjectStructureId" });
            DropIndex("dbo.ClassSubject", new[] { "ProgramBatchId" });
            DropIndex("dbo.ClassSubject", new[] { "AcademicYearId" });
            DropIndex("dbo.ClassSubject", new[] { "SessionId" });
            CreateTable(
                "dbo.SubjectSessionUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectSessionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        JoinedDate = c.DateTime(nullable: false),
                        WithdrawDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectSession", t => t.SubjectSessionId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.SubjectSessionId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SubjectSession",
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
            
            DropTable("dbo.ClassUser");
            DropTable("dbo.ClassSubject");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.SubjectSession", new[] { "SessionId" });
            DropIndex("dbo.SubjectSession", new[] { "AcademicYearId" });
            DropIndex("dbo.SubjectSession", new[] { "ProgramBatchId" });
            DropIndex("dbo.SubjectSession", new[] { "SubjectStructureId" });
            DropIndex("dbo.SubjectSessionUser", new[] { "RoleId" });
            DropIndex("dbo.SubjectSessionUser", new[] { "UserId" });
            DropIndex("dbo.SubjectSessionUser", new[] { "SubjectSessionId" });
            DropForeignKey("dbo.SubjectSession", "SessionId", "dbo.Session");
            DropForeignKey("dbo.SubjectSession", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.SubjectSession", "ProgramBatchId", "dbo.ProgramBatch");
            DropForeignKey("dbo.SubjectSession", "SubjectStructureId", "dbo.SubjectStructure");
            DropForeignKey("dbo.SubjectSessionUser", "RoleId", "dbo.Role");
            DropForeignKey("dbo.SubjectSessionUser", "UserId", "dbo.Users");
            DropForeignKey("dbo.SubjectSessionUser", "SubjectSessionId", "dbo.SubjectSession");
            DropTable("dbo.SubjectSession");
            DropTable("dbo.SubjectSessionUser");
            CreateIndex("dbo.ClassSubject", "SessionId");
            CreateIndex("dbo.ClassSubject", "AcademicYearId");
            CreateIndex("dbo.ClassSubject", "ProgramBatchId");
            CreateIndex("dbo.ClassSubject", "SubjectStructureId");
            CreateIndex("dbo.ClassUser", "RoleId");
            CreateIndex("dbo.ClassUser", "UserId");
            CreateIndex("dbo.ClassUser", "ClassSubjectId");
            AddForeignKey("dbo.ClassSubject", "SessionId", "dbo.Session", "Id");
            AddForeignKey("dbo.ClassSubject", "AcademicYearId", "dbo.AcademicYear", "Id");
            AddForeignKey("dbo.ClassSubject", "ProgramBatchId", "dbo.ProgramBatch", "Id");
            AddForeignKey("dbo.ClassSubject", "SubjectStructureId", "dbo.SubjectStructure", "Id");
            AddForeignKey("dbo.ClassUser", "RoleId", "dbo.Role", "Id");
            AddForeignKey("dbo.ClassUser", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.ClassUser", "ClassSubjectId", "dbo.ClassSubject", "Id");
        }
    }
}

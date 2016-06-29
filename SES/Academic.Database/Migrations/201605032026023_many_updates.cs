namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class many_updates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentProgramBatch", "ProgramBatchId", "dbo.ProgramBatch");
            DropForeignKey("dbo.StudentProgramBatch", "StudentId", "dbo.Student");
            DropIndex("dbo.StudentProgramBatch", new[] { "ProgramBatchId" });
            DropIndex("dbo.StudentProgramBatch", new[] { "StudentId" });
            CreateTable(
                "dbo.StudentBatch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramBatchId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        InActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProgramBatch", t => t.ProgramBatchId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.ProgramBatchId)
                .Index(t => t.StudentId);
            
            AddColumn("dbo.ProgramBatch", "StudyCompleted", c => c.Boolean());
            AddColumn("dbo.RunningClass", "ProgramBatchId", c => c.Int());
            AddForeignKey("dbo.RunningClass", "ProgramBatchId", "dbo.ProgramBatch", "Id");
            CreateIndex("dbo.RunningClass", "ProgramBatchId");
            DropTable("dbo.StudentProgramBatch");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentProgramBatch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramBatchId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        InActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.StudentBatch", new[] { "StudentId" });
            DropIndex("dbo.StudentBatch", new[] { "ProgramBatchId" });
            DropIndex("dbo.RunningClass", new[] { "ProgramBatchId" });
            DropForeignKey("dbo.StudentBatch", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentBatch", "ProgramBatchId", "dbo.ProgramBatch");
            DropForeignKey("dbo.RunningClass", "ProgramBatchId", "dbo.ProgramBatch");
            DropColumn("dbo.RunningClass", "ProgramBatchId");
            DropColumn("dbo.ProgramBatch", "StudyCompleted");
            DropTable("dbo.StudentBatch");
            CreateIndex("dbo.StudentProgramBatch", "StudentId");
            CreateIndex("dbo.StudentProgramBatch", "ProgramBatchId");
            AddForeignKey("dbo.StudentProgramBatch", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.StudentProgramBatch", "ProgramBatchId", "dbo.ProgramBatch", "Id");
        }
    }
}

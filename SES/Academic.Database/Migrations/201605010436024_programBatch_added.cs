namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class programBatch_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgramBatch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        CurrentYearId = c.Int(),
                        CurrentSubYearId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batch", t => t.BatchId)
                .ForeignKey("dbo.Program", t => t.ProgramId)
                .ForeignKey("dbo.Year", t => t.CurrentYearId)
                .ForeignKey("dbo.SubYear", t => t.CurrentSubYearId)
                .Index(t => t.BatchId)
                .Index(t => t.ProgramId)
                .Index(t => t.CurrentYearId)
                .Index(t => t.CurrentSubYearId);
            
            CreateTable(
                "dbo.Batch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.StudentProgramBatch",
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
            
            AddColumn("dbo.StudentGroup", "IsFromBatch", c => c.Boolean());
            AddColumn("dbo.StudentGroup", "ProgramBatchId", c => c.Int());
            AddForeignKey("dbo.StudentGroup", "ProgramBatchId", "dbo.ProgramBatch", "Id");
            CreateIndex("dbo.StudentGroup", "ProgramBatchId");
            DropColumn("dbo.StudentGroup", "BatchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentGroup", "BatchId", c => c.Int());
            DropIndex("dbo.StudentProgramBatch", new[] { "StudentId" });
            DropIndex("dbo.StudentProgramBatch", new[] { "ProgramBatchId" });
            DropIndex("dbo.StudentGroup", new[] { "ProgramBatchId" });
            DropIndex("dbo.Batch", new[] { "SchoolId" });
            DropIndex("dbo.ProgramBatch", new[] { "CurrentSubYearId" });
            DropIndex("dbo.ProgramBatch", new[] { "CurrentYearId" });
            DropIndex("dbo.ProgramBatch", new[] { "ProgramId" });
            DropIndex("dbo.ProgramBatch", new[] { "BatchId" });
            DropForeignKey("dbo.StudentProgramBatch", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentProgramBatch", "ProgramBatchId", "dbo.ProgramBatch");
            DropForeignKey("dbo.StudentGroup", "ProgramBatchId", "dbo.ProgramBatch");
            DropForeignKey("dbo.Batch", "SchoolId", "dbo.School");
            DropForeignKey("dbo.ProgramBatch", "CurrentSubYearId", "dbo.SubYear");
            DropForeignKey("dbo.ProgramBatch", "CurrentYearId", "dbo.Year");
            DropForeignKey("dbo.ProgramBatch", "ProgramId", "dbo.Program");
            DropForeignKey("dbo.ProgramBatch", "BatchId", "dbo.Batch");
            DropColumn("dbo.StudentGroup", "ProgramBatchId");
            DropColumn("dbo.StudentGroup", "IsFromBatch");
            DropTable("dbo.StudentProgramBatch");
            DropTable("dbo.Batch");
            DropTable("dbo.ProgramBatch");
        }
    }
}

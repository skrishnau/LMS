namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gradeNamechanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assignment", "GradeTypeId", "dbo.GradeType");
            DropForeignKey("dbo.GradeType", "SchoolId", "dbo.School");
            DropForeignKey("dbo.GradeValues", "GradeTypeId", "dbo.GradeType");
            DropForeignKey("dbo.ActivityGrading", "ObtainedGradeId", "dbo.GradeValues");
            DropForeignKey("dbo.ExamStudent", "ObtainedGradeId", "dbo.Grade");
            DropIndex("dbo.Assignment", new[] { "GradeTypeId" });
            DropIndex("dbo.GradeType", new[] { "SchoolId" });
            DropIndex("dbo.GradeValues", new[] { "GradeTypeId" });
            DropIndex("dbo.ActivityGrading", new[] { "ObtainedGradeId" });
            DropIndex("dbo.ExamStudent", new[] { "ObtainedGradeId" });
            CreateTable(
                "dbo.GradeValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        IsFailGrade = c.Boolean(),
                        GradeTypeId = c.Int(nullable: false),
                        EquivalentPercentOrPostition = c.Single(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grade", t => t.GradeTypeId)
                .Index(t => t.GradeTypeId);
            
            AddColumn("dbo.Grade", "Type", c => c.String());
            AddColumn("dbo.Grade", "GradeValueIsInPercentOrPostition", c => c.Boolean());
            AddColumn("dbo.Grade", "TotalMaxValue", c => c.Single());
            AddColumn("dbo.Grade", "TotalMinValue", c => c.Single());
            AddColumn("dbo.Grade", "MinimumPassValue", c => c.Single());
            AddColumn("dbo.Grade", "SchoolId", c => c.Int());
            AddForeignKey("dbo.Assignment", "GradeTypeId", "dbo.Grade", "Id");
            AddForeignKey("dbo.Grade", "SchoolId", "dbo.School", "Id");
            AddForeignKey("dbo.ActivityGrading", "ObtainedGradeId", "dbo.GradeValue", "Id");
            AddForeignKey("dbo.ExamStudent", "ObtainedGradeId", "dbo.GradeValue", "Id");
            CreateIndex("dbo.Assignment", "GradeTypeId");
            CreateIndex("dbo.Grade", "SchoolId");
            CreateIndex("dbo.ActivityGrading", "ObtainedGradeId");
            CreateIndex("dbo.ExamStudent", "ObtainedGradeId");
            DropColumn("dbo.Grade", "EquivalentPercent");
            DropTable("dbo.GradeType");
            DropTable("dbo.GradeValues");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GradeValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        IsFailGrade = c.Boolean(),
                        GradeTypeId = c.Int(nullable: false),
                        EquivalentPercentOrPostition = c.Single(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GradeType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Type = c.String(),
                        GradeValueIsInPercentOrPostition = c.Boolean(),
                        TotalMaxValue = c.Single(),
                        TotalMinValue = c.Single(),
                        MinimumPassValue = c.Single(),
                        SchoolId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Grade", "EquivalentPercent", c => c.Single());
            DropIndex("dbo.ExamStudent", new[] { "ObtainedGradeId" });
            DropIndex("dbo.ActivityGrading", new[] { "ObtainedGradeId" });
            DropIndex("dbo.GradeValue", new[] { "GradeTypeId" });
            DropIndex("dbo.Grade", new[] { "SchoolId" });
            DropIndex("dbo.Assignment", new[] { "GradeTypeId" });
            DropForeignKey("dbo.ExamStudent", "ObtainedGradeId", "dbo.GradeValue");
            DropForeignKey("dbo.ActivityGrading", "ObtainedGradeId", "dbo.GradeValue");
            DropForeignKey("dbo.GradeValue", "GradeTypeId", "dbo.Grade");
            DropForeignKey("dbo.Grade", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Assignment", "GradeTypeId", "dbo.Grade");
            DropColumn("dbo.Grade", "SchoolId");
            DropColumn("dbo.Grade", "MinimumPassValue");
            DropColumn("dbo.Grade", "TotalMinValue");
            DropColumn("dbo.Grade", "TotalMaxValue");
            DropColumn("dbo.Grade", "GradeValueIsInPercentOrPostition");
            DropColumn("dbo.Grade", "Type");
            DropTable("dbo.GradeValue");
            CreateIndex("dbo.ExamStudent", "ObtainedGradeId");
            CreateIndex("dbo.ActivityGrading", "ObtainedGradeId");
            CreateIndex("dbo.GradeValues", "GradeTypeId");
            CreateIndex("dbo.GradeType", "SchoolId");
            CreateIndex("dbo.Assignment", "GradeTypeId");
            AddForeignKey("dbo.ExamStudent", "ObtainedGradeId", "dbo.Grade", "Id");
            AddForeignKey("dbo.ActivityGrading", "ObtainedGradeId", "dbo.GradeValues", "Id");
            AddForeignKey("dbo.GradeValues", "GradeTypeId", "dbo.GradeType", "Id");
            AddForeignKey("dbo.GradeType", "SchoolId", "dbo.School", "Id");
            AddForeignKey("dbo.Assignment", "GradeTypeId", "dbo.GradeType", "Id");
        }
    }
}

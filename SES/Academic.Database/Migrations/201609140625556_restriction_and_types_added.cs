namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restriction_and_types_added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Restriction", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.AssignedTask", "TeachId", "dbo.Teach");
            DropForeignKey("dbo.AssignedTask", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.AssignedTask", "SessionId", "dbo.Session");
            DropForeignKey("dbo.AssignmentMarks", "AssignedTaskId", "dbo.AssignedTask");
            DropForeignKey("dbo.AssignmentMarks", "StudentId", "dbo.Student");
            DropForeignKey("dbo.AssignmentMarks", "GradeId", "dbo.Grade");
            DropIndex("dbo.Restriction", new[] { "SubjectId" });
            DropIndex("dbo.AssignedTask", new[] { "TeachId" });
            DropIndex("dbo.AssignedTask", new[] { "AssignmentId" });
            DropIndex("dbo.AssignedTask", new[] { "SessionId" });
            DropIndex("dbo.AssignmentMarks", new[] { "AssignedTaskId" });
            DropIndex("dbo.AssignmentMarks", new[] { "StudentId" });
            DropIndex("dbo.AssignmentMarks", new[] { "GradeId" });
            CreateTable(
                "dbo.DateRestriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestrictionId = c.Int(nullable: false),
                        Constraint = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.GradeRestriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestrictionId = c.Int(nullable: false),
                        ActivityResourceId = c.Int(nullable: false),
                        MustBeGreaterThanOrEqualTo = c.Boolean(nullable: false),
                        GreaterThanOrEqualToValue = c.Single(),
                        MustBeLessThan = c.Boolean(nullable: false),
                        LessThanValue = c.Single(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .ForeignKey("dbo.ActivityResource", t => t.ActivityResourceId)
                .Index(t => t.RestrictionId)
                .Index(t => t.ActivityResourceId);
            
            CreateTable(
                "dbo.ActivityResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityOrResource = c.Boolean(nullable: false),
                        ActivityOrResourceType = c.Byte(nullable: false),
                        ActivityOrResourceId = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                        SubjectSectionId = c.Int(nullable: false),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectSection", t => t.SubjectSectionId)
                .Index(t => t.SubjectSectionId);
            
            CreateTable(
                "dbo.GroupRestriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassOrGroup = c.Boolean(nullable: false),
                        SubjectClassId = c.Int(),
                        GroupId = c.Int(),
                        RestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.SubjectClassId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.UserProfileRestriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FieldName = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SubjectSection", "Position", c => c.Int(nullable: false));
            AddColumn("dbo.Restriction", "ParentId", c => c.Int());
            AddColumn("dbo.Restriction", "MatchMust", c => c.Boolean(nullable: false));
            AddColumn("dbo.Restriction", "MatchAllAny", c => c.Boolean(nullable: false));
            AddColumn("dbo.Restriction", "Visibility", c => c.Boolean(nullable: false));
            AddForeignKey("dbo.Restriction", "ParentId", "dbo.Restriction", "Id");
            CreateIndex("dbo.Restriction", "ParentId");
            DropColumn("dbo.Restriction", "Type");
            DropColumn("dbo.Restriction", "TypeId");
            DropColumn("dbo.Restriction", "CheckParameter1");
            DropColumn("dbo.Restriction", "CheckParameter2");
            DropColumn("dbo.Restriction", "StringValue1");
            DropColumn("dbo.Restriction", "StringValue2");
            DropColumn("dbo.Restriction", "IntValue1");
            DropColumn("dbo.Restriction", "IntValue2");
            DropColumn("dbo.Restriction", "SubjectId");
            DropTable("dbo.AssignedTask");
            DropTable("dbo.AssignmentMarks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AssignmentMarks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignedTaskId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Marks = c.Single(nullable: false),
                        IsGradeSystem = c.Boolean(nullable: false),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssignedTask",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeachId = c.Int(nullable: false),
                        AssignmentId = c.Int(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        DueDate = c.String(),
                        Remarks = c.String(),
                        SessionId = c.Int(nullable: false),
                        CarriesMarks = c.Boolean(nullable: false),
                        TotalMarks = c.Short(),
                        PassMarks = c.Short(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Restriction", "SubjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Restriction", "IntValue2", c => c.Int(nullable: false));
            AddColumn("dbo.Restriction", "IntValue1", c => c.Int(nullable: false));
            AddColumn("dbo.Restriction", "StringValue2", c => c.String());
            AddColumn("dbo.Restriction", "StringValue1", c => c.String());
            AddColumn("dbo.Restriction", "CheckParameter2", c => c.String());
            AddColumn("dbo.Restriction", "CheckParameter1", c => c.String());
            AddColumn("dbo.Restriction", "TypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Restriction", "Type", c => c.String());
            DropIndex("dbo.GroupRestriction", new[] { "RestrictionId" });
            DropIndex("dbo.GroupRestriction", new[] { "SubjectClassId" });
            DropIndex("dbo.ActivityResource", new[] { "SubjectSectionId" });
            DropIndex("dbo.GradeRestriction", new[] { "ActivityResourceId" });
            DropIndex("dbo.GradeRestriction", new[] { "RestrictionId" });
            DropIndex("dbo.DateRestriction", new[] { "RestrictionId" });
            DropIndex("dbo.Restriction", new[] { "ParentId" });
            DropForeignKey("dbo.GroupRestriction", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.GroupRestriction", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.ActivityResource", "SubjectSectionId", "dbo.SubjectSection");
            DropForeignKey("dbo.GradeRestriction", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.GradeRestriction", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.DateRestriction", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.Restriction", "ParentId", "dbo.Restriction");
            DropColumn("dbo.Restriction", "Visibility");
            DropColumn("dbo.Restriction", "MatchAllAny");
            DropColumn("dbo.Restriction", "MatchMust");
            DropColumn("dbo.Restriction", "ParentId");
            DropColumn("dbo.SubjectSection", "Position");
            DropTable("dbo.UserProfileRestriction");
            DropTable("dbo.GroupRestriction");
            DropTable("dbo.ActivityResource");
            DropTable("dbo.GradeRestriction");
            DropTable("dbo.DateRestriction");
            CreateIndex("dbo.AssignmentMarks", "GradeId");
            CreateIndex("dbo.AssignmentMarks", "StudentId");
            CreateIndex("dbo.AssignmentMarks", "AssignedTaskId");
            CreateIndex("dbo.AssignedTask", "SessionId");
            CreateIndex("dbo.AssignedTask", "AssignmentId");
            CreateIndex("dbo.AssignedTask", "TeachId");
            CreateIndex("dbo.Restriction", "SubjectId");
            AddForeignKey("dbo.AssignmentMarks", "GradeId", "dbo.Grade", "Id");
            AddForeignKey("dbo.AssignmentMarks", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.AssignmentMarks", "AssignedTaskId", "dbo.AssignedTask", "Id");
            AddForeignKey("dbo.AssignedTask", "SessionId", "dbo.Session", "Id");
            AddForeignKey("dbo.AssignedTask", "AssignmentId", "dbo.Assignment", "Id");
            AddForeignKey("dbo.AssignedTask", "TeachId", "dbo.Teach", "Id");
            AddForeignKey("dbo.Restriction", "SubjectId", "dbo.Subject", "Id");
        }
    }
}

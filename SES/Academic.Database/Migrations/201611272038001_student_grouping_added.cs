namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student_grouping_added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserClass", "SubjectUserGroupId", "dbo.SubjectUserGroup");
            DropForeignKey("dbo.SubjectUserGroup", "SubjectId", "dbo.Subject");
            DropIndex("dbo.UserClass", new[] { "SubjectUserGroupId" });
            DropIndex("dbo.SubjectUserGroup", new[] { "SubjectId" });
            CreateTable(
                "dbo.UserClassGrouping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserClassId = c.Int(nullable: false),
                        GroupingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserClass", t => t.UserClassId)
                .ForeignKey("dbo.SubjectClassGrouping", t => t.GroupingId)
                .Index(t => t.UserClassId)
                .Index(t => t.GroupingId);
            
            CreateTable(
                "dbo.SubjectClassGrouping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectClassId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .Index(t => t.SubjectClassId);
            
            CreateTable(
                "dbo.BatchGrouping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batch", t => t.BatchId)
                .Index(t => t.BatchId);
            
            CreateTable(
                "dbo.SubjectGrouping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            DropColumn("dbo.UserClass", "SubjectUserGroupId");
            DropTable("dbo.SubjectUserGroup");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubjectUserGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserClass", "SubjectUserGroupId", c => c.Int());
            DropIndex("dbo.SubjectGrouping", new[] { "SubjectId" });
            DropIndex("dbo.BatchGrouping", new[] { "BatchId" });
            DropIndex("dbo.SubjectClassGrouping", new[] { "SubjectClassId" });
            DropIndex("dbo.UserClassGrouping", new[] { "GroupingId" });
            DropIndex("dbo.UserClassGrouping", new[] { "UserClassId" });
            DropForeignKey("dbo.SubjectGrouping", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.BatchGrouping", "BatchId", "dbo.Batch");
            DropForeignKey("dbo.SubjectClassGrouping", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.UserClassGrouping", "GroupingId", "dbo.SubjectClassGrouping");
            DropForeignKey("dbo.UserClassGrouping", "UserClassId", "dbo.UserClass");
            DropTable("dbo.SubjectGrouping");
            DropTable("dbo.BatchGrouping");
            DropTable("dbo.SubjectClassGrouping");
            DropTable("dbo.UserClassGrouping");
            CreateIndex("dbo.SubjectUserGroup", "SubjectId");
            CreateIndex("dbo.UserClass", "SubjectUserGroupId");
            AddForeignKey("dbo.SubjectUserGroup", "SubjectId", "dbo.Subject", "Id");
            AddForeignKey("dbo.UserClass", "SubjectUserGroupId", "dbo.SubjectUserGroup", "Id");
        }
    }
}

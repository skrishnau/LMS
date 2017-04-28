namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gradeNamechanged1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GradeValue", "GradeTypeId", "dbo.Grade");
            DropIndex("dbo.GradeValue", new[] { "GradeTypeId" });
            AddColumn("dbo.GradeValue", "GradeId", c => c.Int(nullable: false));
            AddForeignKey("dbo.GradeValue", "GradeId", "dbo.Grade", "Id");
            CreateIndex("dbo.GradeValue", "GradeId");
            DropColumn("dbo.GradeValue", "GradeTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GradeValue", "GradeTypeId", c => c.Int(nullable: false));
            DropIndex("dbo.GradeValue", new[] { "GradeId" });
            DropForeignKey("dbo.GradeValue", "GradeId", "dbo.Grade");
            DropColumn("dbo.GradeValue", "GradeId");
            CreateIndex("dbo.GradeValue", "GradeTypeId");
            AddForeignKey("dbo.GradeValue", "GradeTypeId", "dbo.Grade", "Id");
        }
    }
}

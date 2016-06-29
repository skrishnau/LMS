namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubjectGroup", "LevelId", "dbo.Level");
            DropForeignKey("dbo.SubjectGroup", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.SubjectGroup", "SchoolId", "dbo.School");
            DropIndex("dbo.SubjectGroup", new[] { "LevelId" });
            DropIndex("dbo.SubjectGroup", new[] { "FacultyId" });
            DropIndex("dbo.SubjectGroup", new[] { "SchoolId" });
            AddColumn("dbo.SubjectGroup", "SubYearId", c => c.Int());
            AddForeignKey("dbo.SubjectGroup", "SubYearId", "dbo.SubYear", "Id");
            CreateIndex("dbo.SubjectGroup", "SubYearId");
            DropColumn("dbo.SubjectGroup", "LevelId");
            DropColumn("dbo.SubjectGroup", "FacultyId");
            DropColumn("dbo.SubjectGroup", "SchoolId");
            DropColumn("dbo.SubjectGroup", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubjectGroup", "IsActive", c => c.Boolean());
            AddColumn("dbo.SubjectGroup", "SchoolId", c => c.Int(nullable: false));
            AddColumn("dbo.SubjectGroup", "FacultyId", c => c.Int());
            AddColumn("dbo.SubjectGroup", "LevelId", c => c.Int());
            DropIndex("dbo.SubjectGroup", new[] { "SubYearId" });
            DropForeignKey("dbo.SubjectGroup", "SubYearId", "dbo.SubYear");
            DropColumn("dbo.SubjectGroup", "SubYearId");
            CreateIndex("dbo.SubjectGroup", "SchoolId");
            CreateIndex("dbo.SubjectGroup", "FacultyId");
            CreateIndex("dbo.SubjectGroup", "LevelId");
            AddForeignKey("dbo.SubjectGroup", "SchoolId", "dbo.School", "Id");
            AddForeignKey("dbo.SubjectGroup", "FacultyId", "dbo.Faculty", "Id");
            AddForeignKey("dbo.SubjectGroup", "LevelId", "dbo.Level", "Id");
        }
    }
}

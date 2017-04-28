namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class level_and_faculty_removed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Program", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.Faculty", "LevelId", "dbo.Level");
            DropForeignKey("dbo.Level", "SchoolId", "dbo.School");
            DropIndex("dbo.Program", new[] { "FacultyId" });
            DropIndex("dbo.Faculty", new[] { "LevelId" });
            DropIndex("dbo.Level", new[] { "SchoolId" });
            AddColumn("dbo.Program", "SchoolId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Program", "SchoolId", "dbo.School", "Id");
            CreateIndex("dbo.Program", "SchoolId");
            DropColumn("dbo.Program", "FacultyId");
            DropTable("dbo.Faculty");
            DropTable("dbo.Level");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Level",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SchoolId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        LevelId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Program", "FacultyId", c => c.Int(nullable: false));
            DropIndex("dbo.Program", new[] { "SchoolId" });
            DropForeignKey("dbo.Program", "SchoolId", "dbo.School");
            DropColumn("dbo.Program", "SchoolId");
            CreateIndex("dbo.Level", "SchoolId");
            CreateIndex("dbo.Faculty", "LevelId");
            CreateIndex("dbo.Program", "FacultyId");
            AddForeignKey("dbo.Level", "SchoolId", "dbo.School", "Id");
            AddForeignKey("dbo.Faculty", "LevelId", "dbo.Level", "Id");
            AddForeignKey("dbo.Program", "FacultyId", "dbo.Faculty", "Id");
        }
    }
}

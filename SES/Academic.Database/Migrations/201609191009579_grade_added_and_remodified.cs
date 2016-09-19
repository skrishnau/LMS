namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grade_added_and_remodified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GradeType", "SchoolId", c => c.Int());
            AddForeignKey("dbo.GradeType", "SchoolId", "dbo.School", "Id");
            CreateIndex("dbo.GradeType", "SchoolId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.GradeType", new[] { "SchoolId" });
            DropForeignKey("dbo.GradeType", "SchoolId", "dbo.School");
            DropColumn("dbo.GradeType", "SchoolId");
        }
    }
}

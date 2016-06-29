namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no_idea : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegularSubjectsGrouping", "Program_Id", "dbo.Program");
            DropIndex("dbo.RegularSubjectsGrouping", new[] { "Program_Id" });
            AddColumn("dbo.SubjectGroup", "NoOfSubjects", c => c.Int(nullable: false));
            DropColumn("dbo.RegularSubjectsGrouping", "Program_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegularSubjectsGrouping", "Program_Id", c => c.Int());
            DropColumn("dbo.SubjectGroup", "NoOfSubjects");
            CreateIndex("dbo.RegularSubjectsGrouping", "Program_Id");
            AddForeignKey("dbo.RegularSubjectsGrouping", "Program_Id", "dbo.Program", "Id");
        }
    }
}

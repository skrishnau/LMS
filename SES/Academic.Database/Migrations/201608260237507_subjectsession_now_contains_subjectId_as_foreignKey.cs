namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subjectsession_now_contains_subjectId_as_foreignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectSessionUser", "Suspended", c => c.Boolean());
            AddForeignKey("dbo.SubjectSession", "SubjectId", "dbo.Subject", "Id");
            CreateIndex("dbo.SubjectSession", "SubjectId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SubjectSession", new[] { "SubjectId" });
            DropForeignKey("dbo.SubjectSession", "SubjectId", "dbo.Subject");
            DropColumn("dbo.SubjectSessionUser", "Suspended");
        }
    }
}

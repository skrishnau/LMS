namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restriction_added_in_section : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectSection", "RestrictionId", c => c.Int());
            AddForeignKey("dbo.SubjectSection", "RestrictionId", "dbo.Restriction", "Id");
            CreateIndex("dbo.SubjectSection", "RestrictionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SubjectSection", new[] { "RestrictionId" });
            DropForeignKey("dbo.SubjectSection", "RestrictionId", "dbo.Restriction");
            DropColumn("dbo.SubjectSection", "RestrictionId");
        }
    }
}

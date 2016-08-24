namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subjectSession_and_SubjectUserGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectUserGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            AddColumn("dbo.Subject", "ShortName", c => c.String());
            AddColumn("dbo.SubjectSessionUser", "SubjectUserGroupId", c => c.Int());
            AddColumn("dbo.SubjectSession", "UseDefaultGrouping", c => c.Boolean(nullable: false));
            AddForeignKey("dbo.SubjectSessionUser", "SubjectUserGroupId", "dbo.SubjectUserGroup", "Id");
            CreateIndex("dbo.SubjectSessionUser", "SubjectUserGroupId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SubjectUserGroup", new[] { "SubjectId" });
            DropIndex("dbo.SubjectSessionUser", new[] { "SubjectUserGroupId" });
            DropForeignKey("dbo.SubjectUserGroup", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectSessionUser", "SubjectUserGroupId", "dbo.SubjectUserGroup");
            DropColumn("dbo.SubjectSession", "UseDefaultGrouping");
            DropColumn("dbo.SubjectSessionUser", "SubjectUserGroupId");
            DropColumn("dbo.Subject", "ShortName");
            DropTable("dbo.SubjectUserGroup");
        }
    }
}

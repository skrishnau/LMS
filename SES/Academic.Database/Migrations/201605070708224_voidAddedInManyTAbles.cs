namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voidAddedInManyTAbles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Role", "Void", c => c.Boolean());
            AddColumn("dbo.UserType", "SchoolId", c => c.Int());
            AddColumn("dbo.UserType", "Void", c => c.Boolean());
            AddForeignKey("dbo.UserType", "SchoolId", "dbo.School", "Id");
            CreateIndex("dbo.UserType", "SchoolId");
            DropColumn("dbo.UserType", "InstitutionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserType", "InstitutionId", c => c.Int());
            DropIndex("dbo.UserType", new[] { "SchoolId" });
            DropForeignKey("dbo.UserType", "SchoolId", "dbo.School");
            DropColumn("dbo.UserType", "Void");
            DropColumn("dbo.UserType", "SchoolId");
            DropColumn("dbo.Role", "Void");
        }
    }
}

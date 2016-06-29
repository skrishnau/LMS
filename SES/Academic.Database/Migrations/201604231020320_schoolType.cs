namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schoolType : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SchoolType", "InstitutionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SchoolType", "InstitutionId", c => c.Int());
        }
    }
}

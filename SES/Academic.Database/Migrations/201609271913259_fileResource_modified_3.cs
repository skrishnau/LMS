namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fileResource_modified_3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserFile", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserFile", "SubjectId", c => c.Int());
        }
    }
}

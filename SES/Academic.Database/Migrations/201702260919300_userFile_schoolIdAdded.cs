namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userFile_schoolIdAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserFile", "SchoolId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserFile", "SchoolId");
        }
    }
}

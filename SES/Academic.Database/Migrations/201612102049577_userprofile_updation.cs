namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userprofile_updation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfileRestriction", "Constraint", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfileRestriction", "Constraint");
        }
    }
}

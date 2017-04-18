namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userFileUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserFile", "IsConstantAndNotEditable", c => c.Boolean());
            AlterColumn("dbo.UserFile", "CreatedBy", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserFile", "CreatedBy", c => c.Int(nullable: false));
            DropColumn("dbo.UserFile", "IsConstantAndNotEditable");
        }
    }
}

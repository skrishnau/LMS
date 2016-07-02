namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class security_que_ans_added_in_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "SecurityQuestion", c => c.String());
            AddColumn("dbo.Users", "SecurityAnswer", c => c.String());
            AlterColumn("dbo.Users", "SchoolId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "SchoolId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "SecurityAnswer");
            DropColumn("dbo.Users", "SecurityQuestion");
        }
    }
}

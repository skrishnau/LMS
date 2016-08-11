namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class middleName_in_Users_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "MiddleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "MiddleName");
        }
    }
}

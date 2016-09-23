namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class __overall : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BookChapter", "Position");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookChapter", "Position", c => c.Int(nullable: false));
        }
    }
}

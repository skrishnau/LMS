namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class choiceUser_created : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChoiceUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChoiceActivityId = c.Int(nullable: false),
                        ChoiceOptionsId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChoiceActivity", t => t.ChoiceActivityId)
                .ForeignKey("dbo.ChoiceOptions", t => t.ChoiceOptionsId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.ChoiceActivityId)
                .Index(t => t.ChoiceOptionsId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ChoiceUser", new[] { "UserId" });
            DropIndex("dbo.ChoiceUser", new[] { "ChoiceOptionsId" });
            DropIndex("dbo.ChoiceUser", new[] { "ChoiceActivityId" });
            DropForeignKey("dbo.ChoiceUser", "UserId", "dbo.Users");
            DropForeignKey("dbo.ChoiceUser", "ChoiceOptionsId", "dbo.ChoiceOptions");
            DropForeignKey("dbo.ChoiceUser", "ChoiceActivityId", "dbo.ChoiceActivity");
            DropTable("dbo.ChoiceUser");
        }
    }
}

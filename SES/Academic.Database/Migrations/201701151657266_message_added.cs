namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class message_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        SentDate = c.DateTime(nullable: false),
                        Viewed = c.Boolean(nullable: false),
                        ViewedDate = c.DateTime(),
                        VoidBySender = c.Boolean(),
                        VoidByReceiver = c.Boolean(),
                        RepliedToId = c.Int(),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Message", t => t.RepliedToId)
                .ForeignKey("dbo.Users", t => t.SenderId)
                .ForeignKey("dbo.Users", t => t.ReceiverId)
                .Index(t => t.RepliedToId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Message", new[] { "ReceiverId" });
            DropIndex("dbo.Message", new[] { "SenderId" });
            DropIndex("dbo.Message", new[] { "RepliedToId" });
            DropForeignKey("dbo.Message", "ReceiverId", "dbo.Users");
            DropForeignKey("dbo.Message", "SenderId", "dbo.Users");
            DropForeignKey("dbo.Message", "RepliedToId", "dbo.Message");
            DropTable("dbo.Message");
        }
    }
}

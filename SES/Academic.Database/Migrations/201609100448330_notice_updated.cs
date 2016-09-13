namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notice_updated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notice", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.NoticeFiles", "NoticeId", "dbo.Notice");
            DropForeignKey("dbo.NoticeTo", "NoticeId", "dbo.Notice");
            DropForeignKey("dbo.NoticeTo", "UserId", "dbo.Users");
            DropIndex("dbo.Notice", new[] { "CreatedById" });
            DropIndex("dbo.NoticeFiles", new[] { "NoticeId" });
            DropIndex("dbo.NoticeTo", new[] { "NoticeId" });
            DropIndex("dbo.NoticeTo", new[] { "UserId" });
            AddColumn("dbo.Exam", "NoticeContent", c => c.String());
            AddColumn("dbo.Exam", "NoticeId", c => c.Int());
            AddColumn("dbo.Notice", "Title", c => c.String());
            AddColumn("dbo.Notice", "Content", c => c.String());
            AddColumn("dbo.Notice", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.Notice", "UpdatedBy", c => c.Int());
            AddColumn("dbo.Notice", "NoticePublishTo", c => c.Boolean());
            AddColumn("dbo.Notice", "PublishNoticeToNoticeBoard", c => c.Boolean(nullable: false));
            AddColumn("dbo.Notice", "PublishedDate", c => c.DateTime());
            AlterColumn("dbo.Exam", "PublishNoticeToNoticeBoard", c => c.Boolean());
            AddForeignKey("dbo.Exam", "NoticeId", "dbo.Notice", "Id");
            CreateIndex("dbo.Exam", "NoticeId");
            DropColumn("dbo.Exam", "Notice");
            DropColumn("dbo.Notice", "Headiing");
            DropColumn("dbo.Notice", "Description");
            DropColumn("dbo.Notice", "CreatedById");
            DropColumn("dbo.Notice", "ViewerLimited");
            DropTable("dbo.NoticeFiles");
            DropTable("dbo.NoticeTo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NoticeTo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoticeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NoticeFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileId = c.Int(nullable: false),
                        NoticeId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Notice", "ViewerLimited", c => c.Boolean());
            AddColumn("dbo.Notice", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.Notice", "Description", c => c.String());
            AddColumn("dbo.Notice", "Headiing", c => c.String());
            AddColumn("dbo.Exam", "Notice", c => c.String());
            DropIndex("dbo.Exam", new[] { "NoticeId" });
            DropForeignKey("dbo.Exam", "NoticeId", "dbo.Notice");
            AlterColumn("dbo.Exam", "publishNoticeToNoticeBoard", c => c.Boolean());
            DropColumn("dbo.Notice", "PublishedDate");
            DropColumn("dbo.Notice", "PublishNoticeToNoticeBoard");
            DropColumn("dbo.Notice", "NoticePublishTo");
            DropColumn("dbo.Notice", "UpdatedBy");
            DropColumn("dbo.Notice", "CreatedBy");
            DropColumn("dbo.Notice", "Content");
            DropColumn("dbo.Notice", "Title");
            DropColumn("dbo.Exam", "NoticeId");
            DropColumn("dbo.Exam", "NoticeContent");
            CreateIndex("dbo.NoticeTo", "UserId");
            CreateIndex("dbo.NoticeTo", "NoticeId");
            CreateIndex("dbo.NoticeFiles", "NoticeId");
            CreateIndex("dbo.Notice", "CreatedById");
            AddForeignKey("dbo.NoticeTo", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.NoticeTo", "NoticeId", "dbo.Notice", "Id");
            AddForeignKey("dbo.NoticeFiles", "NoticeId", "dbo.Notice", "Id");
            AddForeignKey("dbo.Notice", "CreatedById", "dbo.Users", "Id");
        }
    }
}

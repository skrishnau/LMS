namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class award_removed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Award", "SchoolId", "dbo.School");
            DropIndex("dbo.Award", new[] { "SchoolId" });
            DropTable("dbo.Award");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Award",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolId = c.Int(nullable: false),
                        By = c.String(),
                        To = c.String(),
                        For = c.String(),
                        ReceivedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Award", "SchoolId");
            AddForeignKey("dbo.Award", "SchoolId", "dbo.School", "Id");
        }
    }
}

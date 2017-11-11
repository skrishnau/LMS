namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class report_table_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityResourceIds = c.String(),
                        SubjectClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .Index(t => t.SubjectClassId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Report", new[] { "SubjectClassId" });
            DropForeignKey("dbo.Report", "SubjectClassId", "dbo.SubjectClass");
            DropTable("dbo.Report");
        }
    }
}

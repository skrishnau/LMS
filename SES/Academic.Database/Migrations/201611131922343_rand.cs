namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rand : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramBatch", "CurrentYearId", "dbo.Year");
            DropForeignKey("dbo.ProgramBatch", "CurrentSubYearId", "dbo.SubYear");
            DropIndex("dbo.ProgramBatch", new[] { "CurrentYearId" });
            DropIndex("dbo.ProgramBatch", new[] { "CurrentSubYearId" });
            DropColumn("dbo.ProgramBatch", "CurrentYearId");
            DropColumn("dbo.ProgramBatch", "CurrentSubYearId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProgramBatch", "CurrentSubYearId", c => c.Int());
            AddColumn("dbo.ProgramBatch", "CurrentYearId", c => c.Int());
            CreateIndex("dbo.ProgramBatch", "CurrentSubYearId");
            CreateIndex("dbo.ProgramBatch", "CurrentYearId");
            AddForeignKey("dbo.ProgramBatch", "CurrentSubYearId", "dbo.SubYear", "Id");
            AddForeignKey("dbo.ProgramBatch", "CurrentYearId", "dbo.Year", "Id");
        }
    }
}

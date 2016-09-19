namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grade_table_new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GradeType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Type = c.String(),
                        GradeValueIsInPercentOrPostition = c.Boolean(),
                        TotalMaxValue = c.Single(),
                        TotalMinValue = c.Single(),
                        MinimumPassValue = c.Single(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GradeValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        IsFailGrade = c.Boolean(),
                        GradeTypeId = c.Int(nullable: false),
                        EquivalentPercentOrPostition = c.Single(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GradeType", t => t.GradeTypeId)
                .Index(t => t.GradeTypeId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.GradeValues", new[] { "GradeTypeId" });
            DropForeignKey("dbo.GradeValues", "GradeTypeId", "dbo.GradeType");
            DropTable("dbo.GradeValues");
            DropTable("dbo.GradeType");
        }
    }
}

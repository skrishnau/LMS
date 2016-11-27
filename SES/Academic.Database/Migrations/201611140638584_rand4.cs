namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rand4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.OtherAdmins", "AdminsId", "dbo.Admins");
            DropIndex("dbo.Admins", new[] { "AcademicYearId" });
            DropIndex("dbo.OtherAdmins", new[] { "AdminsId" });
            DropTable("dbo.Admins");
            DropTable("dbo.AdminTitle");
            DropTable("dbo.OtherAdmins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OtherAdmins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminsId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Position = c.String(),
                        Task = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdminTitle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcademicYearId = c.Int(nullable: false),
                        ChoosenDate = c.DateTime(nullable: false),
                        EstimatedEndTime = c.Byte(nullable: false),
                        CEOId = c.Int(nullable: false),
                        PrincipalId = c.Int(nullable: false),
                        AdministratorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.OtherAdmins", "AdminsId");
            CreateIndex("dbo.Admins", "AcademicYearId");
            AddForeignKey("dbo.OtherAdmins", "AdminsId", "dbo.Admins", "Id");
            AddForeignKey("dbo.Admins", "AcademicYearId", "dbo.AcademicYear", "Id");
        }
    }
}

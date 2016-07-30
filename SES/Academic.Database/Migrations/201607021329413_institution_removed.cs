namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class institution_removed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherJobTitle", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.Institution", "UserId", "dbo.Users");
            DropForeignKey("dbo.Award", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.Branch", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.UserAssociation", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAssociation", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.UserAssociation", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.UserAssociation", "SchoolId", "dbo.School");
            DropIndex("dbo.TeacherJobTitle", new[] { "InstitutionId" });
            DropIndex("dbo.Institution", new[] { "UserId" });
            DropIndex("dbo.Award", new[] { "InstitutionId" });
            DropIndex("dbo.Branch", new[] { "InstitutionId" });
            DropIndex("dbo.UserAssociation", new[] { "UserId" });
            DropIndex("dbo.UserAssociation", new[] { "InstitutionId" });
            DropIndex("dbo.UserAssociation", new[] { "BranchId" });
            DropIndex("dbo.UserAssociation", new[] { "SchoolId" });
            AddColumn("dbo.Award", "SchoolId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Award", "SchoolId", "dbo.School", "Id");
            CreateIndex("dbo.Award", "SchoolId");
            DropColumn("dbo.Award", "InstitutionId");
            DropTable("dbo.Institution");
            DropTable("dbo.Branch");
            DropTable("dbo.UserAssociation");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserAssociation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        InstitutionId = c.Int(nullable: false),
                        BranchId = c.Int(),
                        SchoolId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        PostalCode = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        InstitutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Institution",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        PostalCode = c.String(),
                        PanNo = c.String(),
                        Website = c.String(),
                        Email = c.String(),
                        Moto = c.String(),
                        Category = c.String(),
                        Logo = c.Binary(),
                        LogoImageType = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Award", "InstitutionId", c => c.Int(nullable: false));
            DropIndex("dbo.Award", new[] { "SchoolId" });
            DropForeignKey("dbo.Award", "SchoolId", "dbo.School");
            DropColumn("dbo.Award", "SchoolId");
            CreateIndex("dbo.UserAssociation", "SchoolId");
            CreateIndex("dbo.UserAssociation", "BranchId");
            CreateIndex("dbo.UserAssociation", "InstitutionId");
            CreateIndex("dbo.UserAssociation", "UserId");
            CreateIndex("dbo.Branch", "InstitutionId");
            CreateIndex("dbo.Award", "InstitutionId");
            CreateIndex("dbo.Institution", "UserId");
            CreateIndex("dbo.TeacherJobTitle", "InstitutionId");
            AddForeignKey("dbo.UserAssociation", "SchoolId", "dbo.School", "Id");
            AddForeignKey("dbo.UserAssociation", "BranchId", "dbo.Branch", "Id");
            AddForeignKey("dbo.UserAssociation", "InstitutionId", "dbo.Institution", "Id");
            AddForeignKey("dbo.UserAssociation", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Branch", "InstitutionId", "dbo.Institution", "Id");
            AddForeignKey("dbo.Award", "InstitutionId", "dbo.Institution", "Id");
            AddForeignKey("dbo.Institution", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.TeacherJobTitle", "InstitutionId", "dbo.Institution", "Id");
        }
    }
}

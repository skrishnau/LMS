namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class file_renamed_to_userfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserImageId", "dbo.File");
            DropForeignKey("dbo.File", "OwnerId", "dbo.Teacher");
            DropForeignKey("dbo.File", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Resource", "StudentFile_Id", "dbo.File");
            DropForeignKey("dbo.ResourceResourceFile", "ResourceFile_Id", "dbo.File");
            DropIndex("dbo.Users", new[] { "UserImageId" });
            DropIndex("dbo.File", new[] { "OwnerId" });
            DropIndex("dbo.File", new[] { "StudentId" });
            DropIndex("dbo.Resource", new[] { "StudentFile_Id" });
            DropIndex("dbo.ResourceResourceFile", new[] { "ResourceFile_Id" });
            CreateTable(
                "dbo.UserFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        FileName = c.String(),
                        FileDirectory = c.String(),
                        FileSizeInBytes = c.Long(nullable: false),
                        FileType = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        Void = c.Boolean(),
                        SubjectId = c.Int(),
                        OwnerId = c.Int(),
                        StudentId = c.Int(),
                        RequiresPassword = c.Boolean(),
                        Password = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teacher", t => t.OwnerId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.OwnerId)
                .Index(t => t.StudentId);
            
            AddForeignKey("dbo.Users", "UserImageId", "dbo.UserFile", "Id");
            AddForeignKey("dbo.Resource", "StudentFile_Id", "dbo.UserFile", "Id");
            AddForeignKey("dbo.ResourceResourceFile", "ResourceFile_Id", "dbo.UserFile", "Id", cascadeDelete: true);
            CreateIndex("dbo.Users", "UserImageId");
            CreateIndex("dbo.Resource", "StudentFile_Id");
            CreateIndex("dbo.ResourceResourceFile", "ResourceFile_Id");
            DropTable("dbo.File");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.File",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        FileName = c.String(),
                        FileDirectory = c.String(),
                        FileSizeInBytes = c.Long(nullable: false),
                        FileType = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        Void = c.Boolean(),
                        SubjectId = c.Int(),
                        OwnerId = c.Int(),
                        StudentId = c.Int(),
                        RequiresPassword = c.Boolean(),
                        Password = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.ResourceResourceFile", new[] { "ResourceFile_Id" });
            DropIndex("dbo.Resource", new[] { "StudentFile_Id" });
            DropIndex("dbo.UserFile", new[] { "StudentId" });
            DropIndex("dbo.UserFile", new[] { "OwnerId" });
            DropIndex("dbo.Users", new[] { "UserImageId" });
            DropForeignKey("dbo.ResourceResourceFile", "ResourceFile_Id", "dbo.UserFile");
            DropForeignKey("dbo.Resource", "StudentFile_Id", "dbo.UserFile");
            DropForeignKey("dbo.UserFile", "StudentId", "dbo.Student");
            DropForeignKey("dbo.UserFile", "OwnerId", "dbo.Teacher");
            DropForeignKey("dbo.Users", "UserImageId", "dbo.UserFile");
            DropTable("dbo.UserFile");
            CreateIndex("dbo.ResourceResourceFile", "ResourceFile_Id");
            CreateIndex("dbo.Resource", "StudentFile_Id");
            CreateIndex("dbo.File", "StudentId");
            CreateIndex("dbo.File", "OwnerId");
            CreateIndex("dbo.Users", "UserImageId");
            AddForeignKey("dbo.ResourceResourceFile", "ResourceFile_Id", "dbo.File", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Resource", "StudentFile_Id", "dbo.File", "Id");
            AddForeignKey("dbo.File", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.File", "OwnerId", "dbo.Teacher", "Id");
            AddForeignKey("dbo.Users", "UserImageId", "dbo.File", "Id");
        }
    }
}

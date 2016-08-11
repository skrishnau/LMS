namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_table_image_now_saved_as_file : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResourceFile", "OwnerId", "dbo.Teacher");
            DropForeignKey("dbo.Resource", "StudentFile_Id", "dbo.StudentFile");
            DropForeignKey("dbo.StudentFile", "StudentId", "dbo.Student");
            DropForeignKey("dbo.ResourceResourceFile", "ResourceFile_Id", "dbo.ResourceFile");
            DropIndex("dbo.ResourceFile", new[] { "OwnerId" });
            DropIndex("dbo.Resource", new[] { "StudentFile_Id" });
            DropIndex("dbo.StudentFile", new[] { "StudentId" });
            DropIndex("dbo.ResourceResourceFile", new[] { "ResourceFile_Id" });
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
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        Void = c.Boolean(nullable: false),
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
            
            AddColumn("dbo.Users", "UserImageId", c => c.Int());
            AddForeignKey("dbo.Users", "UserImageId", "dbo.File", "Id");
            AddForeignKey("dbo.Resource", "StudentFile_Id", "dbo.File", "Id");
            AddForeignKey("dbo.ResourceResourceFile", "ResourceFile_Id", "dbo.File", "Id", cascadeDelete: true);
            CreateIndex("dbo.Users", "UserImageId");
            CreateIndex("dbo.Resource", "StudentFile_Id");
            CreateIndex("dbo.ResourceResourceFile", "ResourceFile_Id");
            DropColumn("dbo.Users", "Image");
            DropColumn("dbo.Users", "ImageType");
            DropTable("dbo.ResourceFile");
            DropTable("dbo.Photo");
            DropTable("dbo.StudentFile");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        RequiresPassword = c.Boolean(nullable: false),
                        Password = c.String(),
                        DisplayName = c.String(),
                        FileName = c.String(),
                        FileDirectory = c.String(),
                        FileSizeInBytes = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        Void = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        FileName = c.String(),
                        FileDirectory = c.String(),
                        FileSizeInBytes = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        Void = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResourceFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(),
                        OwnerId = c.Int(nullable: false),
                        DisplayName = c.String(),
                        FileName = c.String(),
                        FileDirectory = c.String(),
                        FileSizeInBytes = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        Void = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "ImageType", c => c.String());
            AddColumn("dbo.Users", "Image", c => c.Binary());
            DropIndex("dbo.ResourceResourceFile", new[] { "ResourceFile_Id" });
            DropIndex("dbo.Resource", new[] { "StudentFile_Id" });
            DropIndex("dbo.File", new[] { "StudentId" });
            DropIndex("dbo.File", new[] { "OwnerId" });
            DropIndex("dbo.Users", new[] { "UserImageId" });
            DropForeignKey("dbo.ResourceResourceFile", "ResourceFile_Id", "dbo.File");
            DropForeignKey("dbo.Resource", "StudentFile_Id", "dbo.File");
            DropForeignKey("dbo.File", "StudentId", "dbo.Student");
            DropForeignKey("dbo.File", "OwnerId", "dbo.Teacher");
            DropForeignKey("dbo.Users", "UserImageId", "dbo.File");
            DropColumn("dbo.Users", "UserImageId");
            DropTable("dbo.File");
            CreateIndex("dbo.ResourceResourceFile", "ResourceFile_Id");
            CreateIndex("dbo.StudentFile", "StudentId");
            CreateIndex("dbo.Resource", "StudentFile_Id");
            CreateIndex("dbo.ResourceFile", "OwnerId");
            AddForeignKey("dbo.ResourceResourceFile", "ResourceFile_Id", "dbo.ResourceFile", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentFile", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.Resource", "StudentFile_Id", "dbo.StudentFile", "Id");
            AddForeignKey("dbo.ResourceFile", "OwnerId", "dbo.Teacher", "Id");
        }
    }
}

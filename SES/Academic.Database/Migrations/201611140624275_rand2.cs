namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rand2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Book", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Book", "BookCategory_Id", "dbo.BookCategory");
            DropForeignKey("dbo.Book", "BookCategoryId", "dbo.BookCategory");
            DropForeignKey("dbo.Book", "BookReturnCategoryId", "dbo.BookReturnCategory");
            DropForeignKey("dbo.Book", "LibraryId", "dbo.Library");
            DropForeignKey("dbo.BookCategory", "LibraryId", "dbo.Library");
            DropForeignKey("dbo.BookCategory", "Book_Id", "dbo.Book");
            DropForeignKey("dbo.BookReturnCategory", "LibraryId", "dbo.Library");
            DropForeignKey("dbo.BookAuthor", "BookId", "dbo.Book");
            DropForeignKey("dbo.Issue", "BookId", "dbo.Book");
            DropForeignKey("dbo.Issue", "StudentId", "dbo.Student");
            DropForeignKey("dbo.MemberShip", "MembershipTypeId", "dbo.MembershipType");
            DropForeignKey("dbo.Return", "issueId", "dbo.Issue");
            DropIndex("dbo.Book", new[] { "SubjectId" });
            DropIndex("dbo.Book", new[] { "BookCategory_Id" });
            DropIndex("dbo.Book", new[] { "BookCategoryId" });
            DropIndex("dbo.Book", new[] { "BookReturnCategoryId" });
            DropIndex("dbo.Book", new[] { "LibraryId" });
            DropIndex("dbo.BookCategory", new[] { "LibraryId" });
            DropIndex("dbo.BookCategory", new[] { "Book_Id" });
            DropIndex("dbo.BookReturnCategory", new[] { "LibraryId" });
            DropIndex("dbo.BookAuthor", new[] { "BookId" });
            DropIndex("dbo.Issue", new[] { "BookId" });
            DropIndex("dbo.Issue", new[] { "StudentId" });
            DropIndex("dbo.MemberShip", new[] { "MembershipTypeId" });
            DropIndex("dbo.Return", new[] { "issueId" });
            DropTable("dbo.Book");
            DropTable("dbo.BookCategory");
            DropTable("dbo.Library");
            DropTable("dbo.BookReturnCategory");
            DropTable("dbo.BookAuthor");
            DropTable("dbo.Issue");
            DropTable("dbo.MemberShip");
            DropTable("dbo.MembershipType");
            DropTable("dbo.Return");
            DropTable("dbo.UsefulnessCategory");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsefulnessCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Return",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        issueId = c.Int(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        IsFine = c.Boolean(nullable: false),
                        Amount = c.Single(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MembershipType",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        LibraryId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MemberShip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LibraryId = c.Int(nullable: false),
                        UserTypeId = c.Byte(nullable: false),
                        UserId = c.Int(nullable: false),
                        MembershipDate = c.DateTime(nullable: false),
                        ValidUpto = c.DateTime(nullable: false),
                        MembershipCharge = c.Single(nullable: false),
                        Void = c.Boolean(nullable: false),
                        MembershipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Issue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        ReturnDueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookAuthor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        AssociatedUniversity = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookReturnCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LibraryId = c.Int(nullable: false),
                        ReturnYears = c.Byte(nullable: false),
                        ReturnMonths = c.Byte(nullable: false),
                        ReturnDays = c.Short(nullable: false),
                        FinePerMonth = c.Single(nullable: false),
                        FinePerWeek = c.Single(nullable: false),
                        FinePerDay = c.Single(nullable: false),
                        FinePerHour = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Library",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolId = c.Int(nullable: false),
                        Name = c.String(),
                        Location = c.String(),
                        Telephone = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ChiefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        LibraryId = c.Int(nullable: false),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Publication = c.String(),
                        ISBN = c.String(),
                        IsTextBook = c.String(),
                        SubjectId = c.Int(nullable: false),
                        LibraryId = c.Int(nullable: false),
                        CustomSerialNumber = c.String(),
                        Edition = c.String(),
                        BookCategoryId = c.Int(nullable: false),
                        BookReturnCategoryId = c.Int(nullable: false),
                        CategoryOfUsefulness = c.String(),
                        Price = c.Single(nullable: false),
                        Void = c.Boolean(nullable: false),
                        BookCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Return", "issueId");
            CreateIndex("dbo.MemberShip", "MembershipTypeId");
            CreateIndex("dbo.Issue", "StudentId");
            CreateIndex("dbo.Issue", "BookId");
            CreateIndex("dbo.BookAuthor", "BookId");
            CreateIndex("dbo.BookReturnCategory", "LibraryId");
            CreateIndex("dbo.BookCategory", "Book_Id");
            CreateIndex("dbo.BookCategory", "LibraryId");
            CreateIndex("dbo.Book", "LibraryId");
            CreateIndex("dbo.Book", "BookReturnCategoryId");
            CreateIndex("dbo.Book", "BookCategoryId");
            CreateIndex("dbo.Book", "BookCategory_Id");
            CreateIndex("dbo.Book", "SubjectId");
            AddForeignKey("dbo.Return", "issueId", "dbo.Issue", "Id");
            AddForeignKey("dbo.MemberShip", "MembershipTypeId", "dbo.MembershipType", "id");
            AddForeignKey("dbo.Issue", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.Issue", "BookId", "dbo.Book", "Id");
            AddForeignKey("dbo.BookAuthor", "BookId", "dbo.Book", "Id");
            AddForeignKey("dbo.BookReturnCategory", "LibraryId", "dbo.Library", "Id");
            AddForeignKey("dbo.BookCategory", "Book_Id", "dbo.Book", "Id");
            AddForeignKey("dbo.BookCategory", "LibraryId", "dbo.Library", "Id");
            AddForeignKey("dbo.Book", "LibraryId", "dbo.Library", "Id");
            AddForeignKey("dbo.Book", "BookReturnCategoryId", "dbo.BookReturnCategory", "Id");
            AddForeignKey("dbo.Book", "BookCategoryId", "dbo.BookCategory", "Id");
            AddForeignKey("dbo.Book", "BookCategory_Id", "dbo.BookCategory", "Id");
            AddForeignKey("dbo.Book", "SubjectId", "dbo.Subject", "Id");
        }
    }
}

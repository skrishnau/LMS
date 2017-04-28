namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rand8 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AccessPermission");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AccessPermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Read = c.Boolean(nullable: false),
                        ReadWrite = c.Boolean(nullable: false),
                        Write = c.Boolean(nullable: false),
                        Append = c.Boolean(nullable: false),
                        IsGlobal = c.Boolean(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        IsPrivate = c.Boolean(nullable: false),
                        IsAssignable = c.Boolean(nullable: false),
                        IsSearchable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

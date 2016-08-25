namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleName_added_in_role_table_also_roleId_isNull_in_sessionUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Role", "DisplayName", c => c.String(nullable: false));
            AddColumn("dbo.Role", "RoleName", c => c.String(nullable: false));
            AlterColumn("dbo.SubjectSessionUser", "RoleId", c => c.Int());
            DropColumn("dbo.Role", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Role", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.SubjectSessionUser", "RoleId", c => c.Int(nullable: false));
            DropColumn("dbo.Role", "RoleName");
            DropColumn("dbo.Role", "DisplayName");
        }
    }
}

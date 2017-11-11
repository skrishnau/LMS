namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class report_table_updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Report", "ShowImage", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "ShowName", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "ShowCRN", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "ShowTotal", c => c.Boolean(nullable: false));
            AddColumn("dbo.Report", "ShowActivityResourceIds", c => c.String());
            DropColumn("dbo.Report", "ActivityResourceIds");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Report", "ActivityResourceIds", c => c.String());
            DropColumn("dbo.Report", "ShowActivityResourceIds");
            DropColumn("dbo.Report", "ShowTotal");
            DropColumn("dbo.Report", "ShowCRN");
            DropColumn("dbo.Report", "ShowName");
            DropColumn("dbo.Report", "ShowImage");
        }
    }
}

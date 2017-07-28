namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schoolInfoUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.School", "Description", c => c.String());
            AddColumn("dbo.School", "Address", c => c.String());
            AddColumn("dbo.School", "PhoneMain", c => c.String());
            AddColumn("dbo.School", "PhoneAfterHours", c => c.String());
            AddColumn("dbo.School", "EmailGeneral", c => c.String());
            AddColumn("dbo.School", "EmailSupport", c => c.String());
            AddColumn("dbo.School", "EmailMarketing", c => c.String());
            DropColumn("dbo.School", "Country");
            DropColumn("dbo.School", "City");
            DropColumn("dbo.School", "Street");
            DropColumn("dbo.School", "Phone");
            DropColumn("dbo.School", "RegNo");
            DropColumn("dbo.School", "Fax");
            DropColumn("dbo.School", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.School", "Email", c => c.String());
            AddColumn("dbo.School", "Fax", c => c.String());
            AddColumn("dbo.School", "RegNo", c => c.String());
            AddColumn("dbo.School", "Phone", c => c.String());
            AddColumn("dbo.School", "Street", c => c.String());
            AddColumn("dbo.School", "City", c => c.String());
            AddColumn("dbo.School", "Country", c => c.String());
            DropColumn("dbo.School", "EmailMarketing");
            DropColumn("dbo.School", "EmailSupport");
            DropColumn("dbo.School", "EmailGeneral");
            DropColumn("dbo.School", "PhoneAfterHours");
            DropColumn("dbo.School", "PhoneMain");
            DropColumn("dbo.School", "Address");
            DropColumn("dbo.School", "Description");
        }
    }
}

namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gradeTpe_column_renamed_to_RangeOrValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grade", "RangeOrValue", c => c.Boolean(nullable: false));
            DropColumn("dbo.Grade", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grade", "Type", c => c.String());
            DropColumn("dbo.Grade", "RangeOrValue");
        }
    }
}

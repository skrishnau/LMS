namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no_idea4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ActivityGrading", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.ActivityGrading", "ModifiedById", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ActivityGrading", "ModifiedById", c => c.Int(nullable: false));
            AlterColumn("dbo.ActivityGrading", "ModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}

namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weight_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityResource", "WeightInGradeSheet", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActivityResource", "WeightInGradeSheet");
        }
    }
}

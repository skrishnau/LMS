namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class position_added_to_choice_option_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChoiceOptions", "Position", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChoiceOptions", "Position");
        }
    }
}

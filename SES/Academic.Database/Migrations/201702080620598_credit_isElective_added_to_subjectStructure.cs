namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class credit_isElective_added_to_subjectStructure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectStructure", "IsElective", c => c.Boolean(nullable: false));
            AddColumn("dbo.SubjectStructure", "Credit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubjectStructure", "Credit");
            DropColumn("dbo.SubjectStructure", "IsElective");
        }
    }
}

namespace CollegeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileTableImprovementIndicator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImprovementIndicators", "File", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImprovementIndicators", "File");
        }
    }
}

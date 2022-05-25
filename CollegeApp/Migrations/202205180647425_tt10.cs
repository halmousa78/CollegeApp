namespace CollegeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt10 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ImprovementIndicators");
            AddColumn("dbo.ImprovementIndicators", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ImprovementIndicators", "Id");
            DropColumn("dbo.ImprovementIndicators", "ImprovementIndicatorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImprovementIndicators", "ImprovementIndicatorId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ImprovementIndicators");
            DropColumn("dbo.ImprovementIndicators", "Id");
            AddPrimaryKey("dbo.ImprovementIndicators", "ImprovementIndicatorId");
        }
    }
}

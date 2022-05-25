namespace CollegeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt11 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ImprovementIndicators");
            DropColumn("dbo.ImprovementIndicators", "Id");
            AddColumn("dbo.ImprovementIndicators", "ImprovementIndicatorId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ImprovementIndicators", "ImprovementIndicatorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImprovementIndicators", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ImprovementIndicators");
            DropColumn("dbo.ImprovementIndicators", "ImprovementIndicatorId");
            AddPrimaryKey("dbo.ImprovementIndicators", "Id");
        }
    }
}

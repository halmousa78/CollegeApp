namespace CollegeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ImprovementIndicators");
            AlterColumn("dbo.ImprovementIndicators", "ImprovementIndicatorId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ImprovementIndicators", "ImprovementIndicatorId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ImprovementIndicators");
            AlterColumn("dbo.ImprovementIndicators", "ImprovementIndicatorId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ImprovementIndicators", "ImprovementIndicatorId");
        }
    }
}

namespace CollegeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFieldToTrainingGuideTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingGuides", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainingGuides", "Status");
        }
    }
}

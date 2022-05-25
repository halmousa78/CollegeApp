namespace CollegeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects");
            DropPrimaryKey("dbo.Subjects");
            AddColumn("dbo.Subjects", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Subjects", "Id");
            AddForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            DropColumn("dbo.Subjects", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "SubjectId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects");
            DropPrimaryKey("dbo.Subjects");
            DropColumn("dbo.Subjects", "Id");
            AddPrimaryKey("dbo.Subjects", "SubjectId");
            AddForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
        }
    }
}

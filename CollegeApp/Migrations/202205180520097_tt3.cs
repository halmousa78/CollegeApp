namespace CollegeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.ImprovementIndicators", new[] { "SubjectId" });
            DropPrimaryKey("dbo.Subjects");
            AlterColumn("dbo.ImprovementIndicators", "SubjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Subjects", "SubjectId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Subjects", "SubjectId");
            CreateIndex("dbo.ImprovementIndicators", "SubjectId");
            AddForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.ImprovementIndicators", new[] { "SubjectId" });
            DropPrimaryKey("dbo.Subjects");
            AlterColumn("dbo.Subjects", "SubjectId", c => c.Double(nullable: false));
            AlterColumn("dbo.ImprovementIndicators", "SubjectId", c => c.Double(nullable: false));
            AddPrimaryKey("dbo.Subjects", "SubjectId");
            CreateIndex("dbo.ImprovementIndicators", "SubjectId");
            AddForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
        }
    }
}

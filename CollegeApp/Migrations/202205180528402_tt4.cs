namespace CollegeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.ImprovementIndicators", new[] { "SubjectId" });
            DropPrimaryKey("dbo.Subjects");
            AddColumn("dbo.ImprovementIndicators", "Subject_SubjectId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Subjects", "SubjectId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Subjects", "SubjectId");
            CreateIndex("dbo.ImprovementIndicators", "Subject_SubjectId");
            AddForeignKey("dbo.ImprovementIndicators", "Subject_SubjectId", "dbo.Subjects", "SubjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImprovementIndicators", "Subject_SubjectId", "dbo.Subjects");
            DropIndex("dbo.ImprovementIndicators", new[] { "Subject_SubjectId" });
            DropPrimaryKey("dbo.Subjects");
            AlterColumn("dbo.Subjects", "SubjectId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.ImprovementIndicators", "Subject_SubjectId");
            AddPrimaryKey("dbo.Subjects", "SubjectId");
            CreateIndex("dbo.ImprovementIndicators", "SubjectId");
            AddForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
        }
    }
}

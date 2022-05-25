namespace CollegeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImprovementIndicators", "Subject_SubjectId", "dbo.Subjects");
            DropIndex("dbo.ImprovementIndicators", new[] { "Subject_SubjectId" });
            RenameColumn(table: "dbo.ImprovementIndicators", name: "Subject_SubjectId", newName: "SubjectId");
            DropPrimaryKey("dbo.ImprovementIndicators");
            AlterColumn("dbo.ImprovementIndicators", "ImprovementIndicatorId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ImprovementIndicators", "SubjectId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ImprovementIndicators", "ImprovementIndicatorId");
            CreateIndex("dbo.ImprovementIndicators", "SubjectId");
            AddForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
            DropColumn("dbo.ImprovementIndicators", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImprovementIndicators", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.ImprovementIndicators", new[] { "SubjectId" });
            DropPrimaryKey("dbo.ImprovementIndicators");
            AlterColumn("dbo.ImprovementIndicators", "SubjectId", c => c.Int());
            AlterColumn("dbo.ImprovementIndicators", "ImprovementIndicatorId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ImprovementIndicators", "Id");
            RenameColumn(table: "dbo.ImprovementIndicators", name: "SubjectId", newName: "Subject_SubjectId");
            CreateIndex("dbo.ImprovementIndicators", "Subject_SubjectId");
            AddForeignKey("dbo.ImprovementIndicators", "Subject_SubjectId", "dbo.Subjects", "SubjectId");
        }
    }
}

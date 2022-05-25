namespace CollegeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImprovementIndicators", "Subject_SubjectId", "dbo.Subjects");
            DropIndex("dbo.ImprovementIndicators", new[] { "Subject_SubjectId" });
            DropColumn("dbo.ImprovementIndicators", "SubjectId");
            RenameColumn(table: "dbo.ImprovementIndicators", name: "Subject_SubjectId", newName: "SubjectId");
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
            AlterColumn("dbo.Subjects", "SubjectId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ImprovementIndicators", "SubjectId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Subjects", "SubjectId");
            RenameColumn(table: "dbo.ImprovementIndicators", name: "SubjectId", newName: "Subject_SubjectId");
            AddColumn("dbo.ImprovementIndicators", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.ImprovementIndicators", "Subject_SubjectId");
            AddForeignKey("dbo.ImprovementIndicators", "Subject_SubjectId", "dbo.Subjects", "SubjectId");
        }
    }
}

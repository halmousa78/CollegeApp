namespace CollegeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.ImprovementIndicators", new[] { "SubjectId" });
            RenameColumn(table: "dbo.ImprovementIndicators", name: "SubjectId", newName: "Subject_Id");
            DropPrimaryKey("dbo.ImprovementIndicators");
            AddColumn("dbo.ImprovementIndicators", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ImprovementIndicators", "ImprovementIndicatorId", c => c.Int(nullable: false));
            AlterColumn("dbo.ImprovementIndicators", "Subject_Id", c => c.Int());
            AddPrimaryKey("dbo.ImprovementIndicators", "Id");
            CreateIndex("dbo.ImprovementIndicators", "Subject_Id");
            AddForeignKey("dbo.ImprovementIndicators", "Subject_Id", "dbo.Subjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImprovementIndicators", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.ImprovementIndicators", new[] { "Subject_Id" });
            DropPrimaryKey("dbo.ImprovementIndicators");
            AlterColumn("dbo.ImprovementIndicators", "Subject_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ImprovementIndicators", "ImprovementIndicatorId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.ImprovementIndicators", "Id");
            AddPrimaryKey("dbo.ImprovementIndicators", "ImprovementIndicatorId");
            RenameColumn(table: "dbo.ImprovementIndicators", name: "Subject_Id", newName: "SubjectId");
            CreateIndex("dbo.ImprovementIndicators", "SubjectId");
            AddForeignKey("dbo.ImprovementIndicators", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
    }
}

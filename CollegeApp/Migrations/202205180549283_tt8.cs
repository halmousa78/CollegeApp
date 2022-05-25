namespace CollegeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImprovementIndicators", "Subject_Id", "dbo.Subjects");
            RenameColumn(table: "dbo.ImprovementIndicators", name: "Subject_Id", newName: "Subject_SubjectId");
            RenameIndex(table: "dbo.ImprovementIndicators", name: "IX_Subject_Id", newName: "IX_Subject_SubjectId");
            DropPrimaryKey("dbo.Subjects");
            DropColumn("dbo.Subjects", "Id");
            AddColumn("dbo.Subjects", "SubjectId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Subjects", "SubjectId");
            AddForeignKey("dbo.ImprovementIndicators", "Subject_SubjectId", "dbo.Subjects", "SubjectId");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ImprovementIndicators", "Subject_SubjectId", "dbo.Subjects");
            DropPrimaryKey("dbo.Subjects");
            DropColumn("dbo.Subjects", "SubjectId");
            AddPrimaryKey("dbo.Subjects", "Id");
            RenameIndex(table: "dbo.ImprovementIndicators", name: "IX_Subject_SubjectId", newName: "IX_Subject_Id");
            RenameColumn(table: "dbo.ImprovementIndicators", name: "Subject_SubjectId", newName: "Subject_Id");
            AddForeignKey("dbo.ImprovementIndicators", "Subject_Id", "dbo.Subjects", "Id");
        }
    }
}

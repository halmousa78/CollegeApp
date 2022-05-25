namespace CollegeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImprovementIndicators", "ImprovementIndicatorSubjectId", "dbo.ImprovementIndicatorSubjects");
            DropForeignKey("dbo.Subjects", "InitiativeScopeId", "dbo.InitiativeScopes");
            DropIndex("dbo.ImprovementIndicators", new[] { "ImprovementIndicatorSubjectId" });
            DropIndex("dbo.Subjects", new[] { "InitiativeScopeId" });
            AddColumn("dbo.ImprovementIndicators", "InitiativeScopeId", c => c.Int(nullable: false));
            AddColumn("dbo.Subjects", "ImprovementIndicatorSubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.ImprovementIndicators", "InitiativeScopeId");
            CreateIndex("dbo.Subjects", "ImprovementIndicatorSubjectId");
            AddForeignKey("dbo.ImprovementIndicators", "InitiativeScopeId", "dbo.InitiativeScopes", "InitiativeScopeId", cascadeDelete: true);
            AddForeignKey("dbo.Subjects", "ImprovementIndicatorSubjectId", "dbo.ImprovementIndicatorSubjects", "ImprovementIndicatorSubjectId", cascadeDelete: true);
            DropColumn("dbo.ImprovementIndicators", "ImprovementIndicatorSubjectId");
            DropColumn("dbo.Subjects", "InitiativeScopeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "InitiativeScopeId", c => c.Int(nullable: false));
            AddColumn("dbo.ImprovementIndicators", "ImprovementIndicatorSubjectId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Subjects", "ImprovementIndicatorSubjectId", "dbo.ImprovementIndicatorSubjects");
            DropForeignKey("dbo.ImprovementIndicators", "InitiativeScopeId", "dbo.InitiativeScopes");
            DropIndex("dbo.Subjects", new[] { "ImprovementIndicatorSubjectId" });
            DropIndex("dbo.ImprovementIndicators", new[] { "InitiativeScopeId" });
            DropColumn("dbo.Subjects", "ImprovementIndicatorSubjectId");
            DropColumn("dbo.ImprovementIndicators", "InitiativeScopeId");
            CreateIndex("dbo.Subjects", "InitiativeScopeId");
            CreateIndex("dbo.ImprovementIndicators", "ImprovementIndicatorSubjectId");
            AddForeignKey("dbo.Subjects", "InitiativeScopeId", "dbo.InitiativeScopes", "InitiativeScopeId", cascadeDelete: true);
            AddForeignKey("dbo.ImprovementIndicators", "ImprovementIndicatorSubjectId", "dbo.ImprovementIndicatorSubjects", "ImprovementIndicatorSubjectId", cascadeDelete: true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CollegeApp.Data
{
    public class MyDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MyDbContext() : base("name=MyDbContext")
        {
        }





        public System.Data.Entity.DbSet<CollegeApp.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.UserView> UserViews { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.UserViewRole> UserViewRoles { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.TrainingType> TrainingTypes { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Grade> Grades { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Major> Majors { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.ProgramType> ProgramTypes { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Section> Sections { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Term> Terms { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.PlansStudy> PlansStudies { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Grade01> Grade01 { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Grade02> Grade02 { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Grade03> Grade03 { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Grade04> Grade04 { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Grade05> Grade05 { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Grade06> Grade06 { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Cvs.Award> Awards { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Cvs.Experince> Experinces { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Cvs.Qualification> Qualifications { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Cvs.TrainingCourse> TrainingCourses { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.DepartmentType> DepartmentTypes { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.plan.Standard> Standards { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.plan.Initiative> Initiatives { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Account.TraineeUser> TraineeUsers { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.Note.Note> Notes { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.TrainingGuide.TrainingGuide> TrainingGuides { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.TrainingGuide.RemainingCoursesTrainee> RemainingCoursesTrainees { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.ImprovementIndicator.Subject> Subjects { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.ImprovementIndicator.ImprovementIndicator> ImprovementIndicators { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.ImprovementIndicator.ImprovementIndicatorSubject> ImprovementIndicatorSubjects { get; set; }

        public System.Data.Entity.DbSet<CollegeApp.Models.ImprovementIndicator.InitiativeScope> InitiativeScopes { get; set; }
    }
}

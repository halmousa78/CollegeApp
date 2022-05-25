using CollegeApp.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.TrainingGuide
{
    public class RemainingCoursesTrainee
    {
        [Display(Name = "رقم")]
        public int RemainingCoursesTraineeId { get; set; }
        [Display(Name = "اسم القسم")]
        public string DepartmentName { get; set; }
        [Display(Name = "اسم التخصص")]
        public string MajorName { get; set; }
        [Display(Name = "رقم المتدرب ")]
        public int TraineeUserId { get; set; }
        [Display(Name = "اسم المتدرب ")]
        public string TraineeName { get; set; }
        [Display(Name = "المعدل التراكمي")]
        public double GPA { get; set; }
        [Display(Name = "رقم المقرر")]
        public string CourseId { get; set; }
        [Display(Name = "اسم المقرر")]
        public string CourseName { get; set; }
        //دبلوم او بكالريوس
        [Display(Name = "اسم نوع التدريب")]
        public string TrainingTypeName { get; set; }

    }
}
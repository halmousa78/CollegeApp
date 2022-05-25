using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.TrainingGuide
{
    public class TrainingGuide
    {
        [Display(Name = "رقم")]
        public int TrainingGuideId { get; set; }
        [Display(Name = "رقم الفصل التدريبي")]
        public int TermId { get; set; }
        public Term Term { get; set; }
        [Display(Name = "رقم التخصص")]
        public int MajorId { get; set; }
        public Major Major { get; set; }
        [Display(Name = "رقم المدرب")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Display(Name = "اسم المتدرب ")]
        public string TraineeName { get; set; }
        [Display(Name = "رقم المتدرب ")]
        public int TraineeNumber { get; set; }
        public int ProgramTypeId { get; set; }
        public ProgramType ProgramType { get; set; }
        [Display(Name = "مناقشة تسجيل المقررات حسب الخطة التدريبية ")]
        public bool RegistrationOfCoursesAccordingToTheTrainingPlan { get; set; }
        [Display(Name = "مناقشة المستوى التدريبي ")]
        public bool TrainingLevel { get; set; }
        [Display(Name = "شرح الخطة التدريبية")]
        public bool ExplanationOfTheTrainingPlan { get; set; }
        [Display(Name = "مناقشة مستوى المعدل التدريبي")]
        public bool TrainingAverageLevel{ get; set; }
        [Display(Name = "ملاحظات ")]
        public string Notes { get; set; }
    }
}
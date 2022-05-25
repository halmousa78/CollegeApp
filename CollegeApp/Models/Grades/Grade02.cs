using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class Grade02
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "الرقم")]
        public int Grade02Id { get; set; }
        [Display(Name = "المعدل التراكمي")]
        public double GPA { get; set; }
        [Display(Name = "التقدير")]
        public string GradeName { get; set; }
        [Display(Name = "حالة المتدرب")]
        public string TraineeStatus { get; set; }
        [Display(Name = "رقم هاتف المتدرب")]
        public string TraineePhone { get; set; }
        [Display(Name = "رقم المدرب")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Display(Name = "الوحدات المعتمدة")]
        public int ApprovedUnits { get; set; }
        [Display(Name = "رقم الشعبة")]
        public int SectionId { get; set; }
        //[ForeignKey("Course")]
        [Display(Name = "رقم المقرر")]
        [ForeignKey("Course"), Column(Order = 1)]
        public string CourseId { get; set; }
        public Course Course { get; set; }
        [Display(Name = "رقم التخصص")]
        [ForeignKey("Course"), Column(Order = 2)]
        public int MajorId { get; set; }
        public Major Major { get; set; }
        [Display(Name = "اسم المتدرب ")]
        public string TraineeName { get; set; }
        [Display(Name = "رقم المتدرب ")]
        public int TraineeNumber { get; set; }
        // الفصل التدريبي  الثاني 1442
        [Display(Name = "رقم الفصل التدريبي")]
        public int TermId { get; set; }
        public Term Term { get; set; }
        [Display(Name = "الرقم")]
        public int ProgramTypeId { get; set; }
        public ProgramType ProgramType { get; set; }
        [Display(Name = "الحالة لسجل")]
        public bool GradeStatus { get; set; }
    }
}
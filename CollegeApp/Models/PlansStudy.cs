using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class PlansStudy
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "الرقم")]
        public int PlansStudyId { get; set; }
        [Display(Name = "رقم المقرر")]
        public string CourseId { get; set; }
        [Display(Name = "رقم الفصل التدريبي")]
        public int TermId { get; set; }
        public string CreatedDate { get; set; }
        public string UsersCreated { get; set; }
        [Display(Name = "الوصف العام")]
        public string CourseDescription { get; set; }
        public string Topics { get; set; }
        public string References { get; set; }
        public string Recommended { get; set; }

        //Detailed of Theoretical Contents
        [Display(Name = "الاسبوع الاول")]
        public string Week1 { get; set; }
        [Display(Name = "التقييم الاول")]
        public double GradeWeek1 { get; set; }
        [Display(Name = "الاسبوع الثاني")]
        public string Week2 { get; set; }
        [Display(Name = "التقييم الثاني")]
        public double GradeWeek2 { get; set; }
        [Display(Name = "الاسبوع الثالث")]
        public string Week3 { get; set; }
        [Display(Name = "التقييم الثالث")]
        public double GradeWeek3 { get; set; }
        [Display(Name = "الاسبوع الرابع")]
        public string Week4 { get; set; }
        [Display(Name = "التقييم الرابع")]

        public double GradeWeek4 { get; set; }
        [Display(Name = "الاسبوع الخامس")]
        public string Week5 { get; set; }
        [Display(Name = "التقييم الخامس")]

        public double GradeWeek5 { get; set; }
        [Display(Name = "الاسبوع السادس")]
        public string Week6 { get; set; }
        [Display(Name = "التقييم السادس")]

        public double GradeWeek6 { get; set; }
        [Display(Name = "الاسبوع السابع")]
        public string Week7 { get; set; }
        [Display(Name = "التقييم السابع")]

        public double GradeWeek7 { get; set; }
        [Display(Name = "الاسبوع الثامن")]
        public string Week8 { get; set; }
        [Display(Name = "التقييم الثامن")]

        public double GradeWeek8 { get; set; }
        [Display(Name = "الاسبوع التاسع")]
        public string Week9 { get; set; }
        [Display(Name = "التقييم التاسع")]

        public double GradeWeek9 { get; set; }
        [Display(Name = "الاسبوع العاشر")]
        public string Week10 { get; set; }
        [Display(Name = "التقييم العاشر")]

        public double GradeWeek10 { get; set; }
        [Display(Name = "الاسبوع الحادي عشر")]
        public string Week11 { get; set; }
        [Display(Name = "التقييم الحادي عشر")]

        public double GradeWeek11 { get; set; }
        [Display(Name = "الاسبوع الثاني عشر")]
        public string Week12 { get; set; }
        [Display(Name = "التقييم الثاني عشر")]

        public double GradeWeek12 { get; set; }
        [Display(Name = "الاسبوع الثالث عشر")]
        public string Week13 { get; set; }
        [Display(Name = "التقييم الثالث عشر")]

        public double GradeWeek13 { get; set; }
        [Display(Name = "الاسبوع الرابع عشر")]
        public string Week14 { get; set; }
        [Display(Name = "التقييم الرابع عشر")]

        public double GradeWeek14 { get; set; }
        [Display(Name = "الاسبوع الخامس عشر")]
        public string Week15 { get; set; }
        [Display(Name = "التقييم الخامس عشر")]

        public double GradeWeek15 { get; set; }
        [Display(Name = "الاسبوع السادس عشر")]
        public string Week16 { get; set; }
        [Display(Name = "التقييم السادس عشر")]
        public double GradeWeek16 { get; set; }

        public Course Course { get; set; }
        public Term Term { get; set; }
        public bool PlansStudyStatus { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models
{
    public class Section
    {
        //insert explicit value for identity column in table
        [Required, Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "رقم الشعبة")]
        public int SectionId { get; set; }
        [Display(Name = "رقم المقرر")]
        [Key, Column(Order = 2)]
        public string CourseId { get; set; }
        [Display(Name = "الفصل التدريبي")]
        public int TermId { get; set; }
        [Display(Name = "اكتمل")]
        public bool Completed { get; set; }
        [Display(Name = "رقم المستخدم")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Display(Name = "المقرر")]
        public Course Course { get; set; }
        [Display(Name = "الفصل التدريبي")]
        [ForeignKey("TermId")]
        public Term Term { get; set; }
    }
}
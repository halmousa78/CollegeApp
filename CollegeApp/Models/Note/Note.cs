using CollegeApp.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeApp.Models.Note
{
    public class Note
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "رقم الملاحظة")]
        public string NoteId { get; set; }

        [Display(Name = "رقم المستخدم للمدرب")]
        public int UserId { get; set; }

        [Display(Name = "رقم المستخدم للمتدرب")]
        public int TraineeUserId { get; set; }
        [Display(Name = "رقم القسم")]
        public int DepartmentId { get; set; }
        [Display(Name = "الاجراء")]
        public string ActionName { get; set; }
        [Display(Name = "تفاصيل الاجراء المتخذ")]
        public string ActionDetail { get; set; }

        [Display(Name = "وصف الملاحظة")]
        public string NoteDetail { get; set; }
        [Display(Name = "حالة الملاحظة")]
        public string NoteStatus { get; set; }
    }
}
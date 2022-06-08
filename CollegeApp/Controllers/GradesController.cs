using CollegeApp.Data;
using CollegeApp.Models;
using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AutoMapper;

namespace CollegeApp.Controllers
{
    [Permission]
    [ViewPermissionFilter(ViewId = 1)]
    public class GradesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        private IMapper mapper = AutoMapperConfig.Mapper;

        // GET: Grades
        [ViewPermissionFilter(ViewId = 13)]
        public ActionResult Index()
        {
            // using System.Data.Entity; to use include()
            if (!(Session["UserEmail"] == null))
            {
                var getGrades = db.Grades.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                var getRole = Convert.ToInt32(Session["RoleId"].ToString());
                var getUserRole = db.Users.Where(x => x.RoleId == getRole).Select(x => x.RoleId).FirstOrDefault();
                var getUser = Session["UserName"].ToString();
                var getUserId = db.Users.Where(x => x.UserName == getUser).Select(x => x.UserId).FirstOrDefault();

                // مدير النظام و العميد و الوكلاء
                if (getUserRole == 1 || getUserRole == 2 || getUserRole == 3 || getUserRole == 4 || getUserRole == 5)
                {
                    ViewBag.Data = getGrades;
                    return View();
                }
                //رؤوساء الاقسام
                //رئيس قسم الدرسات العامة
                else if (getUserRole == 6)
                {
                    ViewBag.Data = db.Grade01.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                    return View();
                }
                //رئيس قسم تقنية الحاسب
                else if (getUserRole == 7)
                {
                    ViewBag.Data = db.Grade02.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                    return View();
                }
                //رئيس قسم التقنية الإدراية
                else if (getUserRole == 8)
                {
                    ViewBag.Data = db.Grade06.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                    return View();
                }
                //رئيس قسم ميكانيكا السيارات
                else if (getUserRole == 9)
                {
                    ViewBag.Data = db.Grade03.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                    return View();
                }
                //رئيس قسم صيانة الآلات الميكانيكية
                else if (getUserRole == 10)
                {
                    ViewBag.Data = db.Grade04.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                    return View();
                }
                //رئيس قسم التبريد وتكييف الهواء
                else if (getUserRole == 11)
                {
                    ViewBag.Data = db.Grade05.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).ToList();
                    return View();
                }
                // مشرفين التخصصات
                //مشرف تخصص البرمجيات
                else if (getUserRole == 15)
                {
                    ViewBag.Data = db.Grade02.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 4).ToList();
                    return View();
                }
                //مشرف تخصص الشبكات
                else if (getUserRole == 16)
                {
                    ViewBag.Data = db.Grade02.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 6).ToList();
                    return View();
                }
                //مشرف تخصص الدعم الفني
                else if (getUserRole == 17)
                {
                    ViewBag.Data = db.Grade02.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 5).ToList();
                    return View();
                }
                //مشرف تخصص الإدارة المكتبية
                else if (getUserRole == 18)
                {
                    ViewBag.Data = db.Grade06.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 16).ToList();
                    return View();
                }
                //مشرف تخصص الإدارة المحاسبة
                else if (getUserRole == 19)
                {
                    ViewBag.Data = db.Grade06.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 15).ToList();
                    return View();
                }
                //مشرف تخصص ميكانيكا السيارات
                else if (getUserRole == 20)
                {
                    ViewBag.Data = db.Grade06.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 9).ToList();
                    return View();
                }
                //مشرف تخصص صيانة الآلات الميكانيكية
                else if (getUserRole == 21)
                {
                    ViewBag.Data = db.Grade06.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 10).ToList();
                    return View();
                }
                //مشرف تخصص التبريد وتكييف الهواء
                else if (getUserRole == 22)
                {
                    ViewBag.Data = db.Grade06.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.MajorId == 11).ToList();
                    return View();
                }
                //مدرب
                else if (getUserRole == 12)
                {
                    if ((int)Session["DepartmentId"]  == 1)
                    {
                        ViewBag.Data = db.Grade01.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.UserId == getUserId).ToList();

                    }
                    else if ((int)Session["DepartmentId"] == 2)
                    {
                        ViewBag.Data = db.Grade02.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.UserId == getUserId).ToList();

                    }
                    else if ((int)Session["DepartmentId"] == 3)
                    {
                        ViewBag.Data = db.Grade03.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.UserId == getUserId).ToList();

                    }
                    else if ((int)Session["DepartmentId"] == 4)
                    {
                        ViewBag.Data = db.Grade04.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.UserId == getUserId).ToList();

                    }
                    else if ((int)Session["DepartmentId"] == 5)
                    {
                        ViewBag.Data = db.Grade05.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.UserId == getUserId).ToList();

                    }
                    else
                    {
                        ViewBag.Data = db.Grade06.Include(x => x.Course).Include(x => x.Major).Include(x => x.Term).Include(x => x.User).Include(x => x.Major.Department).Include(x => x.Major.TrainingType).Include(x => x.ProgramType).Where(x => x.UserId == getUserId).ToList();
                    }
                    return View();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult GradeUplaod()
        {
          
            ViewBag.getTrainingTypeList = db.ProgramTypes.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GradeUplaod(HttpPostedFileBase upload, int selected)
        {
            ViewBag.getTrainingTypeList = db.ProgramTypes.ToList();

            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload.FileName.EndsWith(".csv"))
                    {
                        Stream stream = upload.InputStream;
                        DataTable csvTable = new DataTable();

                        using (CsvReader csvReader = new CsvReader(new StreamReader(stream), true, ','))
                        {

                            csvTable.Load(csvReader);

                            /////////////////////////
                            foreach (DataRow row in csvTable.Rows)
                            {


                                Grade ged = new Grade();
                                //مواد الدراسات العامة
                                Grade01 ged1 = new Grade01();
                                //الحاسب 
                                Grade02 ged2 = new Grade02();
                                //ميكانيكا السيارات
                                Grade03 ged3 = new Grade03();
                                //صيانة الآلات الميكانيكية
                                Grade04 ged4 = new Grade04();
                                //التبريد وتكييف الهواء
                                Grade05 ged5 = new Grade05();
                                //التقنية الإدارية
                                Grade06 ged6 = new Grade06();

                                Section sec = new Section();

                                if (!((Convert.ToString(row[2]) == "مقرر مسجل عن طريق مدير النظام" && Convert.ToString(row[1]) == " ") || (Convert.ToString(row[2]) == "مقرر مسجل عن طريق االويب" && Convert.ToString(row[1]) == " ") || (Convert.ToString(row[2]) == "مقرر معاد قيده لتعديل الحرمان" && Convert.ToString(row[1]) == " ")))
                                {


                                    ged.GradeId = 0;
                                    if (db.Grades.Select(x => x.GradeId).FirstOrDefault() == 0)
                                    {
                                        ged.GradeId = 1;
                                    }
                                    else
                                    {
                                        ged.GradeId = db.Grades.Select(x => x.GradeId).Max() + 1;
                                    }


                                    ged.GPA = Convert.ToDouble(row[0]);

                                    if (Convert.ToString(row[2]) == "حرمان بسبب غياب")
                                    {
                                        ged.GradeName = "ح";

                                    }
                                    else if (Convert.ToString(row[2]) == "مطوي قيده")
                                    {
                                        ged.GradeName = "ع";

                                    }
                                    else if (Convert.ToString(row[2]) == "انسحاب فصلي")
                                    {
                                        ged.GradeName = "م";

                                    }
                                    else if (Convert.ToString(row[2]) == "مطوي قيده لإنقطاع أسبوعين")
                                    {
                                        ged.GradeName = "م";

                                    }
                                    else if (Convert.ToString(row[3]) == "مفصول أكاديمي")
                                    {
                                        ged.GradeName = "م ك";

                                    }
                                    else if (Convert.ToString(row[3]) == "ملغي قبوله")
                                    {
                                        ged.GradeName = "م ق";

                                    }
                                    else
                                    {
                                        ged.GradeName = Convert.ToString(row[1]);

                                    }
                                    ged.TraineeStatus = Convert.ToString(row[3]);
                                    ged.TraineePhone = Convert.ToString(row[4]);
                                    //TrainerName
                                    if (row[6] == System.DBNull.Value)
                                    {
                                        ged.UserId = 0;

                                    }
                                    else
                                    {
                                        ged.UserId = db.Users.Find(Convert.ToInt32(row[6])).UserId;

                                    }
                                    if (
                                          //مقررات برنامج الدبلوم
                                          Convert.ToString(row[11]) == "ماهر101" ||
                                          Convert.ToString(row[11]) == "اسلك101" ||
                                          Convert.ToString(row[11]) == "مهني101" ||
                                          Convert.ToString(row[11]) == "اسلم101" ||
                                          Convert.ToString(row[11]) == "عربي101" ||
                                          Convert.ToString(row[11]) == "انجل101" ||
                                          Convert.ToString(row[11]) == "انجل102" ||
                                          Convert.ToString(row[11]) == "انجل103" ||
                                          Convert.ToString(row[11]) == "انجل204" ||
                                          Convert.ToString(row[11]) == "انجل111" ||
                                          Convert.ToString(row[11]) == "انجل112" ||
                                          Convert.ToString(row[11]) == "انجل113" ||
                                          Convert.ToString(row[11]) == "فيزي101" ||
                                          Convert.ToString(row[11]) == "رياض101" ||
                                          Convert.ToString(row[11]) == "رياض121" ||
                                          Convert.ToString(row[11]) == "سلم102" ||
                                          Convert.ToString(row[11]) == "كاب101" ||
                                          //مقررات برنامج البكالريوس
                                          Convert.ToString(row[11]) == "انجل301" ||
                                          Convert.ToString(row[11]) == "انجل302" ||
                                          Convert.ToString(row[11]) == "رياض304" ||
                                          Convert.ToString(row[11]) == "اسلم301" ||
                                          Convert.ToString(row[11]) == "عربي301" ||
                                          Convert.ToString(row[11]) == "رياض301" ||
                                          Convert.ToString(row[11]) == "رياض303" ||
                                          Convert.ToString(row[11]) == "فيزي301"
                                      )
                                    {
                                       

                                        ged.MajorId = 1;
                                      


                                    }
                                    else if (Convert.ToString(row[11]) == "حاسب101" || Convert.ToString(row[11]) == "حاسب102")
                                    {
                                        ged.MajorId = 7;
                                    }
                                    else
                                    {
                                        var getMajorIdString = Convert.ToString(row[14]);
                                        var getTrainingTypeName = Convert.ToString(row[16]);
                                        var getTrainingTypeNameId = db.TrainingTypes.Where( x=> x.TrainingTypeName == getTrainingTypeName).Select(x=>x.TrainingTypeId).FirstOrDefault();
                                        var getMajorId = Convert.ToInt32(db.Majors.Where(x => x.MajorName == getMajorIdString && x.TrainingTypeId == getTrainingTypeNameId).Select(x => x.MajorId).FirstOrDefault());
                                        ged.MajorId = getMajorId;
                                    }

                                   
                                    ged.ApprovedUnits = Convert.ToInt32(row[8]);
                                    ged.SectionId = Convert.ToInt32(row[9]);
                                    //CourseNumber
                                    var getCourseId = Convert.ToString(row[11]);
                                    
                                    ged.CourseId = Convert.ToString(row[11]);

                                    ged.TraineeName = Convert.ToString(row[12]);
                                    ged.TraineeNumber = Convert.ToInt32(row[13]);

                                    var getTermIdString = Convert.ToString(row[18]);
                                    ged.TermId = Convert.ToInt32(db.Terms.Where(x => x.TermName == getTermIdString).Select(x => x.TermId).FirstOrDefault());

                                    ged.ProgramTypeId = selected;
                                    ged.GradeStatus = true;

                                    var SectionId = Convert.ToInt32(row[9]);
                                    var getSectionId = db.Sections.Where(x=>x.SectionId == SectionId).Select(x=>x.SectionId).FirstOrDefault();
                                    if (getSectionId == 0)
                                    {
                                        sec.SectionId = Convert.ToInt32(row[9]);
                                        sec.CourseId = Convert.ToString(row[11]);
                                        sec.TermId = Convert.ToInt32(db.Terms.Where(x => x.TermName == getTermIdString).Select(x => x.TermId).FirstOrDefault());
                                        sec.UserId = db.Users.Find(Convert.ToInt32(row[6])).UserId;
                                        db.Sections.Add(sec);
                                        db.SaveChanges();
                                    }
                                   
                                    db.Grades.Add(ged);
                                    db.SaveChanges();

                                    if ( ged.MajorId == 1)
                                    {
                                        //use auto Mapper
                                        //var Getged1 = mapper.Map<Grade01>(ged);
                                        //Getged1.Grade01Id = 0;
                                        //if (db.Grade01.Select(x => x.Grade01Id).FirstOrDefault() == 0)
                                        //{
                                        //    Getged1.Grade01Id = 1;
                                        //}
                                        //else
                                        //{
                                        //    Getged1.Grade01Id = db.Grade01.Select(x => x.Grade01Id).Max() + 1;
                                        //}



                                        ged1.Grade01Id = 0;
                                        if (db.Grade01.Select(x => x.Grade01Id).FirstOrDefault() == 0)
                                        {
                                            ged1.Grade01Id = 1;
                                        }
                                        else
                                        {
                                            ged1.Grade01Id = db.Grade01.Select(x => x.Grade01Id).Max() + 1;
                                        }


                                        ged1.GPA = ged.GPA;
                                        ged1.GradeName = ged.GradeName;
                                        ged1.TraineeStatus = ged.TraineeStatus;
                                        ged1.TraineePhone = ged.TraineePhone;
                                        ged1.UserId = ged.UserId;
                                        ged1.ApprovedUnits = ged.ApprovedUnits;
                                        ged1.SectionId = ged.SectionId;
                                        ged1.CourseId = ged.CourseId;
                                        ged1.MajorId = ged.MajorId;
                                        ged1.TraineeName = ged.TraineeName;
                                        ged1.TraineeNumber = ged.TraineeNumber;
                                        ged1.TermId = ged.TermId;
                                        ged1.ProgramTypeId = ged.ProgramTypeId;
                                        ged1.GradeStatus = ged.GradeStatus;

                                        db.Grade01.Add(ged1);
                                    }
                                    else if (ged.MajorId == 4 || ged.MajorId == 5 || ged.MajorId == 6 || ged.MajorId == 7 || ged.MajorId == 23 || ged.MajorId == 24)
                                    { 
                                        ged2.Grade02Id = 0;
                                        if (db.Grade02.Select(x => x.Grade02Id).FirstOrDefault() == 0)
                                        {
                                            ged2.Grade02Id = 1;
                                        }
                                        else
                                        {
                                            ged2.Grade02Id = db.Grade02.Select(x => x.Grade02Id).Max() + 1;
                                        }

                                        ged2.GPA = ged.GPA;
                                        ged2.GradeName = ged.GradeName;
                                        ged2.TraineeStatus = ged.TraineeStatus;
                                        ged2.TraineePhone = ged.TraineePhone;
                                        ged2.UserId = ged.UserId;
                                        ged2.ApprovedUnits = ged.ApprovedUnits;
                                        ged2.SectionId = ged.SectionId;
                                        ged2.CourseId = ged.CourseId;
                                        ged2.MajorId = ged.MajorId;
                                        ged2.TraineeName = ged.TraineeName;
                                        ged2.TraineeNumber = ged.TraineeNumber;
                                        ged2.TermId = ged.TermId;
                                        ged2.ProgramTypeId = ged.ProgramTypeId;
                                        ged2.GradeStatus = ged.GradeStatus;

                                        db.Grade02.Add(ged2);
                                    }
                                    else if (ged.MajorId == 9 )
                                    {
                                        ged3.Grade03Id = 0;
                                        if (db.Grade03.Select(x => x.Grade03Id).FirstOrDefault() == 0)
                                        {
                                            ged3.Grade03Id = 1;
                                        }
                                        else
                                        {
                                            ged3.Grade03Id = db.Grade03.Select(x => x.Grade03Id).Max() + 1;
                                        }

                                        ged3.GPA = ged.GPA;
                                        ged3.GradeName = ged.GradeName;
                                        ged3.TraineeStatus = ged.TraineeStatus;
                                        ged3.TraineePhone = ged.TraineePhone;
                                        ged3.UserId = ged.UserId;
                                        ged3.ApprovedUnits = ged.ApprovedUnits;
                                        ged3.SectionId = ged.SectionId;
                                        ged3.CourseId = ged.CourseId;
                                        ged3.MajorId = ged.MajorId;
                                        ged3.TraineeName = ged.TraineeName;
                                        ged3.TraineeNumber = ged.TraineeNumber;
                                        ged3.TermId = ged.TermId;
                                        ged3.ProgramTypeId = ged.ProgramTypeId;
                                        ged3.GradeStatus = ged.GradeStatus;

                                        db.Grade03.Add(ged3);
                                    }
                                    else if (ged.MajorId == 10)
                                    {
                                        ged4.Grade04Id = 0;
                                        if (db.Grade04.Select(x => x.Grade04Id).FirstOrDefault() == 0)
                                        {
                                            ged4.Grade04Id = 1;
                                        }
                                        else
                                        {
                                            ged4.Grade04Id = db.Grade04.Select(x => x.Grade04Id).Max() + 1;
                                        }
                                        ged4.GPA = ged.GPA;
                                        ged4.GradeName = ged.GradeName;
                                        ged4.TraineeStatus = ged.TraineeStatus;
                                        ged4.TraineePhone = ged.TraineePhone;
                                        ged4.UserId = ged.UserId;
                                        ged4.ApprovedUnits = ged.ApprovedUnits;
                                        ged4.SectionId = ged.SectionId;
                                        ged4.CourseId = ged.CourseId;
                                        ged4.MajorId = ged.MajorId;
                                        ged4.TraineeName = ged.TraineeName;
                                        ged4.TraineeNumber = ged.TraineeNumber;
                                        ged4.TermId = ged.TermId;
                                        ged4.ProgramTypeId = ged.ProgramTypeId;
                                        ged4.GradeStatus = ged.GradeStatus;

                                        db.Grade04.Add(ged4);
                                    }
                                    else if (ged.MajorId == 11)
                                    {
                                        ged5.Grade05Id = 0;
                                        if (db.Grade05.Select(x => x.Grade05Id).FirstOrDefault() == 0)
                                        {
                                            ged5.Grade05Id = 1;
                                        }
                                        else
                                        {
                                            ged5.Grade05Id = db.Grade05.Select(x => x.Grade05Id).Max() + 1;
                                        }

                                        ged5.GPA = ged.GPA;
                                        ged5.GradeName = ged.GradeName;
                                        ged5.TraineeStatus = ged.TraineeStatus;
                                        ged5.TraineePhone = ged.TraineePhone;
                                        ged5.UserId = ged.UserId;
                                        ged5.ApprovedUnits = ged.ApprovedUnits;
                                        ged5.SectionId = ged.SectionId;
                                        ged5.CourseId = ged.CourseId; ged1.MajorId = ged.MajorId;
                                        ged5.MajorId = ged.MajorId;
                                        ged5.TraineeName = ged.TraineeName;
                                        ged5.TraineeNumber = ged.TraineeNumber;
                                        ged5.TermId = ged.TermId;
                                        ged5.ProgramTypeId = ged.ProgramTypeId;
                                        ged5.GradeStatus = ged.GradeStatus;

                                        db.Grade05.Add(ged5);
                                    }
                                    else // التقنية الإدارية
                                    {
                                        ged6.Grade06Id = 0;
                                        if (db.Grade06.Select(x => x.Grade06Id).FirstOrDefault() == 0)
                                        {
                                            ged6.Grade06Id = 1;
                                        }
                                        else
                                        {
                                            ged6.Grade06Id = db.Grade06.Select(x => x.Grade06Id).Max() + 1;
                                        }
                                        ged6.GPA = ged.GPA;
                                        ged6.GradeName = ged.GradeName;
                                        ged6.TraineeStatus = ged.TraineeStatus;
                                        ged6.TraineePhone = ged.TraineePhone;
                                        ged6.UserId = ged.UserId;
                                        ged6.ApprovedUnits = ged.ApprovedUnits;
                                        ged6.SectionId = ged.SectionId;
                                        ged6.CourseId = ged.CourseId;
                                        ged6.MajorId = ged.MajorId;
                                        ged6.TraineeName = ged.TraineeName;
                                        ged6.TraineeNumber = ged.TraineeNumber;
                                        ged6.TermId = ged.TermId;
                                        ged6.ProgramTypeId = ged.ProgramTypeId;
                                        ged6.GradeStatus = ged.GradeStatus;

                                        db.Grade06.Add(ged6);
                                    }

                                }
                            }

                            /////////////////// 
                        }

                        return View(csvTable);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "هذا الملف ليس بصيغة csv يجب تغير الصيغة");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }



            return View();
        }

    }
}
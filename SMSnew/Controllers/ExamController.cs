using SMSnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSnew.Controllers
{
    public class ExamController : Controller
    {
        SMSnewEntities db = new SMSnewEntities();
        // GET: Exam
        [HttpGet]
        public ActionResult CreateExam(int i = 0)
        {
            var ExamClass = (db.ClassRooms).GroupBy(s => s.Class).Select(grop => grop.FirstOrDefault());
            SelectList list1 = new SelectList(ExamClass, "Class", "Class");
            ViewBag.cls = list1;
            //var Examsub = (db.Subjects).GroupBy(q => q.SubjectName).Select(gp => gp.FirstOrDefault());
            //SelectList list3 = new SelectList(Examsub, "SubjectName", "SubjectName");
            //ViewBag.cls3 = list3;

            //var ExamDivision = (db.ClassRooms).GroupBy(p => p.Division).Select(grp => grp.FirstOrDefault());
            //SelectList list2 = new SelectList(ExamDivision, "Division", "Division");
            //ViewBag.cls2 = list2;

            return View();
        }
        [HttpPost]
        public ActionResult CreateExam(Exam ud, string Save, string Cancel, string ExamClass, string Examsubject)
        {
            SMSnewEntities db = new SMSnewEntities();
            Exam exm = new Exam();

            if (!string.IsNullOrEmpty(Save))
            {

                exm.ExamName = ud.ExamName;
                exm.ExamPassMark = ud.ExamPassMark;
                exm.ExamClass = ExamClass;
                exm.ExamDescription = ud.ExamDescription;
                exm.Examsubject = Examsubject;
                exm.ExamDate = ud.ExamDate;

                exm.Status = "1";
                db.Exams.Add(exm);
                db.SaveChanges();
            }

            else
            {
                return RedirectToAction("CreateExam");
            }

            return RedirectToAction("CreateExam");
        }
        public ActionResult listexam()
        {
            return View(db.Exams.ToList());
        }

        [HttpGet]
        // GET: smsnew/Edit/5
        public ActionResult EditExam(int id)
        {
            SMSnewEntities db = new SMSnewEntities();
            var ExamClass = (db.ClassRooms).GroupBy(s => s.Class).Select(grop => grop.FirstOrDefault());
            SelectList list1 = new SelectList(ExamClass, "Class", "Class");
            ViewBag.cls = list1;
            var Examsub = (db.Subjects).GroupBy(q => q.SubjectName).Select(gp => gp.FirstOrDefault());
            SelectList list3 = new SelectList(Examsub, "SubjectName", "SubjectName");
            ViewBag.cls3 = list3;
            //var ExamDivision = (db.ClassRooms).GroupBy(p => p.Division).Select(grp => grp.FirstOrDefault());
            //SelectList list2 = new SelectList(ExamDivision, "Division", "Division");
            //ViewBag.cls2 = list2;

            return View(db.Exams.Where(i => i.ExamID == id).FirstOrDefault());
        }

        // POST: smsnew/Edit/5
        [HttpPost]
        public ActionResult EditExam(string Save, string Cancel, string Class, int id, string ExamClass, FormCollection collection)
        {
            try
            {
                SMSnewEntities db = new SMSnewEntities();

                Exam exm = db.Exams.Where(i => i.ExamID == id).FirstOrDefault();
                //string data;
                if (!string.IsNullOrEmpty(Save))
                {

                    exm.ExamName = collection["ExamName"];

                    exm.ExamClass = collection["Class"];

                    exm.Examsubject = collection["Examsubjectedt"];
                    exm.ExamDescription = collection["ExamDescription"];
                    exm.ExamPassMark = Convert.ToDouble(collection["ExamPassMark"]);

                    exm.ExamDate = Convert.ToDateTime(collection["ExamDate"]);

                    exm.Status = "1";
                    //db.Exams.Add(exm);
                    db.SaveChanges();
                }

                else
                {
                    return RedirectToAction("listexam");
                }

                return RedirectToAction("listexam");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult deleteexamdetails(int id)
        {
            try
            {
                Exam dep = db.Exams.Where(i => i.ExamID == id).FirstOrDefault();
                db.Exams.Remove(dep);
                int j = db.SaveChanges();
                if (j > 0)
                {
                    //  ViewBag.msg = "success";
                    return RedirectToAction("listexam");
                }
                else
                {
                    ViewBag.msg = "failed";
                }
                return RedirectToAction("listexam");

            }


            catch
            {
                return RedirectToAction("listexam");
            }

        }







        public ActionResult listexammarks()
        {
            //return View(db.vw_EMStudTeacher.ToList());
            var cr = new List<vw_ExamMarkStudTeacher>();
            cr = db.vw_ExamMarkStudTeacher.ToList();
            return View(cr);
        }



        // GET: smsnew/Edit/5
        public ActionResult editmark(int id)
        {

            return View(db.vw_ExamMarkStudTeacher.Where(i => i.ExamMarkId == id).FirstOrDefault());
        }

        // POST: smsnew/Edit/5
        [HttpPost]
        public ActionResult editmark(FormCollection collection, string Save, string Cancel, int id)
        {
            try
            {
                SMSnewEntities db = new SMSnewEntities();

                ExamMark mrk = db.ExamMarks.Where(i => i.ExamMarkId == id).FirstOrDefault();

                if (!string.IsNullOrEmpty(Save))
                {


                    mrk.ExamTeacherId = 1028;

                    mrk.EM = Convert.ToDouble(collection["EM"]);
                    db.SaveChanges();
                }

                else
                {
                    return RedirectToAction("listexammarks");
                }

                return RedirectToAction("listexammarks");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult deletemark(int id)
        {
            try
            {
                ExamMark dep = db.ExamMarks.Where(i => i.ExamMarkId == id).FirstOrDefault();
                db.ExamMarks.Remove(dep);
                int j = db.SaveChanges();
                if (j > 0)
                {
                    //  ViewBag.msg = "success";
                    return RedirectToAction("listexammarks");
                }
                else
                {
                    ViewBag.msg = "failed";
                }
                return RedirectToAction("listexammarks");

            }


            catch
            {
                return RedirectToAction("listexammarks");
            }



        }

        [HttpGet]
        public ActionResult exammarkcreate(int i = 0)
        {
            var ExamClass = (db.Students).GroupBy(s => s.StudClass).Select(grop => grop.FirstOrDefault());
            SelectList list1 = new SelectList(ExamClass, "StudClass", "StudClass");
            ViewBag.cls = list1;



            var TID = db.Teachers.Select(s => new
            {
                Text = s.TeacherFirstName + " " + s.TeacherLastName,
                Value = s.TeacherID
            })
                 .ToList();

            ViewBag.cls4 = new SelectList(TID, "Value", "Text");
            return View();
        }
        [HttpPost]

        public ActionResult exammarkcreate(ExamMark m, string Class, string Division, string TID, string ExamSubject)
        {
            ExamMark mrk = new ExamMark();
            m.Class = Class;
            TempData["class"] = Class;

            m.Division = Division;
            TempData["division"] = Division;
            m.ExamTeacherId = 1028;
            TempData["tcrid"] = Convert.ToInt32(TID);
            m.ExamSubject = ExamSubject;
            TempData["sub"] = ExamSubject;
            return RedirectToAction("searchstudents");

        }
        [HttpGet]
        public ActionResult searchstudents()
        {
            string class1 = Convert.ToString(TempData["class"]);

            string division1 = Convert.ToString(TempData["division"]);
            string sub1 = Convert.ToString(TempData["sub"]);
            string tid1 = Convert.ToString(TempData["tcrid"]);
            var data = (from Student in
                            db.Students
                        where Student.StudDivision == division1 && Student.StudClass == class1
                        select Student).ToList();
            ViewBag.userdetails = data;
            TempData["data"] = data;
            TempData["class2"] = class1;
            TempData["division2"] = division1;
            TempData["sub2"] = sub1;
            TempData["tid2"] = tid1;
            return View();
        }
        [HttpPost]
        //public ActionResult searchstudents(EM m, string Save, string Cancel,  string subj, string TID, string SID)
        public ActionResult searchstudents(FormCollection collection, string Save, string Cancel)
        {
            SMSnewEntities db = new SMSnewEntities();
            ExamMark mrk = new ExamMark();
            int j = 0;
            //String data1 = Convert.ToString(TempData["data"]);
            String division2 = Convert.ToString(TempData["division2"]);
            String class2 = Convert.ToString(TempData["class2"]);
            String sub2 = Convert.ToString(TempData["sub2"]);
            String tid2 = Convert.ToString(TempData["tid2"]);
            var data = (from Student in
                          db.Students
                        where Student.StudDivision == division2 && Student.StudClass == class2
                        select Student).ToList();


            string mark = collection["txtbox"];
            string stid = collection["ExamStudentID"];
            string[] strArray = mark.Split(',');
            string[] studid = stid.Split(',');
            if (!string.IsNullOrEmpty(Save))
            {
                //foreach (var item in data)

                //{
                //    mrk.Class = class2;

                //    mrk.Division = division2;
                //    //mrk.ExamSubject = subj;
                //    //mrk.ExamTeacherId = Convert.ToInt32(TID);
                //    //mrk.ExamStudentID = Convert.ToInt32(SID);

                //    mrk.EM1 = m.EM1;

                //    db.EMs.Add(mrk);
                //    db.SaveChanges();
                //}

                //if (j > 0)
                //{
                //return RedirectToAction("EMcreate");

                //}




                foreach (var iten in studid)
                {
                    int i = 0;
                    i++;
                    mrk.ExamStudentID = Convert.ToInt32(iten);
                    foreach (var item in strArray)
                    {

                        if (i == 1)
                        {
                            mrk.Class = class2;
                            mrk.Division = division2;
                            mrk.EM = Convert.ToDouble(item.ToString());
                            mrk.ExamSubject = sub2;
                            mrk.ExamTeacherId = 1028;
                            db.ExamMarks.Add(mrk);
                            j = db.SaveChanges();

                            i--;
                            strArray = strArray.Skip(1).ToArray();

                        }
                    }
                }


            }




            else
            {
                return RedirectToAction("exammarkcreate");
            }

            return RedirectToAction("exammarkcreate");
        }



        public JsonResult GetDivisionList(string Class1)
        {


            db.Configuration.ProxyCreationEnabled = false;

            //List<Student> DivisionList = db.Students.Where(x => x.StudClass == AssignmentClass).ToList();
            var DivisionList = db.Students.Where(x => x.StudClass == Class1).GroupBy(q => q.StudDivision).Select(group => group.FirstOrDefault()); ;

            return Json(DivisionList, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetSubjectList(string Class1)
        {



            db.Configuration.ProxyCreationEnabled = false;



            var SubjectList = db.Subjects.Where(x => x.SubjectClass == Class1).ToList();

            return Json(SubjectList, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetSubjectList1(string Class2)
        {



            db.Configuration.ProxyCreationEnabled = false;



            var SubjectList = db.Subjects.Where(x => x.SubjectClass == Class2).ToList();

            return Json(SubjectList, JsonRequestBehavior.AllowGet);

        }





        public ActionResult listexammarkforstud()
        {
            ViewBag.studid = 1034;
            int tmp2 = ViewBag.studid;
            ViewBag.fstname = db.Students.Where(x => x.StudentID == tmp2).Select(column => column.StudFirstName).SingleOrDefault();
            ViewBag.lstname = db.Students.Where(x => x.StudentID == tmp2).Select(column => column.StudLastName).SingleOrDefault();
            var cr = new List<vw_ExamMarkStudTeacher>();
            cr = db.vw_ExamMarkStudTeacher.ToList();
            return View(cr);
        }


        public ActionResult listexammarkforparent()
        {

            int idd = 25;
            ViewBag.st = db.Parents.Where(x => x.ParentID == idd).Select(column => column.ParentStudID).SingleOrDefault();
            int tmp = ViewBag.st;
            ViewBag.fstname = db.Students.Where(x => x.StudentID == tmp).Select(column => column.StudFirstName).SingleOrDefault();
            ViewBag.lstname = db.Students.Where(x => x.StudentID == tmp).Select(column => column.StudLastName).SingleOrDefault();
            var cr = new List<vw_ExamMarkStudTeacher>();
            cr = db.vw_ExamMarkStudTeacher.ToList();
            return View(cr);
        }




    }
}
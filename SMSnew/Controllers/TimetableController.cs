using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;

namespace SMSnew.Controllers
{
    public class TimetableController : Controller
    {
        // GET: Timetable
        SMSnewEntities en = new SMSnewEntities();
        public ActionResult CreateTimeTable()
        {

            var classname = (en.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list3 = new SelectList(classname, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.classname = list3;

            var division = (en.ClassRooms).GroupBy(p => p.ClassRoomDivision).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list1 = new SelectList(division, "ClassRoomDivision", "ClassRoomDivision");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.division = list1;

            //SubjectName DropDownList
            var subject = (en.Subjects).GroupBy(s => s.SubjectName).Select(grop => grop.FirstOrDefault());//.ToList(); 
            SelectList list2 = new SelectList(subject, "SubjectName", "SubjectName");
            ViewBag.subject = list2;
            return View();

        }
        public JsonResult GetDivisionList(string ttClass)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            List<ClassRoom> DivisionList = en.ClassRooms.Where(x => x.Class == ttClass).ToList();
            return Json(DivisionList, JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetSubjectList(string ttClass)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            List<Subject> SubjectList = en.Subjects.Where(x => x.SubjectClass == ttClass).ToList();
            return Json(SubjectList, JsonRequestBehavior.AllowGet);


        }

        // POST: SMS/Create
        [HttpPost]
        public ActionResult CreateTimeTable(string Create, FormCollection collection)
        {
            try
            {


                Timetable tt = new Timetable();
                //string day = collection["btnMonday"];

                tt.ttClass = collection["ttClass"];
                tt.ttDivision = collection["ttDivision"];

                tt.ttWeekDay = "Monday";

                tt.Subject_1 = collection["MonSubject_1"];
                tt.Subject_2 = collection["MonSubject_2"];
                tt.Subject_3 = collection["MonSubject_3"];
                tt.Subject_4 = collection["MonSubject_4"];
                tt.Subject_5 = collection["MonSubject_5"];
                tt.Subject_6 = collection["MonSubject_6"];
                tt.Subject_7 = collection["MonSubject_7"];
                tt.Subject_8 = collection["MonSubject_8"];
                en.Timetables.Add(tt);
                int i = en.SaveChanges();
               
                    tt.ttClass = collection["ttClass"];
                    tt.ttDivision = collection["ttDivision"];
                    tt.ttWeekDay = "Tuesday";
                    tt.Subject_1 = collection["TueSubject_1"];
                    tt.Subject_2 = collection["TueSubject_2"];
                    tt.Subject_3 = collection["TueSubject_3"];
                    tt.Subject_4 = collection["TueSubject_4"];
                    tt.Subject_5 = collection["TueSubject_5"];
                    tt.Subject_6 = collection["TueSubject_6"];
                    tt.Subject_7 = collection["TueSubject_7"];
                    tt.Subject_8 = collection["TueSubject_8"];
                    en.Timetables.Add(tt);
                    int j = en.SaveChanges();
                    



                        tt.ttClass = collection["ttClass"];
                        tt.ttDivision = collection["ttDivision"];
                        tt.ttWeekDay = "Wednesday";
                        tt.Subject_1 = collection["WedSubject_1"];
                        tt.Subject_2 = collection["WedSubject_2"];
                        tt.Subject_3 = collection["WedSubject_3"];
                        tt.Subject_4 = collection["WedSubject_4"];
                        tt.Subject_5 = collection["WedSubject_5"];
                        tt.Subject_6 = collection["WedSubject_6"];
                        tt.Subject_7 = collection["WedSubject_7"];
                        tt.Subject_8 = collection["WedSubject_8"];
                        en.Timetables.Add(tt);
                        int k = en.SaveChanges();
                        

                            tt.ttClass = collection["ttClass"];
                            tt.ttDivision = collection["ttDivision"];
                            tt.ttWeekDay = "Thursday";
                            tt.Subject_1 = collection["ThuSubject_1"];
                            tt.Subject_2 = collection["ThuSubject_2"];
                            tt.Subject_3 = collection["ThuSubject_3"];
                            tt.Subject_4 = collection["ThuSubject_4"];
                            tt.Subject_5 = collection["ThuSubject_5"];
                            tt.Subject_6 = collection["ThuSubject_6"];
                            tt.Subject_7 = collection["ThuSubject_7"];
                            tt.Subject_8 = collection["ThuSubject_8"];
                            en.Timetables.Add(tt);
                            int z = en.SaveChanges();
                           
                                tt.ttClass = collection["ttClass"];
                                tt.ttDivision = collection["ttDivision"];
                                tt.ttWeekDay = "Friday";
                                tt.Subject_1 = collection["FriSubject_1"];
                                tt.Subject_2 = collection["FriSubject_2"];
                                tt.Subject_3 = collection["FriSubject_3"];
                                tt.Subject_4 = collection["FriSubject_4"];
                                tt.Subject_5 = collection["FriSubject_5"];
                                tt.Subject_6 = collection["FriSubject_6"];
                                tt.Subject_7 = collection["FriSubject_7"];
                                tt.Subject_8 = collection["FriSubject_8"];
                                en.Timetables.Add(tt);
                                int l = en.SaveChanges();
                               

                                    tt.ttClass = collection["ttClass"];
                                    tt.ttDivision = collection["ttDivision"];
                                    tt.ttWeekDay = "Saturday";
                                    tt.Subject_1 = collection["SatSubject_1"];
                                    tt.Subject_2 = collection["SatSubject_2"];
                                    tt.Subject_3 = collection["SatSubject_3"];
                                    tt.Subject_4 = collection["SatSubject_4"];
                                    tt.Subject_5 = collection["SatSubject_5"];
                                    tt.Subject_6 = collection["SatSubject_6"];
                                    tt.Subject_7 = collection["SatSubject_7"];
                                    tt.Subject_8 = collection["SatSubject_8"];
                                    en.Timetables.Add(tt);
                                    int m = en.SaveChanges();
                                        return RedirectToAction("CreateTimeTable");
               
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditTimeTable()
        {
            var classname = (en.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list3 = new SelectList(classname, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.classname = list3;

            var division = (en.ClassRooms).GroupBy(p => p.ClassRoomDivision).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list1 = new SelectList(division, "ClassRoomDivision", "ClassRoomDivision");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.division = list1;
            return View();
        }
        public JsonResult EditGetMonSub1(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var monsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Monday" select s.Subject_1).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(monsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetMonSub2(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var monsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Monday" select s.Subject_2).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(monsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetMonSub3(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var monsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Monday" select s.Subject_3).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(monsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetMonSub4(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var monsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Monday" select s.Subject_4).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(monsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetMonSub5(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var monsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Monday" select s.Subject_5).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(monsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetMonSub6(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var monsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Monday" select s.Subject_6).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(monsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetMonSub7(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var monsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Monday" select s.Subject_7).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(monsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetMonSub8(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var monsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Monday" select s.Subject_8).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(monsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetTueSub1(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var tuesubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Tuesday" select s.Subject_1).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(tuesubjects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditGetTueSub2(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var tuesubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Tuesday" select s.Subject_2).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(tuesubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetTueSub3(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var tuesubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Tuesday" select s.Subject_3).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(tuesubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetTueSub4(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var tuesubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Tuesday" select s.Subject_4).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(tuesubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetTueSub5(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var tuesubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Tuesday" select s.Subject_5).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(tuesubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetTueSub6(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var tuesubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Tuesday" select s.Subject_6).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(tuesubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetTueSub7(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var tuesubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Tuesday" select s.Subject_7).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(tuesubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetTueSub8(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var tuesubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Tuesday" select s.Subject_8).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(tuesubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetWedSub1(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var wedsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Wednesday" select s.Subject_1).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(wedsubjects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditGetWedSub2(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var wedsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Wednesday" select s.Subject_2).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(wedsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetWedSub3(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var wedsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Wednesday" select s.Subject_3).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(wedsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetWedSub4(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var wedsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Wednesday" select s.Subject_4).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(wedsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetWedSub5(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var wedsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Wednesday" select s.Subject_5).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(wedsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetWedSub6(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var wedsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Wednesday" select s.Subject_6).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(wedsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetWedSub7(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var wedsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Wednesday" select s.Subject_7).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(wedsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetWedSub8(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var wedsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Wednesday" select s.Subject_8).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(wedsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetThuSub1(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var thusubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Thursday" select s.Subject_1).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(thusubjects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditGetThuSub2(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var thusubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Thursday" select s.Subject_2).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(thusubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetThuSub3(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var thusubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Thursday" select s.Subject_3).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(thusubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetThuSub4(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var thusubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Thursday" select s.Subject_4).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(thusubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetThuSub5(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var thusubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Thursday" select s.Subject_5).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(thusubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetThuSub6(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var thusubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Thursday" select s.Subject_6).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(thusubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetThuSub7(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var thusubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Thursday" select s.Subject_7).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(thusubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetThuSub8(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var thusubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Thursday" select s.Subject_8).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(thusubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetFriSub1(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var frisubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Friday" select s.Subject_1).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(frisubjects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditGetFriSub2(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var frisubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Friday" select s.Subject_2).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(frisubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetFriSub3(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var frisubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Friday" select s.Subject_3).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(frisubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetFriSub4(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var frisubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Friday" select s.Subject_4).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(frisubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetFriSub5(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var frisubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Friday" select s.Subject_5).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(frisubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetFriSub6(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var frisubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Friday" select s.Subject_6).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(frisubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetFriSub7(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var frisubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Friday" select s.Subject_7).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(frisubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetFriSub8(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var frisubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Friday" select s.Subject_8).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(frisubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetSatSub1(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var satsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Saturday" select s.Subject_1).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(satsubjects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditGetSatSub2(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var satsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Saturday" select s.Subject_2).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(satsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetSatSub3(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var satsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Saturday" select s.Subject_3).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(satsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetSatSub4(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var satsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Saturday" select s.Subject_4).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(satsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetSatSub5(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var satsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Saturday" select s.Subject_5).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(satsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetSatSub6(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var satsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Saturday" select s.Subject_6).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(satsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetSatSub7(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var satsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Saturday" select s.Subject_7).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(satsubjects, JsonRequestBehavior.AllowGet);


        }
        public JsonResult EditGetSatSub8(string ttClass, string ttDivision, FormCollection collection)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            // SelectList monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").ToList();
            var satsubjects = (from s in en.Timetables where s.ttClass == ttClass && s.ttDivision == ttDivision && s.ttWeekDay == "Saturday" select s.Subject_8).SingleOrDefault();
            //var monsubjects = en.Timetables.Where(x => x.ttClass == ttClass && x.ttDivision == ttDivision && x.ttWeekDay == "Monday").Select(x => new { x.Subject_1, x.Subject_2, x.Subject_3, x.Subject_4, x.Subject_5, x.Subject_6, x.Subject_7, x.Subject_8 });
            return Json(satsubjects, JsonRequestBehavior.AllowGet);


        }
        // POST: SMS/Edit/5
        [HttpPost]
        public ActionResult EditTimeTable(string ttClass, string ttDivision, FormCollection collection)
        {
            try
            {
                Timetable tt = en.Timetables.Where(i => i.ttClass == ttClass && i.ttDivision == ttDivision && i.ttWeekDay == "Monday").FirstOrDefault();
                tt.ttClass = collection["ttClass"];
                tt.ttDivision = collection["ttDivision"];

                tt.ttWeekDay = "Monday";

                tt.Subject_1 = collection["MonSubject_1"];
                tt.Subject_2 = collection["MonSubject_2"];
                tt.Subject_3 = collection["MonSubject_3"];
                tt.Subject_4 = collection["MonSubject_4"];
                tt.Subject_5 = collection["MonSubject_5"];
                tt.Subject_6 = collection["MonSubject_6"];
                tt.Subject_7 = collection["MonSubject_7"];
                tt.Subject_8 = collection["MonSubject_8"];
                int a = en.SaveChanges();

                Timetable tt1 = en.Timetables.Where(i => i.ttClass == ttClass && i.ttDivision == ttDivision && i.ttWeekDay == "Tuesday").FirstOrDefault();
                tt1.ttClass = collection["ttClass"];
                tt1.ttDivision = collection["ttDivision"];
                tt1.ttWeekDay = "Tuesday";
                tt1.Subject_1 = collection["TueSubject_1"];
                tt1.Subject_2 = collection["TueSubject_2"];
                tt1.Subject_3 = collection["TueSubject_3"];
                tt1.Subject_4 = collection["TueSubject_4"];
                tt1.Subject_5 = collection["TueSubject_5"];
                tt1.Subject_6 = collection["TueSubject_6"];
                tt1.Subject_7 = collection["TueSubject_7"];
                tt1.Subject_8 = collection["TueSubject_8"];
                int b = en.SaveChanges();

                Timetable tt2 = en.Timetables.Where(i => i.ttClass == ttClass && i.ttDivision == ttDivision && i.ttWeekDay == "Wednesday").FirstOrDefault();
                tt2.ttClass = collection["ttClass"];
                tt2.ttDivision = collection["ttDivision"];
                tt2.ttWeekDay = "Wednesday";
                tt2.Subject_1 = collection["WedSubject_1"];
                tt2.Subject_2 = collection["WedSubject_2"];
                tt2.Subject_3 = collection["WedSubject_3"];
                tt2.Subject_4 = collection["WedSubject_4"];
                tt2.Subject_5 = collection["WedSubject_5"];
                tt2.Subject_6 = collection["WedSubject_6"];
                tt2.Subject_7 = collection["WedSubject_7"];
                tt2.Subject_8 = collection["WedSubject_8"];
                int c = en.SaveChanges();

                Timetable tt3 = en.Timetables.Where(i => i.ttClass == ttClass && i.ttDivision == ttDivision && i.ttWeekDay == "Thursday").FirstOrDefault();
                tt3.ttClass = collection["ttClass"];
                tt3.ttDivision = collection["ttDivision"];
                tt3.ttWeekDay = "Thursday";
                tt3.Subject_1 = collection["ThuSubject_1"];
                tt3.Subject_2 = collection["ThuSubject_2"];
                tt3.Subject_3 = collection["ThuSubject_3"];
                tt3.Subject_4 = collection["ThuSubject_4"];
                tt3.Subject_5 = collection["ThuSubject_5"];
                tt3.Subject_6 = collection["ThuSubject_6"];
                tt3.Subject_7 = collection["ThuSubject_7"];
                tt3.Subject_8 = collection["ThuSubject_8"];
                int d = en.SaveChanges();

                Timetable tt4 = en.Timetables.Where(i => i.ttClass == ttClass && i.ttDivision == ttDivision && i.ttWeekDay == "Friday").FirstOrDefault();
                tt4.ttClass = collection["ttClass"];
                tt4.ttDivision = collection["ttDivision"];
                tt4.ttWeekDay = "Friday";
                tt4.Subject_1 = collection["FriSubject_1"];
                tt4.Subject_2 = collection["FriSubject_2"];
                tt4.Subject_3 = collection["FriSubject_3"];
                tt4.Subject_4 = collection["FriSubject_4"];
                tt4.Subject_5 = collection["FriSubject_5"];
                tt4.Subject_6 = collection["FriSubject_6"];
                tt4.Subject_7 = collection["FriSubject_7"];
                tt4.Subject_8 = collection["FriSubject_8"];
                int e = en.SaveChanges();

                Timetable tt5 = en.Timetables.Where(i => i.ttClass == ttClass && i.ttDivision == ttDivision && i.ttWeekDay == "Saturday").FirstOrDefault();
                tt5.ttClass = collection["ttClass"];
                tt5.ttDivision = collection["ttDivision"];
                tt5.ttWeekDay = "Saturday";
                tt5.Subject_1 = collection["SatSubject_1"];
                tt5.Subject_2 = collection["SatSubject_2"];
                tt5.Subject_3 = collection["SatSubject_3"];
                tt5.Subject_4 = collection["SatSubject_4"];
                tt5.Subject_5 = collection["SatSubject_5"];
                tt5.Subject_6 = collection["SatSubject_6"];
                tt5.Subject_7 = collection["SatSubject_7"];
                tt5.Subject_8 = collection["SatSubject_8"];
                int f = en.SaveChanges();

                ttClass = null;
                ttDivision = null;
                return RedirectToAction("EditTimeTable", "Timetable");
            }

            catch
            {
                return View();
            }
        }
    }
}
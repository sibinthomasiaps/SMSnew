using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;
namespace SMSnew.Controllers
{
    public class AttendanceController : Controller
    {
        SMSnewEntities db = new SMSnewEntities();
        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StudAttendanceView()
        {
            int c = db.Attendances.Where(i => i.StudentID == 1023).Select(i => i.AttendanceDate).Count();
            ViewBag.count = c;
            var data = db.Attendances.Where(i => i.StudentID == 1023).ToList();
            ViewBag.attendance = data;
            return View();
        }
        [HttpGet]
        public ActionResult Attendancesearch()
        {
            var getclass = (db.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list = new SelectList(getclass, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.getclass = list;
            //var getdivision = (db.ClassRooms).GroupBy(p => p.ClassRoomDivision).Select(grp => grp.FirstOrDefault());//.ToList(); 
            //SelectList list1 = new SelectList(getdivision, "ClassRoomDivision", "ClassRoomDivision");//// "ClassRoomID", "ClassRoomDivision", "Class"
            //ViewBag.getdivision = list1;

            var getdate = (db.Attendances).GroupBy(p => p.AttendanceDate).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list2 = new SelectList(getdate, "AttendanceDate", "AttendanceDate");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.getdate = list2;
            TempData["date"] = list2;
            return View();
        }
        public JsonResult GetDivisionList(string getclass)
        {

            //var division = (en.ClassRooms.Where(x => x.Class == SubAlClass).GroupBy(p => p.ClassRoomDivision).Select(grp => grp.FirstOrDefault()));
            //var div = en.ClassRooms.Where(x => x.Class == SubAlClass).Select(x => x.ClassRoomDivision).Distinct().ToList();
            //return Json(division, JsonRequestBehavior.AllowGet);
            //List<ClassRoom> DivisionList = div;
            db.Configuration.ProxyCreationEnabled = false;
            List<ClassRoom> DivisionList = null;
            DivisionList = db.ClassRooms.Where(x => x.Class == getclass).ToList();
            return Json(DivisionList, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public ActionResult Attendancesearch(FormCollection collection, string getclass, string getdivision, string save, string cancel, string search)
        {


            //var getdate1 = (db.Attendances).GroupBy(p => p.AttendanceDate).Select(grp => grp.FirstOrDefault());

            var entities = new SMSnewEntities();

            var getdate2 = (entities.Attendances.ToList());
            if (!string.IsNullOrEmpty(save))
            {
                try
                {
                    Attendance at = new Attendance();
                    TempData["class"] = getclass;
                    TempData["division"] = getdivision;

                    var date1 = collection["date"];
                    String vdate1 = Convert.ToString(date1);
                    DateTime dat = Convert.ToDateTime(vdate1);
                    TempData["date"] = date1;

                    foreach (var item in getdate2)
                    {

                        var s = item.AttendanceDate;
                        string adate = Convert.ToString(s);
                        DateTime dat1 = Convert.ToDateTime(adate);
                        var cl = item.StudClass;
                        String class1 = Convert.ToString(cl);
                        var di = item.StudDivision;
                        String division1 = Convert.ToString(di);


                        if (getclass == class1 && getdivision == di)
                        {
                            if (dat == dat1)
                            {
                                ViewBag.msg = "Attendance already inserted";
                                return RedirectToAction("Attendancesearch");
                            }

                        }

                    }

                    return RedirectToAction("Attendancereg");


                }
                catch
                {


                }
                return View();
            }
            else if (!string.IsNullOrEmpty(cancel))
            {
                return RedirectToAction("Attendancesearch");
            }
            else
            {
                TempData["class"] = getclass;
                TempData["division"] = getdivision;
                var date1 = collection["date"];
                String vdate1 = Convert.ToString(date1);
                DateTime dat = Convert.ToDateTime(vdate1);
                TempData["date"] = date1;

                return RedirectToAction("attendancelist");
            }
        }
        [HttpGet]
        public ActionResult Attendancereg()
        {

            String gclass = Convert.ToString(TempData["class"]);
            String gdivision = Convert.ToString(TempData["division"]);
            String Atdate = Convert.ToString(TempData["date"]);
            List<Student> EmployeeGridView = (from Student in db.Students//.Take(15)
                                              select Student).ToList();



            var data = (from Student in
                            db.Students
                        where Student.StudDivision == gdivision && Student.StudClass == gclass//.Take(15)
                        select Student).ToList();

            Student model = new Student();
            //model.PageSize = 10;
            List<Student> Students = EmployeeGridView;
            if (Students != null)
            {
                //   model.Students = Students;
            }
            ViewBag.userdetails = data;
            //model.gclass = gclass;
            //model.gdivision = gdivision;
            TempData["class"] = gclass;
            TempData["division"] = gdivision;
            TempData["date"] = Atdate;
            return View(model);

        }

        [HttpPost]
        public ActionResult Attendancereg(FormCollection collection, string save, string cancel)
        {
            if (!string.IsNullOrEmpty(save))
            {
                try
                {
                    String gclass = Convert.ToString(TempData["class"]);
                    String gdivision = Convert.ToString(TempData["division"]);
                    String details = Convert.ToString(TempData["details"]);
                    String date = Convert.ToString(TempData["date"]);
                    var data1 = (from Student in
                                     db.Students
                                 where Student.StudClass == gclass && Student.StudDivision == gdivision
                                 select Student).ToList();
                    ViewBag.userdetails = data1;

                    var data11 = (from Student in
                                      db.Students
                                  where Student.StudClass == gclass && Student.StudDivision == gdivision
                                  select Student).ToList();
                    int j = 0;


                    Attendance at = new Attendance();
                    at.AttendanceDate = Convert.ToDateTime(date);
                    at.StudClass = gclass;
                    at.StudDivision = gdivision;
                    //at.StudentId=item.StudentId;

                    string status = collection["ckbox1"];
                    string stid = collection["StudentID"];
                    string[] strArray = status.Split(',');

                    string[] studid = stid.Split(',');
                    foreach (var iten in studid)
                    {
                        int i = 0;
                        i++;
                        at.StudentID = Convert.ToInt32(iten);
                        foreach (var item in strArray)
                        {

                            if (i == 1)
                            {

                                at.AttStatus = item.ToString();
                                db.Attendances.Add(at);
                                j = db.SaveChanges();

                                i--;
                                strArray = strArray.Skip(1).ToArray();

                            }
                        }
                    }



                    if (j > 0)
                    {
                        ViewBag.msg = "success";
                        return RedirectToAction("attendancelist");
                    }
                    else
                    {
                        ViewBag.msg = "failed";
                        return RedirectToAction("attendancelist");
                    }



                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Attendancesearch");
            }


        }
        [HttpGet]
        public ActionResult attendancelist()
        {
            String gclass = Convert.ToString(TempData["class"]);
            String gdivision = Convert.ToString(TempData["division"]);
            DateTime Atdate = Convert.ToDateTime(TempData["date"]);


            //DateTime Atdate = Convert.ToDateTime(TempData["date"]);

            List<Attendance> EmployeeGridView = (from Attendance in db.Attendances//.Take(15)
                                                 select Attendance).ToList();


            var data = (from Attendance in
                            db.Attendances
                        where Attendance.StudDivision == gdivision && Attendance.StudClass == gclass && Attendance.AttendanceDate == Atdate//.Take(15)
                        select Attendance).ToList();

            Attendance model = new Attendance();
            //model.PageSize = 10;
            List<Attendance> Attendances = EmployeeGridView;
            if (Attendances != null)
            {
                //   model.Students = Students;
            }
            ViewBag.userdetails = data;
            //model.gclass = gclass;
            //model.gdivision = gdivision;
            TempData["class"] = gclass;
            TempData["division"] = gdivision;
            TempData["date"] = Atdate;
            ViewBag.Encoded = new Func<string, string>(encodecode.Encode);
            return View(model);
        }
        [HttpPost]
        public ActionResult attendancelist(string cancel)
        {
            return RedirectToAction("Attendancesearch");
        }
        [HttpGet]
        public ActionResult attendancelistEdit(string id)
        {
            string vv = encodecode.Decode(id);
            int dd = Convert.ToInt32(vv);
            TempData["decodeid"] = dd;
            var getstatus = (db.Attendances).GroupBy(p => p.AttStatus).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list = new SelectList(getstatus, "AttStatus", "AttStatus");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.getstatus = list;

            return View(db.Attendances.Where(i => i.AttendanceID == dd).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult attendancelistEdit(FormCollection collection, string save, string cancel, string getstatus)
        {
            String dcd = Convert.ToString(TempData["decodeid"]);

            int id = Convert.ToInt32(dcd);
            if (!string.IsNullOrEmpty(save))
            {
                try
                {


                    Attendance at = db.Attendances.Where(i => i.AttendanceID == id).FirstOrDefault();

                    at.AttStatus = collection["AttStatus"];
                    int j = db.SaveChanges();
                    if (j > 0)
                    {

                        return RedirectToAction("attendancelist");
                    }
                    else
                    {
                        return RedirectToAction("attendancelist");
                    }
                }
                catch
                {


                }
                return View();
            }
            else
            {
                return RedirectToAction("attendancelist");
            }

        }

        [HttpGet]
        public ActionResult attendancecard()
        {

            return View();
        }
        [HttpPost]
        public ActionResult attendancecard(FormCollection collection)
        {

            AttendanceCard card = new AttendanceCard();
            card.AttendanceCardId = collection["cardid"];
            card.AttendanceDate = Convert.ToDateTime(collection["date"]);

            var cardid = collection["cardid"];

            var data11 = (from Student in
                               db.Students
                          where Student.AttendanceCardId == cardid
                          select Student).ToList();
            foreach (var item in data11)
            {


                card.StudClass = item.StudClass;
                card.StudDivision = item.StudDivision;
                card.StudentID = item.StudentID;
                card.AttStatus = "present";

            }

            db.AttendanceCards.Add(card);
            db.SaveChanges();
            return View();

        }
        [HttpGet]
        public ActionResult Attendancecardsearch()
        {
            var getclass = (db.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list = new SelectList(getclass, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.getclass = list;
            //var getdivision = (db.ClassRooms).GroupBy(p => p.ClassRoomDivision).Select(grp => grp.FirstOrDefault());//.ToList(); 
            //SelectList list1 = new SelectList(getdivision, "ClassRoomDivision", "ClassRoomDivision");//// "ClassRoomID", "ClassRoomDivision", "Class"
            //ViewBag.getdivision = list1;

            var getdate = (db.AttendanceCards).GroupBy(p => p.AttendanceDate).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list2 = new SelectList(getdate, "AttendanceDate", "AttendanceDate");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.getdate = list2;
            TempData["date"] = list2;
            return View();
        }

        [HttpPost]
        public ActionResult Attendancecardsearch(FormCollection collection, string getclass, string getdivision, string save, string cancel, string search)
        {


            //var getdate1 = (db.Attendances).GroupBy(p => p.AttendanceDate).Select(grp => grp.FirstOrDefault());


            if (!string.IsNullOrEmpty(save))
            {
                try
                {
                    Attendance at = new Attendance();
                    TempData["class"] = getclass;
                    TempData["division"] = getdivision;
                    TempData["date"] = Convert.ToDateTime(collection["date"]);

                    return RedirectToAction("Attendancecardlist");


                }
                catch
                {


                }
                return View();
            }
            else
            {
                return RedirectToAction("Attendancecardsearch");
            }

        }
        public JsonResult GetDivisionList1(string getclass)
        {

            //var division = (en.ClassRooms.Where(x => x.Class == SubAlClass).GroupBy(p => p.ClassRoomDivision).Select(grp => grp.FirstOrDefault()));
            //var div = en.ClassRooms.Where(x => x.Class == SubAlClass).Select(x => x.ClassRoomDivision).Distinct().ToList();
            //return Json(division, JsonRequestBehavior.AllowGet);
            //List<ClassRoom> DivisionList = div;
            db.Configuration.ProxyCreationEnabled = false;
            List<ClassRoom> DivisionList = null;
            DivisionList = db.ClassRooms.Where(x => x.Class == getclass).ToList();
            return Json(DivisionList, JsonRequestBehavior.AllowGet);


        }

        public ActionResult attendancecardlist(string cancel)
        {


            String gclass = Convert.ToString(TempData["class"]);
            String gdivision = Convert.ToString(TempData["division"]);
            DateTime Atdate = Convert.ToDateTime(TempData["date"]);
            var data = (from AttendanceCard in
                            db.AttendanceCards
                        where AttendanceCard.StudDivision == gdivision && AttendanceCard.StudClass == gclass && AttendanceCard.AttendanceDate == Atdate//.Take(15)
                        select AttendanceCard).ToList();
            ViewBag.userdetails = data;


            if (!string.IsNullOrEmpty(cancel))
            {
                return RedirectToAction("Attendancecardsearch");
            }
            return View();

        }
        //[HttpGet]
        //public ActionResult attendancecardedit(string id)
        //{

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult attendancecardedit( FormCollection collection)
        //{

        //    AttendanceCard card = new AttendanceCard();
        //    //card.AttendanceCardId = collection["cardid"];
        //    //card.AttendanceDate = Convert.ToDateTime(collection["date"]);

        //    var cardid = collection["cardid"];


        //    card.AttendanceCardId = collection["cardid"];
        //    card.AttendanceDate = Convert.ToDateTime(collection["date"]);


        //    card.StudDivision = item.StudDivision;
        //    card.StudentID = item.StudentID;
        //    card.AttStatus = "present";


        //    db.SaveChanges();



        //} 

    }
}
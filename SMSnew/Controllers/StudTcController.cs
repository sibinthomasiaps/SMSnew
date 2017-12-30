using SMSnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSnew.Controllers
{
    public class StudTcController : Controller
    {
        SMSnewEntities db = new SMSnewEntities();
        // GET: StudTc
        public ActionResult Index()
        {
            return View();
        }
    [HttpGet]
        public ActionResult StudentTcDataInsertion()
        {
            var ClassLastStudied = (db.Students).GroupBy(p => p.StudClass).Select(grp => grp.FirstOrDefault());
            SelectList list = new SelectList(ClassLastStudied, "StudClass", "StudClass");
            ViewBag.cls = list;  
            return View();
        }
 
        [HttpPost]
        public ActionResult StudentTcDataInsertion(TC t,string save)
        {
            try
            {
                if (!string.IsNullOrEmpty(save))
                {
                    TC lbs = new TC();
                    //lbs.AdmissionDate = t.AdmissionDate;
                    lbs.ClassLastStudied = t.ClassLastStudied;
                    lbs.GuardianName = t.GuardianName;
                    //lbs.Nationality = t.Nationality;
                    //lbs.Caste = t.Caste;
                    //lbs.DOB = t.DOB;
                    lbs.AnyPendingFees = t.AnyPendingFees;
                    lbs.WorkingDays = t.WorkingDays;
                    lbs.WorkingDaysPresent = t.WorkingDaysPresent;
                    lbs.ExtraCurricular = t.ExtraCurricular;
                    lbs.TCApplicationDate = t.TCApplicationDate;
                    lbs.TCIssueDate = DateTime.Now;
                    lbs.ReasonForLeaving = t.ReasonForLeaving;
                    lbs.StudId = t.StudId;
                    lbs.Remarks = t.Remarks;
                    db.TCs.Add(lbs);
                   int i= db.SaveChanges();
                   if (i > 0)
                   {
                       return RedirectToAction("StudentTcDataInsertion");
                   }
                }
            }
            catch
            { 
            
            }
       
            return View();
        }
        public JsonResult GetDivisionList(string ClassLastStudied)
        {
            db.Configuration.ProxyCreationEnabled = false;

          //  var DivisionList = (db.Students.Where(i => i.StudActive == 1)).GroupBy(p => p.StudFirstName).Select(grp => grp.FirstOrDefault());
            var DivisionList = db.Students.Where(x => x.StudClass == ClassLastStudied &&  x.StudActive == 1).GroupBy(q => q.StudFirstName).Select(group => group.FirstOrDefault());
            return Json(DivisionList, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetDivisionList1(string ClassLastStudied1)
        {
            db.Configuration.ProxyCreationEnabled = false;

            //  var DivisionList = (db.Students.Where(i => i.StudActive == 1)).GroupBy(p => p.StudFirstName).Select(grp => grp.FirstOrDefault());
            var DivisionList = db.Students.Where(x => x.StudClass == ClassLastStudied1 && x.StudActive == 1).GroupBy(q => q.StudFirstName).Select(group => group.FirstOrDefault());
            return Json(DivisionList, JsonRequestBehavior.AllowGet);

        }

        public ActionResult StudentTcDataView()
        {

            var tc = new List<vw_StudentTc>();
            tc = db.vw_StudentTc.ToList();
            return View(tc);
            //List<TC> tc = db.TCs.OrderByDescending(x => x.TCid).ToList<TC>();
            //return View(tc);
        }

        [HttpGet]
        public ActionResult StudentTcEdit11(int id)
        {
            db.TCs.Where(i => i.TCid == id).FirstOrDefault();
            var Classstudid = (db.TCs.Where(i => i.TCid == id).Select(i => i.StudId).FirstOrDefault());
            int sid = Convert.ToInt32(Classstudid);
            ViewBag.idd = sid;
            // var sname = (db.Students.Where(i => i.StudentID == sid).Select(i => i.StudFirstName).FirstOrDefault());
            var sname = (db.Students.Where(i => i.StudentID == sid).Select(i => i.StudFirstName + " " + i.StudLastName).FirstOrDefault());
            ViewBag.sname = sname;

            var ClassLastStudied = (db.Students).GroupBy(p => p.StudClass).Select(grp => grp.FirstOrDefault());
            SelectList list = new SelectList(ClassLastStudied, "StudClass", "StudClass");
            ViewBag.ls = list;
            return View(db.TCs.Where(i => i.TCid == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult StudentTcEdit11(int id, TC t, string save, string cancel)
        {

            try
            {
                if (!string.IsNullOrEmpty(save))
                {
                    TC lbs = db.TCs.Where(i => i.TCid == id).FirstOrDefault();
                    //lbs.AdmissionDate = t.AdmissionDate;
                    lbs.ClassLastStudied = t.ClassLastStudied;
                    lbs.GuardianName = t.GuardianName;
                    //lbs.Nationality = t.Nationality;
                    //lbs.Caste = t.Caste;
                    //lbs.DOB = t.DOB;
                    lbs.AnyPendingFees = t.AnyPendingFees;
                    lbs.WorkingDays = t.WorkingDays;
                    lbs.WorkingDaysPresent = t.WorkingDaysPresent;
                    lbs.ExtraCurricular = t.ExtraCurricular;
                    lbs.TCApplicationDate = t.TCApplicationDate;
                    lbs.TCIssueDate = DateTime.Now;
                    lbs.ReasonForLeaving = t.ReasonForLeaving;
                    lbs.StudId = t.StudId;
                    lbs.Remarks = t.Remarks;
                    int l = db.SaveChanges();
                    if (l > 0)
                    {

                        return RedirectToAction("StudentTcDataView");
                    }
                }
                else
                {
                    return RedirectToAction("StudentTcDataView");
                }
            }
            catch
            {
                return RedirectToAction("StudentTcDataView");
            }
            return RedirectToAction("StudentTcDataView");

        }
   
        
    }
}
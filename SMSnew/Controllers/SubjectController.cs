using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models; 

namespace SMSnew.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        SMSnewEntities en = new SMSnewEntities();

        public ActionResult Index()
        {
            var cr = new List<Subject>();
            cr = en.Subjects.ToList();
            return View(cr);
           
        }

      

        // GET: Subject
        public ActionResult CreateSubject()
        {
            var classname = (en.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list3 = new SelectList(classname, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.classname = list3;
            return View();
        }

        // POST: SMS/Create
        [HttpPost]
        public ActionResult CreateSubject(FormCollection collection)
        {
            try
            {
                int id = Convert.ToInt32(Session["UserID"]);
                //Session["UserID"] = ud.Userid.ToString();
                //Session["UserName"] = ud.Username.ToString();
                Subject sb = new Subject();
                sb.SubjectName = collection["SubjectName"];
                sb.SubjectClass = collection["SubjectClass"];
                sb.SubjectModifiedDate = DateTime.Now;
                sb.SubjectModifiedBy = id;
                sb.SubjectModifiedDescription = collection["SubjectModifiedDescription"];
                sb.Status = Convert.ToInt32(collection["Status"]);
                en.Subjects.Add(sb);
                int i = en.SaveChanges();
                if (i > 0)
                {
                    return RedirectToAction("CreateSubject");
                }
                else
                {
                    ViewBag.msg = "failed";
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }
        public ActionResult SubjectList()
        {
            return View();
        }

        // GET: SMS/Details/5
        public ActionResult DetailsSubjectList()
        {
            var cr = new List<Subject>();
            cr = en.Subjects.ToList();
            return View(cr);
        }

        public ActionResult EditSubject(int id, string title = "")
        {
            var classname = (en.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list3 = new SelectList(classname, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.classname = list3;
            return View(en.Subjects.Where(i => i.Subjectid == id).FirstOrDefault());
        }

        // POST: SMS/Edit/5
        [HttpPost]
        public ActionResult EditSubject(int id, FormCollection collection)
        {

            try
            {
                Subject cl = en.Subjects.Where(i => i.Subjectid == id).FirstOrDefault();
                cl.SubjectName = collection["SubjectName"];
                cl.SubjectClass = collection["SubjectClass"];
                cl.SubjectModifiedDate = DateTime.Now;
                cl.SubjectModifiedBy = 1;
                cl.SubjectModifiedDescription = collection["SubjectModifiedDescription"];
                cl.Status = Convert.ToInt32(collection["Status"]);
                int j = en.SaveChanges();
                return RedirectToAction("DetailsSubjectList");   
            }
            catch
            {
                return View();
            }
        }
        public JsonResult DeleteAJAX(int subjectid)
        {

           

            Subject data = (from item in en.Subjects where item.Subjectid == subjectid select item).SingleOrDefault();

            en.Subjects.Remove(data);

            en.SaveChanges();

            return Json("Record deleted successfully!");

        }
        public ActionResult DeleteSubject(int id)
        {
             Subject cl = en.Subjects.Where(i => i.Subjectid == id).FirstOrDefault();
                en.Subjects.Remove(cl);
                int j = en.SaveChanges();
                    return RedirectToAction("DetailsSubjectList");
           // return View(en.Subjects.Where(i => i.Subjectid == id).FirstOrDefault());
        }

        // POST: SMS/Delete/5
        //[HttpPost]
        //public ActionResult DeleteSubject(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        Subject cl = en.Subjects.Where(i => i.Subjectid == id).FirstOrDefault();
        //        en.Subjects.Remove(cl);
        //        int j = en.SaveChanges();
        //        if (j > 0)
        //        {
        //            return RedirectToAction("DetailsSubjectList");
        //        }
        //        else
        //        {
        //            ViewBag.msg = "failed";
        //        }
        //        return View();

        //    }
        //    catch
        //    {
        //        return View();
        //    }

        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;

namespace SMSnew.Controllers
{
    public class TeacherAllocationController : Controller
    {
        SMSnewEntities en = new SMSnewEntities();
        // GET: TeacherAllocation
        public ActionResult Index()
        {
            return View();
        }

        // GET: TeacherAllocation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeacherAllocation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherAllocation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherAllocation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeacherAllocation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherAllocation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeacherAllocation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult CreateTeacherAllocation()
        {
            var classname = (en.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list3 = new SelectList(classname, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.classname = list3;
            var teachername = en.Teachers.Select(s => new
            {
                Text = s.TeacherFirstName + " " + s.TeacherLastName,
                Value = s.TeacherID
            })
                 .ToList();

            ViewBag.teachername = new SelectList(teachername, "Value", "Text");
            //var teachername = from name in en.Teachers select name;
            //(en.Teachers).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            //SelectList list4 = new SelectList(teachername, "TeacherID", "TeacherFirstName");//// "ClassRoomID", "ClassRoomDivision", "Class"
            //ViewBag.teachername = list4;
            return View();
        }
        public JsonResult GetDivisionList(string Class)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            List<ClassRoom> DivisionList = en.ClassRooms.Where(x => x.Class == Class).ToList();
            return Json(DivisionList, JsonRequestBehavior.AllowGet);


        }
        // POST: SMS/Create
        [HttpPost]
        public ActionResult CreateTeacherAllocation(FormCollection collection, string Class, String ClassRoomDivision)
        {
            try
            {

                ClassRoom cr = en.ClassRooms.Where(a => a.Class.Equals(Class) && a.ClassRoomDivision.Equals(ClassRoomDivision)).FirstOrDefault();
                cr.ClassRoomTeacherID = Convert.ToInt32(collection["ClassRoomTeacherID"]);
                cr.ClassRoomModifiedBy = 1;
                cr.ClassRoomModifiedDate = DateTime.Now;
                cr.ClassRoomModifiedDescription = collection["ClassRoomModifiedDescription"];
                int j = en.SaveChanges();
                return RedirectToAction("CreateTeacherAllocation");


            }
            catch
            {
                return View();
            }
        }
        public ActionResult TeacherAllocationList()
        {
            return View();
        }

        // GET: SMS/Details/5
        public ActionResult DetailsTeacherAllocationList()
        {
            var cr = new List<vw_ClassRoomTeacherView>();
            cr = en.vw_ClassRoomTeacherView.ToList();
            return View(cr);
        }

        public ActionResult EditTeacherAllocation(int id)
        {

            //var teachername = from name in en.Teachers select name;
            //SelectList list5 = new SelectList(teachername, "TeacherID", "TeacherFirstName");//// "ClassRoomID", "ClassRoomDivision", "Class"
            //ViewBag.teachername = list5;
            var teachername = en.Teachers.Select(s => new
            {
                Text = s.TeacherFirstName + " " + s.TeacherLastName,
                Value = s.TeacherID
            })
                .ToList();

            ViewBag.teachername = new SelectList(teachername, "Value", "Text");
            return View(en.vw_ClassRoomTeacherView.Where(i => i.ClassRoomID == id).FirstOrDefault());
        }

        // POST: SMS/Edit/5
        [HttpPost]
        public ActionResult EditTeacherAllocation(int id, FormCollection collection)
        {

            try
            {
                ClassRoom cr = en.ClassRooms.Where(i => i.ClassRoomID == id).FirstOrDefault();
                cr.ClassRoomTeacherID = Convert.ToInt32(collection["TeacherFullName"]);
                cr.ClassRoomModifiedDescription = collection["ClassRoomModifiedDescription"];
                int j = en.SaveChanges();
                return RedirectToAction("DetailsTeacherAllocationList");
            }
            catch
            {
                return View();
            }
        }
    }
}

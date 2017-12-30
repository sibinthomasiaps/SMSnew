using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;

namespace SMSnew.Controllers
{
    public class SubjectAllocationController : Controller
    {
        SMSnewEntities en = new SMSnewEntities();
        public ActionResult CreateSubjectAllocation()
        {
            var classname = (en.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list3 = new SelectList(classname, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.classname = list3;

            //var division = (en.ClassRooms).GroupBy(p => p.ClassRoomDivision).Select(grp => grp.FirstOrDefault());//.ToList(); 
            //SelectList list1 = new SelectList(division, "Division", "Division");//// "ClassRoomID", "ClassRoomDivision", "Class"
            //ViewBag.division = list1;

            var teachers = (en.Teachers).GroupBy(p => p.TeacherFirstName).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list2 = new SelectList(teachers, "TeacherID", "TeacherFirstName");
            ViewBag.teachers = list2;

            return View();
        }
        public JsonResult GetSubjectAlList(string SubAlClass)
        {

            en.Configuration.ProxyCreationEnabled = false;
            List<Subject> SubjectList = en.Subjects.Where(x => x.SubjectClass == SubAlClass).ToList();
            return Json(SubjectList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDivisionList(string SubAlClass)
        {
            en.Configuration.ProxyCreationEnabled = false;
            List<ClassRoom> DivisionList = null;
            DivisionList = en.ClassRooms.Where(x => x.Class == SubAlClass).ToList();
            return Json(DivisionList, JsonRequestBehavior.AllowGet);
        }
        // POST: SMS/Create
        [HttpPost]
        public ActionResult CreateSubjectAllocation(FormCollection collection, string SubAlClass, string SubAlDivision)
        {
            try
            {
                ClassRoom cr = en.ClassRooms.Where(a => a.Class.Equals(SubAlClass) && a.ClassRoomDivision.Equals(SubAlDivision)).FirstOrDefault();
                int crid = cr.ClassRoomID;
                SubjectAllocation sba = new SubjectAllocation();               
                sba.SubAlSubject = Convert.ToInt32(collection["SubAlSubject"]);
                sba.SubAlIdTeacher = Convert.ToInt32(collection["SubAlIdTeacher"]);
                sba.SubAlClassRoomId = crid;
                sba.SubjectAlModifiedDate = DateTime.Now;
                sba.SubjectAlModifiedBy = Convert.ToInt32("1");
                sba.SubjectAlModifiedDescription = collection["SubjectAlModifiedDescription"];
                en.SubjectAllocations.Add(sba);
                int i = en.SaveChanges();
                if (i > 0)
                {
                    
                    return RedirectToAction("CreateSubjectAllocation");
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

        public ActionResult DetailsSubjectAlList()
        {

            var cr = new List<vw_SubjectAllocationList>();
            cr = en.vw_SubjectAllocationList.ToList();
            return View(cr);

        }
        public ActionResult EditSubjectAlList(int id)
        {
            var teachers = (en.Teachers).GroupBy(p => p.TeacherFirstName).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list2 = new SelectList(teachers, "TeacherFirstName", "TeacherFirstName");
            ViewBag.teachers = list2;
            return View(en.vw_SubjectAllocationList.Where(i => i.SubAlId == id).FirstOrDefault());
        }

        // POST: SMS/Edit/5
        [HttpPost]
        public ActionResult EditSubjectAlList(int id,string TeacherFirstName, FormCollection collection)
        {

            try
            {
                var tid = en.Teachers.Where(t => t.TeacherFirstName == TeacherFirstName).Select(t => t.TeacherID).SingleOrDefault();
                SubjectAllocation cl = en.SubjectAllocations.Where(i => i.SubAlId == id).FirstOrDefault();   
                  cl.SubAlIdTeacher = Convert.ToInt32(tid);
                cl.SubjectAlModifiedDate = DateTime.Now;
                cl.SubjectAlModifiedBy = 1;
                cl.SubjectAlModifiedDescription = collection["SubjectAlModifiedDescription"];
                int j = en.SaveChanges();
                return RedirectToAction("DetailsSubjectAlList");
               
            }
            catch
            {
                return View();
            }
        }
        public JsonResult DeleteAJAX(int subalid)
        {
            SubjectAllocation data = (from item in en.SubjectAllocations where item.SubAlId == subalid select item).SingleOrDefault();

            en.SubjectAllocations.Remove(data);

            en.SaveChanges();

            return Json("Record deleted successfully!");

        }

    }
}
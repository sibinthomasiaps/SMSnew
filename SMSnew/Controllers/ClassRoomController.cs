using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using SMSnew.Models; 

namespace SMSnew.Controllers
{
    
    public class ClassRoomController : Controller
    {
        SMSnewEntities en = new SMSnewEntities();
        // GET: ClassRoom
        public ActionResult CreateClassRoom()
        {
            return View();
        }

        // POST: SMS/Create
        [HttpPost]
        public ActionResult CreateClassRoom(FormCollection collection)
        {
            try
            {

                ClassRoom cl = new ClassRoom();
                cl.Class = collection["Class"];
                cl.ClassRoomDivision = collection["ClassRoomDivision"];
                cl.BuildingName = collection["BuildingName"];
                cl.Remarks = collection["Remarks"];
                cl.ClassRoomModifiedDate = DateTime.Now;
                cl.ClassRoomModifiedBy = 1;
                cl.ClassRoomModifiedDescription = collection["ClassRoomModifiedDescription"];
                cl.Status = Convert.ToInt32(collection["Status"]);
                en.ClassRooms.Add(cl);
                int i = en.SaveChanges();
                if (i > 0)
                {
                    return RedirectToAction("CreateClassRoom");
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
        public ActionResult ClassRoomList()
        {
            return View();
        }

        // GET: SMS/Details/5
        public ActionResult DetailsClassRoomList()
        {
            var cr = new List<ClassRoom>();
            cr = en.ClassRooms.ToList();
            return View(cr);
        }
        public ActionResult EditClassRoom(int id)
        {
            //var classname = (en.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            //SelectList list3 = new SelectList(classname, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            //ViewBag.classname = list3;
            return View(en.ClassRooms.Where(i => i.ClassRoomID == id).FirstOrDefault());
        }

        // POST: SMS/Edit/5
        [HttpPost]
        public ActionResult EditClassRoom(int id, FormCollection collection)
        {

            try
            {
                ClassRoom cr = en.ClassRooms.Where(i => i.ClassRoomID == id).FirstOrDefault();
                cr.Class = collection["Class"];
                cr.ClassRoomDivision = collection["ClassRoomDivision"];
                cr.BuildingName = collection["BuildingName"];
                cr.Remarks = collection["Remarks"];
                cr.ClassRoomModifiedDescription = collection["ClassRoomModifiedDescription"];
                cr.Status = Convert.ToInt32(collection["Status"]);
                cr.ClassRoomModifiedDate = DateTime.Now;
                cr.ClassRoomModifiedBy = 1;
                int j = en.SaveChanges();
                return RedirectToAction("DetailsClassRoomList");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult DeleteAJAX(int classroomid)
        {



            ClassRoom data = (from item in en.ClassRooms

                            where item.ClassRoomID == classroomid

                            select item).SingleOrDefault();

            en.ClassRooms.Remove(data);

            en.SaveChanges();

            return Json("Record deleted successfully!");

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;

namespace SMSnew.Controllers
{
    public class ClassController : Controller
    {

        SMSnewEntities en = new SMSnewEntities();
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        // GET: Class/Details/5
      

        // GET: Class/Create
        public ActionResult CreateClass()
        {
            var cr = new List<Class>();
            cr = en.Classes.ToList();
            return View(cr);
           
        }

        // POST: SMS/Create
        [HttpPost]
        public ActionResult CreateClass(FormCollection collection)
        {
            try
            {

                Class cl = new Class();
                cl.ClassName = collection["ClassName"];
                cl.ClassModifiedDate = DateTime.Now;
                cl.ClassModifiedBy = 1;
                cl.ClassModifiedDescription = "Created";
                cl.ClassStatus = 1; 
                en.Classes.Add(cl);
                en.SaveChanges();
                return RedirectToAction("CreateClass");
           
            }
            catch
            {
                return View();
            }
        }
        // GET: Class/Edit/5
        public ActionResult EditClassList(int id)
        {
            
            var s=en.Classes.Where(i => i.ClassId == id).FirstOrDefault();
            return View(s);
        }

        // POST: Class/Edit/5
        [HttpPost]
        public ActionResult EditClassList(int id, FormCollection collection)
        {

            try
            {
                Class cr = en.Classes.Where(i => i.ClassId == id).FirstOrDefault();
                cr.ClassName = collection["ClassName"];
                cr.ClassStatus=Convert.ToInt32(collection["ClassStatus"]);
                cr.ClassModifiedDescription = collection["ClassModifiedDescription"];
                cr.ClassModifiedDate = DateTime.Now;
                cr.ClassModifiedBy = 1;
                en.SaveChanges();
                return RedirectToAction("CreateClass");
            }
            catch
            {
                return View();
            }
        }
        // GET: Class/Delete/5
     
        public ActionResult DeleteClass(int id)
        {

            Class data = (from item in en.Classes where item.ClassId == id select item).SingleOrDefault();
            en.Classes.Remove(data);
            en.SaveChanges();
            return RedirectToAction("CreateClass");

        }

       
    }
}

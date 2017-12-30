using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;

namespace SMSnew.Controllers
{
    public class DivisionController : Controller
    {

        SMSnewEntities en = new SMSnewEntities();
        public ActionResult Index()
        {
            return View();
        }

        // GET: Class/Details/5


        // GET: Class/Create
        public ActionResult CreateDivision()
        {
            var cr = new List<Division>();
            cr = en.Divisions.ToList();
            return View(cr);

        }

        // POST: SMS/Create
        [HttpPost]
        public ActionResult CreateDivision(FormCollection collection)
        {
            try
            {

                Division cl = new Division();
                cl.DivisionName = collection["DivisionName"];
                cl.DivisionModifiedDate = DateTime.Now;
                cl.DivisionModifiedBy = 1;
                cl.DivisionModifiedDescription = "Created";
                cl.DivisionStatus = 1; ;
                en.Divisions.Add(cl);
                int i = en.SaveChanges();
                return RedirectToAction("CreateDivision");

            }
            catch
            {
                return View();
            }
        }
        // GET: Class/Edit/5
        public ActionResult EditDivisionList(int id)
        {
            return View(en.Divisions.Where(i => i.DivisionId == id).FirstOrDefault());
        }

        // POST: Class/Edit/5
        [HttpPost]
        public ActionResult EditDivisionList(int id, FormCollection collection)
        {

            try
            {
                Division cr = en.Divisions.Where(i => i.DivisionId == id).FirstOrDefault();
                cr.DivisionName = collection["DivisionName"];
                cr.DivisionStatus = Convert.ToInt32(collection["DivisionStatus"]);
                cr.DivisionModifiedDescription = collection["DivisionModifiedDescription"];
                cr.DivisionModifiedDate = DateTime.Now;
                cr.DivisionModifiedBy = 1;
                int j = en.SaveChanges();
                return RedirectToAction("CreateDivision");
            }
            catch
            {
                return View();
            }
        }
        // GET: Class/Delete/5
        public ActionResult DeleteDivision(int id)
        {

            Division data = (from item in en.Divisions where item.DivisionId == id select item).SingleOrDefault();
            en.Divisions.Remove(data);
            en.SaveChanges();
            return RedirectToAction("CreateDivision");

        }
    }
}

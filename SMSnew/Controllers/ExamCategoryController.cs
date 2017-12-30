using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;

namespace SMSnew.Controllers
{
    public class ExamCategoryController : Controller
    {
        // GET: ExamCategory
        SMSnewEntities db = new SMSnewEntities();
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExamCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExamCategory/Create
        public ActionResult CreateExamCategory()
        {
            var cr = new List<ExamCategory>();
            cr = db.ExamCategories.ToList();
            return View(cr);
        }
        [HttpPost]
        public ActionResult CreateExamCategory(FormCollection collection)
        {
            try
            {

                ExamCategory cl = new ExamCategory();
                cl.ExamCategoryName = collection["ExamCategoryName"];
                cl.ExamCategoryDescription = collection["ExamCategoryDescription"];
               
                cl.ExamModifiedDate = DateTime.Now;
                cl.ExamModifiedBy = 1;
                cl.ExamModifiedDescription = "Created";
                cl.ExamStatus = 1;
                db.ExamCategories.Add(cl);
                int i = db.SaveChanges();
                return RedirectToAction("CreateExamCategory");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditExamCategory(int id)
        {
            return View(db.ExamCategories.Where(i => i.ExamCategory1 == id).FirstOrDefault());
        }

        // POST: Class/Edit/5
        [HttpPost]
        public ActionResult EditExamCategory(int id, FormCollection collection)
        {

            try
            {
                ExamCategory cr = db.ExamCategories.Where(i => i.ExamCategory1 == id).FirstOrDefault();
                cr.ExamCategoryName = collection["ExamCategoryName"];
                cr.ExamStatus = Convert.ToInt32(collection["ExamStatus"]);
                cr.ExamCategoryDescription = collection["ExamCategoryDescription"];
                cr.ExamModifiedDescription = collection["ExamModifiedDescription"];
                cr.ExamModifiedDate = DateTime.Now;
                cr.ExamModifiedBy = 1;
                int j = db.SaveChanges();
                return RedirectToAction("CreateExamCategory");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteExamCategory(int id)
        {

            ExamCategory data = (from item in db.ExamCategories where item.ExamCategory1 == id select item).SingleOrDefault();
            db.ExamCategories.Remove(data);
            db.SaveChanges();
            return RedirectToAction("CreateExamCategory");

        }
        // POST: ExamCategory/Create
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

        // GET: ExamCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExamCategory/Edit/5
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

        // GET: ExamCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExamCategory/Delete/5
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
    }
}

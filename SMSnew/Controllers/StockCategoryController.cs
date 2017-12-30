using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;
using System.Data.SqlClient;
using System.Data;
namespace SMSnew.Controllers
{
    public class StockCategoryController : Controller
    {
        SMSnewEntities entSms = new SMSnewEntities();
        // GET: StockCategory
        public ActionResult CreateStockCategory()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStockCategory(FormCollection collection)
        {
            try
            {
                StockCategory Category = new StockCategory();
                Category.CategoryName = collection["CategoryName"];
                entSms.StockCategories.Add(Category);
                entSms.SaveChanges();
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ListStockCategory()
        {
            try
            {
                return View(entSms.StockCategories.ToList());
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditStockCategory(int? id)
        {
            try
            {
                return View(entSms.StockCategories.Where(C => C.CategoryId == id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return View();
            }
           
        }

        [HttpPost]
        public ActionResult EditStockCategory(int? id, FormCollection collection)
        {
            try
            {
                StockCategory Category = new StockCategory();
                Category = entSms.StockCategories.Find(id);
                Category.CategoryName = collection["CategoryName"];
                entSms.SaveChanges();
                return RedirectToAction("ListStockCategory");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteStockCategory(int? id)
        {
            try
            {
                StockCategory Category = new StockCategory();
                Category = entSms.StockCategories.Find(id);
                entSms.StockCategories.Remove(Category);
                entSms.SaveChanges();
                return RedirectToAction("ListStockCategory");
            }
            catch
            {
                return View();
            }
           
        }

        [HttpGet]
        public ActionResult GetSubs()
        {
            var ddlClass = entSms.Classes.ToList();
            SelectList listClass = new SelectList(ddlClass, "ClassId", "ClassName");
            ViewBag.ddlCategory = listClass;
            return View();
        }
        public JsonResult GetSubsOfClass(string clName)
        {
          
            var subs=(from s in entSms.Subjects where s.SubjectClass==clName select s.SubjectName ).ToList();
            ViewBag.subs = subs;
            return Json(subs, JsonRequestBehavior.AllowGet);
        }
    }
}
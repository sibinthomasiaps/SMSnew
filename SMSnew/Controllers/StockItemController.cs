using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;
namespace SMSnew.Controllers
{
    public class StockItemController : Controller
    {
        private SMSnewEntities entSms = new SMSnewEntities();       // GET: StockItem
        [HttpGet]
        public ActionResult CreateStockItem()
        {
            try
            {
                var ddlCategory = entSms.StockCategories.ToList();
                SelectList listCategory = new SelectList(ddlCategory, "CategoryId", "CategoryName");
                ViewBag.ddlCategory = listCategory;
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStockItem(FormCollection collection)
        {
            try
            {
                StockItem Item = new StockItem();
                Item.CategoryId = Convert.ToInt32(collection["CategoryId"]);
                Item.ItemName = collection["ItemName"];
                Item.ItemUnit = collection["ItemUnit"];
                Item.ItemUnitPrice = Convert.ToDouble(collection["ItemUnitPrice"]);
                Item.ItemDescription = collection["ItemDescription"];
                Item.ItemTaxPercentage = Convert.ToDouble(collection["ItemTaxPercentage"]);
                Item.ItemTaxAmount = Convert.ToDouble(collection["ItemTaxAmount"]);
                entSms.StockItems.Add(Item);
                entSms.SaveChanges();
                return RedirectToAction("CreateStockItem");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ListStockItem()
        {
            return View(entSms.vw_ListStockItem.ToList());
        }

        [HttpGet]
        public ActionResult DeleteStockItem(int? id)
        {
            StockItem ST = new StockItem();

            ST=entSms.StockItems.Where(S=>S.ItemId==id).FirstOrDefault();
            entSms.StockItems.Remove(ST);
            entSms.SaveChanges();
            return RedirectToAction("ListStockItem");
        }
        [HttpGet]
        public ActionResult EditStockItem(int? id)
        {
            try
            {
                var ddlCategory = entSms.StockCategories.ToList();
                SelectList listCategory = new SelectList(ddlCategory, "CategoryId", "CategoryName");
                ViewBag.ddlCategory = listCategory;
                return View(entSms.StockItems.Where(S=>S.ItemId==id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStockItem(int? id, FormCollection collection)
        {
            StockItem item = new StockItem();
            item = entSms.StockItems.Where(S => S.ItemId == id).FirstOrDefault();
            item.CategoryId =Convert.ToInt32(collection["CategoryId"]);
            item.ItemName = collection["ItemName"];
            item.ItemUnit = collection["ItemUnit"];
            item.ItemUnitPrice =Convert.ToDouble( collection["ItemUnitPrice"]);
            item.ItemDescription = collection["ItemDescription"];
            item.ItemTaxPercentage = Convert.ToDouble(collection["ItemTaxPercentage"]);
            item.ItemTaxAmount = Convert.ToDouble( collection["ItemTaxAmount"]);
            entSms.SaveChanges();
            return RedirectToAction("ListStockItem");
        }
    }
}
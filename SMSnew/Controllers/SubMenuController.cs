using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;

namespace SMSnew.Controllers
{
    public class SubMenuController : Controller
    {
        // GET: SubMenu
        SMSnewEntities db = new SMSnewEntities();
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubMenu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubMenu/Create
        public ActionResult CreateSubMenu()
        {
            var menuname = (db.MainMenus).GroupBy(p => p.MenuName).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list3 = new SelectList(menuname, "MainMenuId", "MenuName");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.menuname = list3;
            return View();
        }

        // POST: SubMenu/Create
        [HttpPost]
        public ActionResult CreateSubMenu(FormCollection collection)
        {
            //    try
            //    {
            //        //int id = Convert.ToInt32(Session["UserID"]);
            //        //Session["UserID"] = ud.Userid.ToString();
            //        //Session["UserName"] = ud.Username.ToString();
            //        SubMenu sb = new SubMenu();
            //        sb.MenuId =Convert.ToInt32(collection["MenuId"]);
            //        sb.SubMenuName = collection["SubMenuName"];
            //        sb.SubMenuControllerName = collection["SubMenuControllerName"];
            //        sb.SubMenuPath = collection["SubMenuPath"];
            //        db.MenuSubMenus.Add(sb);
            //        int i = db.SaveChanges();
            //        if (i > 0)
            //        {
            //            return RedirectToAction("CreateSubMenu");
            //        }
            //        else
            //        {
            //            ViewBag.msg = "failed";
            //            return View();
            //        }

            //    }
            //    catch
            //    {
            //        return View();
            //    }
            return View();
        }

        // GET: SubMenu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubMenu/Edit/5
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

        // GET: SubMenu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubMenu/Delete/5
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

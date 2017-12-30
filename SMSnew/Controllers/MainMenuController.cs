using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;

namespace SMSnew.Controllers
{
    public class MainMenuController : Controller
    {
        SMSnewEntities db = new SMSnewEntities();
        // GET: MainMenu
        public ActionResult Index()
        {
            return View();
        }

        // GET: MainMenu/Details/5
        public ActionResult DetailsMainMenu()
        {
            var cr = new List<MainMenu>();
            cr = db.MainMenus.ToList();
            return View(cr);
        }
        public JsonResult ChangeUser(MainMenu mainmenu)
        {
            // Update model to your db  
            MainMenu cl = db.MainMenus.Where(i => i.MainMenuId == mainmenu.MainMenuId).FirstOrDefault();
            cl.MenuName = mainmenu.MenuName;
           
            int j = db.SaveChanges();
            string message = "Success";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteMenu(int MainMenuId)
        {
            // Update model to your db  
            MainMenu cl = db.MainMenus.Where(i => i.MainMenuId == MainMenuId).FirstOrDefault();
            db.MainMenus.Remove(cl);
            db.SaveChanges();
            string message = "Success";
            return Json(message, JsonRequestBehavior.AllowGet);
        }  
        // GET: MainMenu/Create
        public ActionResult CreateMainMenu()
        {
           
            var cr = new List<MainMenu>();
            cr = db.MainMenus.ToList();
            return View(cr);
        }

        // POST: MainMenu/Create
        [HttpPost]
       public ActionResult CreateMainMenu(FormCollection collection)
        {
             MainMenu cl = new MainMenu();
             cl.MenuName = collection["MenuName"];
             db.MainMenus.Add(cl);
             db.SaveChanges();
             return RedirectToAction("CreateMainMenu");          
        }

        // GET: MainMenu/Edit/5
        public ActionResult EditMainMenu(int id)
        {
            return View(db.MainMenus.Where(i => i.MainMenuId == id).FirstOrDefault());
        }


        // POST: MainMenu/Edit/5
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

        // GET: MainMenu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MainMenu/Delete/5
        [HttpPost]
        public ActionResult DeleteMainMenu(int id)
        {

            MainMenu data = (from item in db.MainMenus where item.MainMenuId == id select item).SingleOrDefault();
            db.MainMenus.Remove(data);
            db.SaveChanges();
            return RedirectToAction("CreateMainMenu");

        }

    }
}

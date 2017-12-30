using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;
using System.IO;

namespace SMSnew.Controllers
{
    public class EventController : Controller
    {
        SMSnewEntities sms = new SMSnewEntities();
         
        // GET: Event
        public ActionResult CreateEvent()
        {
            try
            {
                ViewBag.EventFilePath = Server.MapPath("~/uploads/Event");
                var ddlEventInCharge = sms.Employees.ToList();
                SelectList list = new SelectList(ddlEventInCharge, "EmployeeID", "EmpFirstName");
                ViewBag.ddlEventInCharge = list;
                SelectList lstStatus = new SelectList(
                    new List<SelectListItem>
                {
                    new SelectListItem{Selected=false,Text="Active",Value="Active"},
                    new SelectListItem{Selected=false,Text="Inactive",Value="Inactive"},
                }, "Value", "Text");
                ViewBag.ddlStatus = lstStatus;
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent(FormCollection collection, HttpPostedFileBase file)
        {
            try
            {

                Event evt = new Event();
                evt.EventType = collection["EventType"];
                evt.EventName = collection["EventName"];
                evt.EventVenue = collection["EventVenue"];
                evt.EventLocation = collection["EventLocation"];
                evt.EventCountry = collection["EventCountry"];
                evt.EventDetails = collection["EventDetails"];
                evt.EventEmail = collection["EventEmail"];
                evt.EventPH =collection["EventPH"];
                evt.EventFax = collection["EventFax"];
                evt.EventParticipantsNumber = Convert.ToInt32(collection["EventParticipantsNumber"]);
                evt.EventInCharge = Convert.ToInt32(collection["EventInCharge"]);
                evt.CheckInDate =Convert.ToDateTime(collection["CheckInDate"]);
                evt.CheckOutDate =Convert.ToDateTime(collection["CheckOutDate"]);
                if (file != null) 
                { 
                     var allowedExtensions = new[] { ".docx", ".xlsx", ".txt", ".pdf", ".docm", ".xlsm",".rtf" };
                     var ext=Path.GetExtension(file.FileName);
                         if (allowedExtensions.Contains(ext))
                         {
                            if (!Directory.Exists(Server.MapPath("~/uploads/Event")))
                            {
                             Directory.CreateDirectory(Server.MapPath("~/uploads/Event"));
                            }
                            string _FileName = Path.GetFileName(file.FileName);
                            string _Path = Path.Combine(Server.MapPath("~/uploads/Event"), _FileName);
                            file.SaveAs(_Path);
                            evt.UploadFiles = _FileName;
                         }
                }
                evt.Status = collection["Status"];
                sms.Events.Add(evt);
                sms.SaveChanges();
                return RedirectToAction("IndexEvent");

            }
            catch(Exception ex)
            {
                return View();
            }
           
        }
        
        [HttpGet]
        public ActionResult IndexEvent()
        {
            try
            {
                return View(sms.vw_IndexEvent.ToList());
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult EditEvent(int? id)
        {
            try
            {
                var UploadedFileName = sms.Events.Where(x => x.EventRegID == id).Select(x=>x.UploadFiles).SingleOrDefault();
                ViewBag.filname=UploadedFileName;
                ViewBag.EventFilePath = Server.MapPath("~/uploads/Event");
                var ddlEventInCharge = sms.Employees.ToList();
                SelectList list = new SelectList(ddlEventInCharge, "EmployeeID", "EmpFirstName");
                ViewBag.ddlEventInCharge = list;

                SelectList lstStatus = new SelectList(
                    new List<SelectListItem>
                {
                    new SelectListItem{Selected=false,Text="Active",Value="Active"},
                    new SelectListItem{Selected=false,Text="Inactive",Value="Inactive"},
                }, "Value", "Text");
                ViewBag.ddlStatus = lstStatus;
                return View(sms.Events.Where(model => model.EventRegID == id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult EditEvent(int? id, FormCollection collection,HttpPostedFileBase file)
        {
            try
            {
                Event evt = new Event();
                evt = sms.Events.Find(id);
                evt.EventType = collection["EventType"];
                evt.EventName = collection["EventName"];
                evt.EventVenue = collection["EventVenue"];
                evt.EventLocation = collection["EventLocation"];
                evt.EventCountry = collection["EventCountry"];
                evt.EventDetails = collection["EventDetails"];
                evt.EventEmail = collection["EventEmail"];
                evt.EventPH = collection["EventPH"];
                evt.EventFax = collection["EventFax"];
                evt.EventParticipantsNumber = int.Parse(collection["EventParticipantsNumber"]);
                evt.EventInCharge = int.Parse(collection["EventInCharge"]);
                evt.CheckInDate = Convert.ToDateTime(collection["CheckInDate"]);
                evt.CheckOutDate = Convert.ToDateTime(collection["CheckOutDate"]);
                if (file != null)
                {
                    var allowedExtensions = new[] { ".docx", ".xlsx", ".txt", ".pdf", ".docm", ".xlsm", ".rtf" };
                    var ext = Path.GetExtension(file.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        if (!Directory.Exists(Server.MapPath("~/uploads/Event")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/uploads/Event"));
                        }
                        var ExistingFilePath = Path.Combine(Server.MapPath("~/uploads/Event"), evt.UploadFiles);
                        System.IO.File.Delete(ExistingFilePath);
                        string _FileName = Path.GetFileName(file.FileName);
                        string _Path = Path.Combine(Server.MapPath("~/uploads/Event"), _FileName);
                        file.SaveAs(_Path);
                        evt.UploadFiles = _FileName;
                    }

                }
                evt.Status = collection["Status"];
                sms.SaveChanges();

                return RedirectToAction("IndexEvent");
            }
            catch (Exception ex)
            {
                return View();
            }
           
        }

        public ActionResult DeleteEvent(int? id)
        {
            try
            {
                Event evt = sms.Events.Find(id);
                if (evt.UploadFiles != null)
                {
                    var ExistingFilePath = Path.Combine(Server.MapPath("~/uploads/Event"), evt.UploadFiles);
                    System.IO.File.Delete(ExistingFilePath);
                }

                sms.Events.Remove(evt);
                sms.SaveChanges();
                return RedirectToAction("IndexEvent");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public JsonResult CheckFileExist(string UploadedFilePath,string FullFileName)

        {
            var status = "Not Exist";
            var fileExtension = Path.GetExtension(FullFileName);
            string[] validExtensions = {".docx", ".xlsx",".txt",".pdf",".docm",".xlsm",".rtf" };
            string allowdedFile = Array.Find(validExtensions, f => f.Equals(fileExtension));
            if (!string.IsNullOrWhiteSpace(allowdedFile))
            {
                if (System.IO.File.Exists(UploadedFilePath))
                {
                    status = "Exist";
                }
            }
            else
            {
                status = "Invalid";
            }
           
            return Json(status,JsonRequestBehavior.AllowGet);

        }

    }
}
using SMSnew.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSnew.Controllers
{
    public class ParentController : Controller
    {
         SMSnewEntities db = new  SMSnewEntities();

        // GET: Parent
        public ActionResult Index()
        {
            return View();

        }

        [HttpGet]

        public ActionResult parentreg()
        {
                         return View();

        }

        [HttpPost]
        public ActionResult parentreg(Parent ud,string submit,string cancel)
        {
            
           
            
                if (!string.IsNullOrEmpty(submit))
                {
                User us = new User();
                    Parent uds = new Parent();
                  
                    uds.ParentName = ud.ParentName;
                
                    uds.ParentPH = ud.ParentPH;
                    uds.ParentFax = ud.ParentFax;
                    uds.ParentGender = ud.ParentGender;
                    uds.ParentStatus = ud.ParentStatus;
                    uds.ParentAddress1 = ud.ParentAddress1;
                    uds.ParentState = ud.ParentState;
                    uds.ParentAddress2 = ud.ParentAddress2;
                    uds.ParentCountry = ud.ParentCountry;
                    uds.ParentCity = ud.ParentCity;
                    uds.ParentPINcode = ud.ParentPINcode;
                string imagetype = null;
                if (uds.ParentGender == "Male")
                {
                    imagetype = "male-avatar.jpg";
                }
                else
                {
                    imagetype = "female-avatar.jpg";
                }
                uds.Photo = imagetype;

                var k = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);
                uds.ParRegId = "p" + k;
                //PASSWORD
                SMSnew.Models.passwordgen p = new SMSnew.Models.passwordgen();
                var tuple = p.password();
                string pas = tuple.Item1;
                string enpas = tuple.Item2;

               
                //ViewBag.msg = msg;
                //TempData["message"] = ViewBag.msg;

                uds.ParentModifiedDate = DateTime.Now;

                
                db.Parents.Add(uds);
                db.SaveChanges();
                us.Password = enpas;
                us.RegId = uds.ParRegId;
                us.Username = us.RegId;
                //us.Mailid = ud.mailid;
                us.UserType = "Parent";
                
                us.Status = 1;
                db.Users.Add(us);
                db.SaveChanges();
                //EMAIL
                SMSnew.Models.Emailuserdetails sendmail = new SMSnew.Models.Emailuserdetails();
                //string msg = sendmail.emailgen(uds.ParRegId, pas, ud.mailid, uds.ParentName);


            }
               
            else
            {
                return RedirectToAction("parentreg", "Parent");
            }

            return View();

        }




    }
}

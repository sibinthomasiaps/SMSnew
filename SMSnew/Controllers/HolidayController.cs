using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;
namespace SMSnew.Controllers
{
    public class HolidayController : Controller
    {
        SMSnewEntities db = new SMSnewEntities();
        // GET: Holiday
        public ActionResult Index()
        {
            return View();
        }
        // GET: Holiday


        [HttpGet]
        public ActionResult Holidayregi()
        {
            return View();
        }


        public ActionResult StudHolidayView()
        {
            int c = db.Holidays.Where(i => i.HolidayStatus == "Active").Select(i => i.HolidayDate).Count();
            ViewBag.count = c;
            var data = db.Holidays.Where(i => i.HolidayStatus == "Active").ToList();
            ViewBag.holiday = data;

            //int ca = en.Attendances.Where(i => i.StudentID == 1035 && i.AttStatus == "Absent").Select(i => i.AttendanceDate).Count();
            //ViewBag.count = ca;
            //var dataa = en.Attendances.Where(i => i.StudentID == 1035 && i.AttStatus == "Absent").ToList();
            //ViewBag.attendancea = dataa;
            return View();
        }


        [HttpPost]

        public ActionResult Holidayregi(FormCollection collection)
        {

            try
            {



                Holiday hol = new Holiday();
                hol.HolidayDate = Convert.ToDateTime(collection["HolidayDate"]);
                DateTime da = Convert.ToDateTime(collection["HolidayDate"]);
                var data = db.Holidays.Where(d => d.HolidayDate == da).ToList();
                ViewBag.date = data;
                foreach (var item in ViewBag.date)
                {
                    DateTime dat = item.HolidayDate;
                    if (dat == da)
                    {
                        ViewBag.msg1 = "Date already Exist";
                        //return View();
                    }
                }

                hol.HolidayDescription = collection["HolidayDescription"];
                //hol.HolidayStatus = collection["HolidayStatus"];
                hol.HolidayStatus = collection["HolidayStatus"];
                db.Holidays.Add(hol);
                int j = db.SaveChanges();
                if (j > 0)
                {
                    ViewBag.msg = "sucess";
                    return View();
                }

                return View();
            }

            catch
            {
                return View();
            }
        }
        public ActionResult Holidaygrid(String holidaydate, String holidaydescription, String holidaystatus)
        {
            if (holidaydate != "")
            {

                DateTime holdate = Convert.ToDateTime(holidaydate);
                return View(db.Holidays.Where(d => d.HolidayDate == holdate || holidaydate == null).ToList());

            }
            else if (holidaydescription != "")
            {


                return View(db.Holidays.Where(d => d.HolidayDescription == holidaydescription).ToList());

            }

            else if (holidaystatus != "")
            {
                return View(db.Holidays.Where(d => d.HolidayStatus == holidaystatus).ToList());
            }
            else
            {
                return View(db.Holidays.ToList());
            }

        }
        public ActionResult sample()
        {
            return View();
        }
    }
}
using SMSnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;

namespace SMSnew.Controllers
{
    public class SalaryController : Controller
    {
        SMSnewEntities db = new SMSnewEntities();
        // GET: Salary
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(Group gd)
        {
            return View();
        }

        [HttpGet]

        public ActionResult Salary()
        {
            var data1 = (from Employee in db.Employees//.Take(15)

                         select Employee).ToList();
            ViewBag.userdetails = data1;

            var data = db.Salaries.ToList();
            ViewBag.date = data;

            //var data = db.Salaries.Where(d => d.SalDate == da).ToList();
            //ViewBag.date = data;

            return View();
        }


        [HttpPost]

        public ActionResult Salary(FormCollection collection)
        {


            try
            {



                Salary sal = new Salary();
                sal.SalEmployeeID = Convert.ToInt32(collection["Empid"]);
                int id = Convert.ToInt32(collection["Empid"]);
                sal.SalDate = Convert.ToDateTime(collection["Salarydate"]);

                sal.SalAmount = Convert.ToInt32(collection["Salaryamount"]);

                DateTime da = Convert.ToDateTime(collection["Salarydate"]);
                //ViewBag.selectdate = da;



                db.Salaries.Add(sal);
                int j = db.SaveChanges();
                if (j > 0)
                {
                    ViewBag.msg = "sucess";
                    return RedirectToAction("Salary");

                }

            }

            catch
            {

            }
            return View();
        }

        public ActionResult Salarygrid(String getgroup, String saldate, String salamount)
        {
            var getgroup1 = (db.Employees).GroupBy(p => p.EmpFirstName).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list = new SelectList(getgroup1, "EmpFirstName", "EmpFirstName");//// 
            ViewBag.getgroup = list;

            if (getgroup != "")
            {

                //int empname = Convert.ToInt32(getgroup);
                return View(db.vw_empsal.Where(d => d.EmpFirstName == getgroup || getgroup == null).ToList());

            }
            else if (saldate != "")
            {

                DateTime salarydate = Convert.ToDateTime(saldate);
                return View(db.vw_empsal.Where(d => d.SalDate == salarydate).ToList());

            }

            else if (salamount != "")
            {
                int salam = Convert.ToInt32(salamount);
                //int salaryamount = Convert.ToInt32(salamount);
                return View(db.vw_empsal.Where(d => d.SalAmount == salam).ToList());
            }
            else
            {
                return View(db.vw_empsal.ToList());
            }


        }
    }
}
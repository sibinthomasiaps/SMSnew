using SMSnew.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSnew.Controllers
{
    public class EmployeeController : Controller
    {
        SMSnewEntities db = new SMSnewEntities();

        // GET: Employee
        public ActionResult Index()
        {
            return View();

        }



        public ActionResult Employeegrid()
        {
            var cr = new List<Employee>();
            cr = db.Employees.Where(i => i.EmpActive == 1).ToList();
            return View(cr);


        }
        public ActionResult EmployeeGridDelete(int id)
        {
            try
            {

                Employee dep = db.Employees.Where(i => i.EmployeeID == id).FirstOrDefault();
                dep.EmpActive = 0;
                int j = db.SaveChanges();
                if (j > 0)
                {

                    return RedirectToAction("Employeegrid");
                }
                else
                {
                    ViewBag.msg = "failed";
                }
                return RedirectToAction("Employeegrid");

            }
            catch
            {
                return RedirectToAction("Employeegrid");
            }

        }
        [HttpGet]
        public ActionResult EmployeeInsert()
        {

            return View();
        }



        public ActionResult EmployeeRegistration(string lname, string fname, string gender, string bloodgroup, string dob, string joindate, string contactno, string email, string address1, string address2, string city, string state, string postcode, string country, string experience, string expdescription, string RollNumber, string Designation, string Department, string Photo, string username, string passsword, string Status)
        {

            Employee te = new Employee();
            te.EmpDesignation = Designation;
            te.EmpPhoto = Photo;
            te.EmpFirstName = fname;
            te.EmpLastName = lname;
            if (joindate != "")
            {
                te.EmpJoinedDate = Convert.ToDateTime(joindate);
            }
            te.EmpPhone = contactno;
            te.EmpEmail = email;
            te.EmpAddress1 = address1;
            te.EmpAddress2 = address2;
            te.EmpCity = city;
            te.EmpState = state;
            te.EmpLastLoginDate = DateTime.Now;
            te.EmpPINcode = postcode;
            te.EmpActive = 1;
            te.EmpCountry = country;
            te.EmpExpDescription = expdescription;
            if (experience != "")
            {
                te.EmpExperienced = Convert.ToInt32(experience);
            }
            te.EmpGender = gender;
            te.EmpBloodGroup = bloodgroup;
            te.EmpDOB = Convert.ToDateTime(dob);

            te.EmpStatus = Status;
            // te.Userid = 22;
            string imagetype = null;
            if (gender == "Male")
            {
                imagetype = "male-avatar.jpg";
            }
            else
            {
                imagetype = "female-avatar.jpg";
            }
            te.EmpPhoto = imagetype;
            var k = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);
            te.EmpRegId = "E" + k;
            db.Employees.Add(te);
            int i = db.SaveChanges();
            if (i > 0)
            {
                smsclass.passwordgen p = new smsclass.passwordgen();
                var tuple = p.password();
                string pas = tuple.Item1;
                string enpas = tuple.Item2;


                User ue = new User();
                ue.Mailid = email;
                ue.RegId = te.EmpRegId;
                ue.UserType = "Employee";
                ue.LastLoginDate = DateTime.Now;
                ue.Mailid = te.EmpEmail;
                ue.Status = 1;
                ue.Username = te.EmpRegId;
                ue.Password = enpas;
                db.Users.Add(ue);
                smsclass.Emailuserdetails sendmail = new smsclass.Emailuserdetails();
                string msg = sendmail.emailgen(te.EmpRegId, pas, email, fname);
                ViewBag.msg = msg;
                TempData["message"] = ViewBag.msg;

                int s = db.SaveChanges();
                {
                    return RedirectToAction("EmployeeInsert");
                }
            }
            return RedirectToAction("EmployeeInsert");
        }

        [HttpGet]
        public ActionResult EmployeeGridEdit(int id)
        {

            return View(db.Employees.Where(i => i.EmployeeID == id).FirstOrDefault());
        }
        public ActionResult EmployeeGridEdit(int id, string lname, string fname, string gender, string bloodgroup, string dob, string joindate, string contactno, string email, string address1, string address2, string city, string state, string postcode, string country, string experience, string expdescription, string RollNumber, string Designation, string Department, string Photo, string username, string passsword, string Status)
        {

            return View();
        }


        public ActionResult EmployeeEditing(string lname, string fname, string gender, string bloodgroup, string dob, string joindate, string contactno, string email, string address1, string address2, string city, string state, string postcode, string country, string experience, string expdescription, string RollNumber, string Designation, string Department, string Photo, string username, string passsword, string Status, string ModifiedDescription, int id)
        {
            try
            {
                Employee te = db.Employees.Where(i => i.EmployeeID == id).FirstOrDefault();
                te.EmpDesignation = Designation;
                te.EmpPhoto = Photo;
                te.EmpFirstName = fname;
                te.EmpLastName = lname;
                if (joindate != "")
                {
                    te.EmpJoinedDate = Convert.ToDateTime(joindate);
                }
                te.EmpPhone = contactno;
                te.EmpLastLoginDate = DateTime.Now;
                te.EmpEmail = email;
                te.EmpAddress1 = address1;
                te.EmpAddress2 = address2;
                te.EmpCity = city;
                te.EmpState = state;
                te.EmpPINcode = postcode;
                te.EmpCountry = country;
                te.EmpExpDescription = expdescription;
                if (experience != "")
                {
                    te.EmpExperienced = Convert.ToInt32(experience);
                }
                te.EmpGender = gender;
                te.EmpBloodGroup = bloodgroup;
                if (dob != "")
                {
                    te.EmpDOB = Convert.ToDateTime(dob);
                }

                te.EmpStatus = Status;

                // te.Userid = 22;
                te.EmpModifiedBy = 22;

                te.EmpModifiedDate = DateTime.Now;

                te.EmpModifiedDescription = ModifiedDescription;
                int l = db.SaveChanges();
                if (l > 0)
                {
                    return RedirectToAction("Employeegrid");
                }
            }
            catch
            {
                return RedirectToAction("Employeegrid");
            }
            return RedirectToAction("Employeegrid");
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;
using System.Web.Security;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;


namespace SMSnew.Controllers
{
    public class TeacherController : Controller
    {
        SMSnewEntities en =new SMSnewEntities();
        
       public ActionResult IndexTeacher()
        {

            int userid = Convert.ToInt32(Session["UserID"]);
            string regid = Convert.ToString(Session["UserName"]);
            var photo = (from us in en.Teachers where us.TcrRegId == regid select us.Photo).Single();
            ViewBag.imgprofile = photo;
            return View();
         
        }
        
        
        // GET: Teacher
         public ActionResult CreateTeacher()
        {
            string msg2 = Convert.ToString(TempData["message"]);
            ViewBag.msg1 = msg2;
            return View();
        }

        [HttpPost]
        public ActionResult CreateTeacher(FormatException collection)
        {
           
            return View();
        }

        public ActionResult TeacherInsert(string fname, string lname, string gender, string bloodgroup, string dob, string joindate, string contactno, string email, string address1, string address2, string city, string state, string postcode, string country, string experience, string qualification, string expDescription)
        {
           
            Teacher te = new Teacher();
            te.TeacherFirstName = fname;
            te.TeacherLastName = lname;
            te.TeacherGender = gender;
            te.TeacherBloodGroup = bloodgroup;
            te.TeacherpDOB = Convert.ToDateTime(dob);
            te.TeacherJoinedDate = Convert.ToDateTime(joindate);
            te.TeacherContactNumber = Convert.ToInt32(contactno);
            te.TeacherEmail = email;
            te.TeacherAddress1 = address1;
            te.TeacherAddress2 = address2;
            te.TeacherCity = city;
            te.TeacherState = state;
            te.TeacherCountry = country;
            te.TeacherPINcode = postcode;
            te.TeacherQualification = qualification;
            te.TeacherExperienced = Convert.ToInt32(experience);
            te.TeacherExpDescription = expDescription;
            te.TeacherModifiedBy = 1;
            te.TeacherModifiedDate = DateTime.Now;
            te.TeacherModifiedDescription = "registered";
            te.TeacherActive = 1;

            var k = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);
            string regid="T" + k;
            te.TcrRegId = regid;

            string imagetype = null;
            if (gender == "Male")
            {
                imagetype = "male-avatar.jpg";
            }
            else
            {
                imagetype = "female-avatar.jpg";
            }
            te.Photo = imagetype; 
            en.Teachers.Add(te);
            int x = en.SaveChanges();


            //--------------auto generte password---------------///
            smsclass.passwordgen p = new smsclass.passwordgen();
            var tuple = p.password();
            string pas = tuple.Item1;
            string enpas = tuple.Item2;
            //-------------end autogenerate password--------------------//

            User us = new User();
            us.RegId = regid;
            us.UserType = "Teacher";
            us.Username = regid;
            us.Status = 1;
            us.Mailid = email;
            us.Password = enpas;
            en.Users.Add(us);
            int y = en.SaveChanges();


            //--------------auto generte Email---------------///
            smsclass.Emailuserdetails sendmail = new smsclass.Emailuserdetails();
            string msg = sendmail.emailgen(regid, pas, email, fname);
            ViewBag.msg = msg;
            TempData["message"] = ViewBag.msg;
            //-------------end autogenerate Email--------------------//

            return RedirectToAction("CreateTeacher");
        }
        public ActionResult DetailsTeacherList()
        {

            var cr = new List<Teacher>();
            cr = en.Teachers.Where (i=>i.TeacherActive==1).ToList();
            return View(cr);

        }
        public ActionResult EditTeacherList(int id)
        {
            return View(en.Teachers.Where(i => i.TeacherID == id).FirstOrDefault());
        }
       
        public ActionResult TeacherEdit1(string fname, string lname, string gender, string bloodgroup, string dob, string joindate, string contactno, string email, string address1, string address2, string city, string state, string postcode, string country, string experience, string qualification, string expDescription, string description,string id)
        {
            int teacherid = Convert.ToInt32(id);

            Teacher te = en.Teachers.Where(j => j.TeacherID == teacherid).FirstOrDefault(); 
            te.TeacherFirstName = fname;
            te.TeacherLastName = lname;
            te.TeacherGender = gender;
            te.TeacherBloodGroup = bloodgroup;
            te.TeacherpDOB = Convert.ToDateTime(dob);
            te.TeacherJoinedDate = Convert.ToDateTime(joindate);
            te.TeacherContactNumber = Convert.ToInt32(contactno);
            te.TeacherEmail = email;
            te.TeacherAddress1 = address1;
            te.TeacherAddress2 = address2;
            te.TeacherCity = city;
            te.TeacherState = state;
            te.TeacherCountry = country;
            te.TeacherPINcode = postcode;
            te.TeacherQualification = qualification;
            te.TeacherExperienced = Convert.ToInt32(experience);
            te.TeacherExpDescription = expDescription;
            te.TeacherModifiedBy = 1;
            te.TeacherModifiedDate = DateTime.Now;
            te.TeacherModifiedDescription = description;
            //te.TeacherRollNumber = "TE1000";
            te.TeacherActive = 1;
           // te.Userid = 100;
            // te.TeacherLastLoginDate = DateTime.Now;
           // en.Teachers.Add(te);
            int i = en.SaveChanges();
            return RedirectToAction("DetailsTeacherList");
        }

        public JsonResult DeleteAJAX(int teacherid)
        {

            Teacher data = (from item in en.Teachers where item.TeacherID == teacherid select item).SingleOrDefault();
            data.TeacherActive = 0;
            //en.Students.Remove(data);
            en.SaveChanges();
            return Json("Record deleted successfully!");

        }
        public ActionResult DeleteTeacher(int id)
        {
            Teacher cl = en.Teachers.Where(i => i.TeacherID == id).FirstOrDefault();
            cl.TeacherActive = 0;
            //en.Students.Remove(cl);
            int j = en.SaveChanges();
            return RedirectToAction("DetailsTeacherList");
            // return View(en.Subjects.Where(i => i.Subjectid == id).FirstOrDefault());
        }
        public ActionResult CreateTeacherAllocation()
        {
            var classname = (en.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list3 = new SelectList(classname, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.classname = list3;
            var teachername = from name in en.Teachers select name;
                //(en.Teachers).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list4 = new SelectList(teachername, "TeacherID", "TeacherFirstName");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.teachername = list4;
            return View();
        }
        public JsonResult GetDivisionList(string Class)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            List<ClassRoom>DivisionList = en.ClassRooms.Where(x => x.Class == Class ).ToList();
            return Json(DivisionList, JsonRequestBehavior.AllowGet);


        }
        // POST: SMS/Create
        [HttpPost]
        public ActionResult CreateTeacherAllocation(FormCollection collection,string Class,String ClassRoomDivision)
        {
            try
            {
              
                ClassRoom cr = en.ClassRooms.Where(a => a.Class.Equals(Class) && a.ClassRoomDivision.Equals(ClassRoomDivision)).FirstOrDefault();
                cr.ClassRoomTeacherID = Convert.ToInt32(collection["TeacherID"]);
                cr.ClassRoomModifiedBy = 1;
                cr.ClassRoomModifiedDate = DateTime.Now;
                cr.ClassRoomModifiedDescription = collection["ClassRoomModifiedDescription"];
                int j = en.SaveChanges();
                return RedirectToAction("CreateTeacherAllocation");
              

            }
            catch
            {
                return View();
            }
        }
        public ActionResult TeacherAllocationList()
        {
            return View();
        }

        // GET: SMS/Details/5
        public ActionResult DetailsTeacherAllocationList()
        {
            var cr = new List<vw_ClassRoomTeacherView>();
            cr = en.vw_ClassRoomTeacherView.ToList();
            return View(cr);
        }

        public ActionResult EditTeacherAllocation(int id)
        {
            
            var teachername = from name in en.Teachers select name;
            SelectList list5 = new SelectList(teachername, "TeacherID", "TeacherFirstName");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.teachername = list5;
            return View(en.vw_ClassRoomTeacherView.Where(i => i.ClassRoomID == id).FirstOrDefault());
        }

        // POST: SMS/Edit/5
        [HttpPost]
        public ActionResult EditTeacherAllocation(int id, FormCollection collection)
        {

            try
            {
                ClassRoom cr = en.ClassRooms.Where(i => i.ClassRoomID == id).FirstOrDefault();
                cr.ClassRoomTeacherID =Convert.ToInt32( collection["TeacherFirstName"]);
                cr.ClassRoomModifiedDescription = collection["ClassRoomModifiedDescription"];
                int j = en.SaveChanges();
                return RedirectToAction("DetailsTeacherAllocationList");
            }
            catch
            {
                return View();
            }
        }
    }
}
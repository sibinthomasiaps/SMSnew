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
    public class StudentController : Controller
    {
        // GET: Student
        SMSnewEntities en = new SMSnewEntities();
        public ActionResult IndexStudent()
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            string regid = Convert.ToString(Session["UserName"]);
            //string userid = Convert.ToString(userid1);
            var photo = (from us in en.Students where us.StudRegId == regid select us.StudPhoto).Single();
            ViewBag.imgprofile = photo;
            return View();
        }
        public ActionResult studentsreg()
        {
            var classname = (en.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list3 = new SelectList(classname, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.classname = list3;
            return View();
        }
        public JsonResult GetDivisionList(string StudClass)
        {

            en.Configuration.ProxyCreationEnabled = false;
            //List<Subject> SubjectList = null;
            List<ClassRoom> DivisionList = en.ClassRooms.Where(x => x.Class == StudClass).ToList();
            return Json(DivisionList, JsonRequestBehavior.AllowGet);


        }
        public ActionResult StudentInsert(string fname, string lname, string gender, string bloodgroup, string dob, string joindate, string contactno, string email, string address1, string address2, string city, string state, string postcode, string country,string studclass,string studivision )
        {
            Student te = new Student();
            var maxrollno = en.Students.Where(r => r.StudClass ==studclass && r.StudDivision==studivision).Max(r=>r.StudRollNumber);
           
            if(maxrollno=="")
            {
                te.StudRollNumber = "1";
            }
            else
            {
                int rno = Convert.ToInt32(maxrollno);
                int rollno = rno + 1;
                te.StudRollNumber = Convert.ToString(rollno);
            }
         
            te.StudFirstName = fname;
            te.StudLastName = lname;
            te.StudGender = gender;
            te.StudBloodGroup = bloodgroup;
            te.StudDOB = Convert.ToDateTime(dob);
            te.StudJoinDate = Convert.ToDateTime(joindate);
            te.StudContactNumber = contactno;
            te.StudEmail = email;
            te.StudAddress1 = address1;
            te.StudAddress2 = address2;
            te.StudCity = city;
            te.StudState = state;
            te.StudCountry = country;
            te.StudPINcode = postcode;
            te.StudClass = studclass;
            te.StudDivision = studivision;
            te.StudModifiedBy = 1;
           // te.StudModifiedDate = DateTime.Now;
            te.StudModifiedDescription = "registered";


            var k = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);
            string regid = "S" + k;
            te.StudRegId = regid;
            
            te.StudActive = 1;
            string imagetype = null;
            if(gender=="Male")
            {
                imagetype="male-avatar.jpg";
            }
            else
            {
                imagetype = "female-avatar.jpg";
            }
            te.StudPhoto = imagetype;
            // te.TeacherLastLoginDate = DateTime.Now;
            en.Students.Add(te);
            int x = en.SaveChanges();

            //--------------auto generte password---------------///
            smsclass.passwordgen p = new smsclass.passwordgen();
            var tuple = p.password();
            string pas = tuple.Item1;
            string enpas = tuple.Item2;
            //-------------end autogenerate password--------------------//

            User us = new User();
            us.RegId = regid;
            us.UserType = "Student";
            us.Username = regid;
            us.Status = 0;
            us.Mailid = email;
            us.Password = enpas;
            en.Users.Add(us);
            int y = en.SaveChanges();
            return RedirectToAction("studentsreg");
        }
        public ActionResult DetailsStudentList()
        {

            var cr = new List<Student>();
            cr = en.Students.Where(i => i.StudActive == 1).ToList();
            return View(cr);    

        }
        public ActionResult EditStudentList(int id)
        {
            var classname = (en.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list3 = new SelectList(classname, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.classname = list3;
            //return View();
            return View(en.Students.Where(i => i.StudentID == id).FirstOrDefault());
        }
        public ActionResult EditStudentList1(int id)
        {
            var classname = (en.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list3 = new SelectList(classname, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.classname = list3;
            //return View();
            return View(en.Students.Where(i => i.StudentID == id).FirstOrDefault());
        }
        public ActionResult StudentEdit(string fname, string lname, string gender, string bloodgroup, string dob, string joindate, string contactno, string email, string address1, string address2, string city, string state, string postcode, string country, string studclass, string studivision,string modidescription, string id)
        {
            int studentid = Convert.ToInt32(id);

            Student te = en.Students.Where(j => j.StudentID == studentid).FirstOrDefault();
            te.StudFirstName = fname;
            te.StudLastName = lname;
            te.StudGender = gender;
            te.StudBloodGroup = bloodgroup;
            te.StudDOB = Convert.ToDateTime(dob);
            te.StudJoinDate = Convert.ToDateTime(joindate);
            te.StudContactNumber = contactno;
            te.StudEmail = email;
            te.StudAddress1 = address1;
            te.StudAddress2 = address2;
            te.StudCity = city;
            te.StudState = state;
            te.StudCountry = country;
            te.StudPINcode = postcode;
            te.StudClass = studclass;
            te.StudDivision = studivision;
            te.StudModifiedBy = 1;
            // te.StudModifiedDate = DateTime.Now;
            te.StudModifiedDescription = modidescription;
            //te.StudRollNumber = "ST1000";
            te.StudActive = 1;
            //te.Userid = 100;
            // te.TeacherLastLoginDate = DateTime.Now;
            // en.Teachers.Add(te);
            int i = en.SaveChanges();
            return RedirectToAction("DetailsStudentList");
        }


        public JsonResult DeleteAJAX(int studentid)
        {



            Student data = (from item in en.Students where item.StudentID == studentid select item).SingleOrDefault();
            data.StudActive = 0;
            //en.Students.Remove(data);
            en.SaveChanges();
            return Json("Record deleted successfully!");

        }
        public ActionResult DeleteStudent(int id)
        {
            Student cl = en.Students.Where(i => i.StudentID == id).FirstOrDefault();
            cl.StudActive = 0;
            //en.Students.Remove(cl);
            int j = en.SaveChanges();
            return RedirectToAction("DetailsStudentList");
            // return View(en.Subjects.Where(i => i.Subjectid == id).FirstOrDefault());
        }
    }
}
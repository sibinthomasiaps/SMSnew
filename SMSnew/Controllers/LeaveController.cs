using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;
using System.Net.Mail;
namespace SMSnew.Controllers
{
    public class LeaveController : Controller
    {
        SMSnewEntities ent = new SMSnewEntities();
        // GET: Leave
        public ActionResult CreateStudentLeave()
        {
            //ViewBag.LeavePersonId = 7;
            ViewBag.LeavePersonId = 1022;

            var leaveperson = (ent.Groups).GroupBy(p => p.GroupName).Select(grp => grp.FirstOrDefault());
            SelectList list = new SelectList(leaveperson, "GroupName", "GroupName");
            ViewBag.LeavePerson = list;




            return View();

        }
        [HttpPost]
        public ActionResult CreateStudentLeave(Leave lve, string Save, string Cancel)
        {
            try
            {
                if (!string.IsNullOrEmpty(Save))
                {
                    Leave lv = new Leave();
                    //lv.LeaveID = lve.LeaveID;
                    //lv.LeaveDate = lve.LeaveDate;
                    lv.LeaveCategory = lve.LeaveCategory;
                    lv.LeaveReason = lve.LeaveReason;
                    lv.LeavePerson = lve.LeavePerson;
                    lv.LeaveAppliedDate = DateTime.Now;
                    lv.LeaveStartDate = lve.LeaveStartDate;
                    lv.LeaveEndDate = lve.LeaveEndDate;

                    DateTime dt1 = Convert.ToDateTime(lve.LeaveEndDate);
                    DateTime dt2 = Convert.ToDateTime(lve.LeaveStartDate);



                    var days = dt1.Subtract(dt2).TotalDays;

                    lv.LeaveDays = Convert.ToInt16(days);
                    //lv.LeaveDays = lve.LeaveDays;

                    lv.LeaveStatus = "pending";

                    lv.LeavePersonRegId = lve.LeavePersonRegId;


                    //lv.LeaveApprovalPersonId=0;//initially set leave approval person id as 0
                    ent.Leaves.Add(lv);
                    int i = ent.SaveChanges();
                    if (i > 0)
                    {

                        return RedirectToAction("sendmailbystudent");
                    }

                }

                else if (!string.IsNullOrEmpty(Cancel))
                {


                    return RedirectToAction("CreateStudentLeave");//this code is not needed because already a redirection is given in cancel button click
                }


            }

            catch
            {


                return View();
            }
            return RedirectToAction("CreateStudentLeave");
        }

        public ActionResult ListStudentLeave()
        {

            //below 3 lines list all leave application
            //var cr = new List<Leave>();
            //cr = ent.Leaves.ToList();
            //return View(cr);

            //int Id = 7;

            string Id = "1022";

            //List<Leave> studleaveList = ent.Leaves.Where(x => x.LeaveID == Id).ToList();

            List<Leave> studleaveList = ent.Leaves.Where(x => x.LeavePersonRegId == Id).ToList();
            return View(studleaveList);

        }

        public ActionResult EditStudentLeave(int id)
        {
            var leaveperson = (ent.Groups).GroupBy(p => p.GroupName).Select(grp => grp.FirstOrDefault());
            SelectList list = new SelectList(leaveperson, "GroupName", "GroupName");
            ViewBag.lveperson = list;

            return View(ent.Leaves.Where(i => i.LeaveID == id).FirstOrDefault());
            //return View(ent.Leaves.Where(i => i.LeavePersonId == id).FirstOrDefault());


        }
        [HttpPost]
        public ActionResult EditStudentLeave(int id, Leave lve, string Save, string Cancel)
        {

            try
            {
                if (!string.IsNullOrEmpty(Save))
                {
                    Leave lv = ent.Leaves.Where(i => i.LeaveID == id).FirstOrDefault();
                    lv.LeaveCategory = lve.LeaveCategory;
                    lv.LeaveReason = lve.LeaveReason;
                    lv.LeaveAppliedDate = DateTime.Now;
                    lv.LeaveStartDate = lve.LeaveStartDate;
                    lv.LeaveEndDate = lve.LeaveEndDate;
                    //lv.LeaveDays = lve.LeaveDays;
                    DateTime dt1 = Convert.ToDateTime(lve.LeaveEndDate);
                    DateTime dt2 = Convert.ToDateTime(lve.LeaveStartDate);
                    lv.LeavePerson = lve.LeavePerson;
                    lv.LeavePersonRegId = lve.LeavePersonRegId;

                    var days = dt1.Subtract(dt2).TotalDays;

                    lv.LeaveDays = Convert.ToInt16(days);
                    lv.LeaveStatus = lve.LeaveStatus;

                    int j = ent.SaveChanges();
                    if (j > 0)
                    {

                        //return RedirectToAction("ListStudentLeave");
                        return RedirectToAction("sendmailbystudent");//redirect to send mail on success

                    }
                }
                else
                {
                    return View();

                }

                return View();

            }

            catch
            {
                return View();
            }

        }

        public ActionResult DeleteStudentLeave(int id)
        {



            try
            {


                Leave lv = ent.Leaves.Where(i => i.LeaveID == id).FirstOrDefault();
                ent.Leaves.Remove(lv);
                int j = ent.SaveChanges();
                if (j > 0)
                {

                    return RedirectToAction("ListStudentLeave");
                }
                return View();
            }

            catch
            {

                return View();
            }




        }
        public ActionResult ListAllLeaves()
        {
            ////var cr = new List<Leave>();
            ////cr = ent.Leaves.ToList();
            //return View(cr);
            ViewBag.LeaveApprovalId = 8;

            List<Leave> studleaveList = ent.Leaves.Where(x => x.LeavePerson == "student").ToList();//this is to display list of all students applied for leave
            return View(studleaveList);




        }
        public ActionResult EditLeaveByTeacher(int id)
        {
            ViewBag.LeaveApprovalPersonId = 8;


            return View(ent.Leaves.Where(i => i.LeaveID == id).FirstOrDefault());

        }
        [HttpPost]
        public ActionResult EditLeaveByTeacher(int id, Leave lve, String Save, String Cancel)
        {

            try
            {
                if (!string.IsNullOrEmpty(Save))
                {


                    Leave lv = ent.Leaves.Where(i => i.LeaveID == id).FirstOrDefault();
                    lv.LeaveCategory = lve.LeaveCategory;
                    lv.LeaveReason = lve.LeaveReason;
                    lv.LeaveAppliedDate = DateTime.Now;
                    lv.LeaveStartDate = lve.LeaveStartDate;
                    lv.LeaveEndDate = lve.LeaveEndDate;
                    //lv.LeaveDays = lve.LeaveDays;
                    DateTime dt1 = Convert.ToDateTime(lve.LeaveEndDate);
                    DateTime dt2 = Convert.ToDateTime(lve.LeaveStartDate);



                    var days = dt1.Subtract(dt2).TotalDays;

                    lv.LeaveDays = Convert.ToInt16(days);
                    lv.LeaveStatus = lve.LeaveStatus;
                    lv.LeavePersonRegId = lve.LeavePersonRegId;

                    int j = ent.SaveChanges();
                    if (j > 0)
                    {

                        //return RedirectToAction("ListAllLeaves");
                        return RedirectToAction("sendmailbyteacher");

                    }
                }
                else
                {
                    //return View();
                    return RedirectToAction("ListAllLeaves");

                }

                //return View();
                return RedirectToAction("ListAllLeaves");

            }

            catch
            {
                return View();
            }
        }


        public ActionResult DeleteLeaveByTeacher(int id)
        {

            try
            {
                Leave lve = ent.Leaves.Where(i => i.LeaveID == id).FirstOrDefault();
                ent.Leaves.Remove(lve);
                int j = ent.SaveChanges();
                if (j > 0)
                {


                    return RedirectToAction("ListAllLeaves");

                }
                return View();
            }
            catch
            {

                return View();
            }


        }

        public ActionResult sendmailbyteacher()
        {
            //ViewBag.teachermail=(from s in ent.Teachers where s.TcrRegId== ViewBag.LeaveApprovalPersonId).SingleOrDefault();
            var studemail = (from s in ent.Students where s.StudentID == 1022 select s.StudEmail).SingleOrDefault();
            ViewBag.studentmail = studemail;
            var paremail = (from s in ent.Parents where s.ParentStudID == 1022 select s.ParentEmail).SingleOrDefault();
            ViewBag.parentmail = paremail;

            ViewBag.Subject = "Leave status";
            //ViewBag.teachermail= "abcdteacher@gmail.com";
            ViewBag.From = (from s in ent.Teachers where s.TeacherID == 1032 select s.TeacherEmail).SingleOrDefault();
            return View();

        }

        [HttpPost]
        public ActionResult sendmailbyteacher(SMSnew.Models.MailModel _objModelMail, string studentmail, string parentmail, string teachermail)
        {

            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                string tomail = studentmail;
                string ccmail = parentmail;
                string frommail = teachermail;
                mail.To.Add(tomail);
                mail.CC.Add(ccmail);
                // mail.CC.Add(_objModelMail.To);

                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("akhiliaps@gmail.com", "intercard"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                //var stmail = ent.Students.ToList();
                //SelectList list = new SelectList(stmail, "StudEmail", "StudEmail");//datas in get atre pasted to avoid viewbag null error
                //ViewBag.studentmail = list;
                //var parentmail1 = ent.Parents.ToList();
                //SelectList list1 = new SelectList(parentmail1, "ParentEmail", "ParentEmail");
                //ViewBag.parentmail = list1;
                smtp.Send(mail);
                // return View("Index", _objModelMail);
                //return View("sendmailbyteacher", _objModelMail);this portion is commented and view result is changed to action result
                return RedirectToAction("ListAllLeaves");

            }
            else
            {
                return View();
            }
        }

        public ActionResult sendmailbystudent()
        {
            var From = (from s in ent.Students where s.StudentID == 1022 select s.StudEmail).SingleOrDefault();// from is studentmailid
            ViewBag.From = From;
            var StudClass = (from s in ent.Students where s.StudentID == 1022 select s.StudClass).SingleOrDefault();
            var StudDivision = (from s in ent.Students where s.StudentID == 1022 select s.StudDivision).SingleOrDefault();

            //var teacmail=()
            var teachmail = (from s in ent.vw_classTeacherEmail where s.ClassRoomDivision == StudDivision && s.Class == StudClass select s.TeacherEmail).SingleOrDefault();

            ViewBag.teachermail = teachmail;//teachermail is given to the viewbag.now need to call viewbag in the view


            ViewBag.Subject = "Leave Application";


            // var teachemail=(from s in ent.ClassRooms where s.ClassRoomTeacherID==11 select s.)
            return View();

        }
        [HttpPost]
        public ActionResult sendmailbystudent(SMSnew.Models.MailModel _objModelMail, string studentmail, string teachermail)
        {

            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();//this is a class in system.net.mail used for sending mail
                string tomail = teachermail;

                // string ccmail = parentmail;
                mail.From = new MailAddress(_objModelMail.From);
                mail.To.Add(tomail);
                // mail.CC.Add(ccmail);
                // mail.CC.Add(_objModelMail.To);


                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("akhiliaps@gmail.com", "intercard"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                //var stmail = ent.Students.ToList();
                //SelectList list = new SelectList(stmail, "StudEmail", "StudEmail");//datas in get atre pasted to avoid viewbag null error
                //ViewBag.studentmail = list;
                //var parentmail1 = ent.Parents.ToList();
                //SelectList list1 = new SelectList(parentmail1, "ParentEmail", "ParentEmail");
                //ViewBag.parentmail = list1;
                smtp.Send(mail);
                // return View("Index", _objModelMail);
                //return View("Index2", _objModelMail);
                ////return View("sendmailbystudent", _objModelMail);
                //ViewBag.Message = "susccesfully sent";
                return RedirectToAction("ListStudentLeave");
            }
            else
            {
                return View();
            }

        }

    }
}

        









       
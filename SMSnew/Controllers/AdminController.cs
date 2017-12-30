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
    public class AdminController : Controller
    {

        SMSnewEntities db = new SMSnewEntities();
        // GET: Admin
       
       
        //--------------------------------Institution Details--------------------------//
        [HttpGet]
        public ActionResult institutionprofile()
        {

            return View();
        }


        [HttpPost]
        public ActionResult institutionprofile(School sch, string submit, string cancel,HttpPostedFileBase file)
        {
            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", ".jpeg"
        };

            if (!string.IsNullOrEmpty(submit))
            {

                School sh = new School();
                sh.SchoolName = sch.SchoolName;
                sh.SchoolLanguage = sch.SchoolLanguage;
                sh.SchoolGST = sch.SchoolGST;
                sh.SchoolContactPerson = sch.SchoolContactPerson;
                sh.SchoolEmail = sch.SchoolEmail;
                sh.SchoolFax = sch.SchoolFax;
                sh.SchoolDetails = sch.SchoolDetails;
                sh.SchoolCopyright= sch.SchoolCopyright;
                sh.SchoolCity = sch.SchoolCity;
                sh.SchoolAddress2 = sch.SchoolAddress2;
                sh.SchoolAddress1 = sch.SchoolAddress1;
                sh.SchoolCode = sch.SchoolCode;
                sh.SchoolMobile = sch.SchoolMobile;
                sh.SchoolPhone = sch.SchoolPhone;
                sh.SchoolPINcode = sch.SchoolPINcode;
                sh.SchoolState = sch.SchoolState;
                sh.SchoolState = sch.SchoolState;
                sh.SchoolCountry = sch.SchoolCountry;
                sh.SchoolCurrencyType = sch.SchoolCurrencyType;
                sh.SchoolTimeZone = sch.SchoolTimeZone;



                if (file != null)
                {
                    //sh.SchoolLogo = file.ToString(); //getting complete url  

                    //var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
                    //var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
                    //if (allowedExtensions.Contains(ext)) //check what type of extension  
                    //{
                    //    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    //    string myfile = name + "_" + sh.SchoolName + ext; //appending the name with id  
                    //                                                      // store the file inside ~/project folder(Img)  
                    //    var path = Path.Combine(Server.MapPath("~/Img"), myfile);

                    //    //var path =Server.MapPath("~/Img"), myfile);
                    //    file.SaveAs(path + name + ext);
                    //    sh.SchoolLogo = fileName;




                    //}




                    string filePat = Server.MapPath("~/Img/" + sh.SchoolLogo);

                    //System.IO.File.Delete(filePat);

                    var k = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

                    var fileName = k + Path.GetFileName(file.FileName);
                    sh.SchoolLogo = fileName.ToString();
                    var path = Path.Combine(Server.MapPath("~/Img"), sh.SchoolLogo);

                    file.SaveAs(path);

                }

                    


                    db.Schools.Add(sh);
                db.SaveChanges();
                
            }

            else
            {
                return RedirectToAction("institutionprofile", "Admin");
            }

            return View();


        }
        [HttpGet]
        public ActionResult institutionprofileedit(int id = 1005)
        {
            return View(db.Schools.Where(i => i.Schoolid == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult institutionprofileedit(School sch, string submit ,string cancel, HttpPostedFileBase file, int id = 1005)
        {
            var allowedExtensions = new[] {
                 ".Jpg", ".png", ".jpg", ".jpeg"
                    };

           




                if (!string.IsNullOrEmpty(submit))
            {


                School sh = db.Schools.Where(i => i.Schoolid == id).FirstOrDefault();

                sh.SchoolName = sch.SchoolName;
                sh.SchoolLanguage = sch.SchoolLanguage;
                sh.SchoolGST = sch.SchoolGST;
                sh.SchoolContactPerson = sch.SchoolContactPerson;
                sh.SchoolEmail = sch.SchoolEmail;
                sh.SchoolFax = sch.SchoolTimeZone;
                sh.SchoolDetails = sch.SchoolDetails;
                sh.SchoolCopyright = sch.SchoolCopyright;
                sh.SchoolCity = sch.SchoolCity;
                sh.SchoolAddress2 = sch.SchoolAddress2;
                sh.SchoolAddress1 = sch.SchoolAddress1;
                sh.SchoolCode = sch.SchoolCode;
                sh.SchoolMobile = sch.SchoolMobile;
                sh.SchoolPhone = sch.SchoolPhone;
                sh.SchoolPINcode = sch.SchoolPINcode;
                sh.SchoolState = sch.SchoolState;
                sh.SchoolState = sch.SchoolState;
                sh.SchoolCountry = sch.SchoolCountry;
                sh.SchoolCurrencyType = sch.SchoolCurrencyType;
                sh.SchoolTimeZone = sch.SchoolTimeZone;
                if (file != null)
                {


                    string filePat = Server.MapPath("~/Img/" + sh.SchoolLogo);

                    System.IO.File.Delete(filePat);

                    var k = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

                    var fileName = k + Path.GetFileName(file.FileName);
                    sh.SchoolLogo = fileName.ToString();
                    var path = Path.Combine(Server.MapPath("~/Img"), sh.SchoolLogo);

                    file.SaveAs(path);


                

                    }
                


                db.SaveChanges();

                return RedirectToAction("institutionprofileedit");
        }
            else

            {
                return RedirectToAction("institutionprofileedit");
    }
}






        //-------------------------------- end Institution Details--------------------------//





        //<--------------------------------Group Members insteration-------------------------->
        [HttpGet]
        public ActionResult GroupMembership()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GroupMembership(Group grp,string save,string cancel)
        {
            if (!string.IsNullOrEmpty(save))
            {

                Group gt = new Group();
                gt.GroupStatus = 1;
                gt.GroupCreatedDate = DateTime.Now;
                gt.GroupName = grp.GroupName;
                gt.GroupDescription = grp.GroupDescription;
                db.Groups.Add(gt);
                db.SaveChanges();
                return View();
            }
            else
            {
                return RedirectToAction("GroupMembership");
            }
        }
        //<-------------------------------- end Group Members insteration-------------------------->


            //-------------------------- start group edit and delete--------------------------//


        [HttpGet]
        public ActionResult groupMembershipedt()
        {
            SMSnewEntities db = new SMSnewEntities();
            var entities = new SMSnewEntities();

            return View(entities.Groups.ToList());



           
        }
        [HttpGet]
        public ActionResult groupedt(int id)
        {
            return View(db.Groups.Where(i => i.Groupid == id).FirstOrDefault());

        }
        [HttpPost]

        public ActionResult groupedt(int id,Group gp,string cancel,string save)
        {
            if (!string.IsNullOrEmpty(save))
            {
                Group gps = db.Groups.Where(i => i.Groupid == id).FirstOrDefault();

                gps.GroupName = gp.GroupName;
                gps.GroupDescription = gp.GroupDescription;
                //db.Groups.Add(gps);
                db.SaveChanges();

                return RedirectToAction("groupMembershipedt");
            }
            else
            {
                return RedirectToAction("groupMembershipedt");
            }
        }

    
        [HttpGet]
        public ActionResult groupdlt(int id)
        {
            return View(db.Groups.Where(i => i.Groupid == id).FirstOrDefault());


        }

        [HttpPost]


        public ActionResult groupdlt(int id, Group gp,string save, string cancel)
        {
            if (!string.IsNullOrEmpty(save))
            {

                Group gps = db.Groups.Where(i => i.Groupid == id).FirstOrDefault();


                db.Groups.Remove(gps);
                db.SaveChanges();
                return RedirectToAction("groupMembershipedt");
            }
            else
            {
                return RedirectToAction("groupMembershipedt");
            }
        }

        //--------------------------  End group edit and delete--------------------------//

        //---------------------------- start academaic year------------------------------//



        [HttpGet]


        public ActionResult academaicyr()
        {

            SMSnewEntities db = new SMSnewEntities();
            var entities = new SMSnewEntities();

            return View(entities.AcademicYears.ToList());

            //return View();
        }

        [HttpPost]
        public ActionResult academaicyr(AcademicYear ayr,string submit,string delete ,string year,string year2)
        {
            if (!string.IsNullOrEmpty(submit))
            {
                AcademicYear ad = new AcademicYear();
                ad.AcademicEndMonth = ayr.AcademicEndMonth;
                ad.AcademicEndYear =year ;
                ad.AcademicStartMonth = ayr.AcademicStartMonth;
                ad.AcademicStartYear =year2 ;
                db.AcademicYears.Add(ad);
                db.SaveChanges();
                return RedirectToAction("academaicyr");
            }
            else
            {
                return RedirectToAction("academaicyr");
            }
        }


        [HttpGet]
        public ActionResult acdyredt(int id)
        {
            return View(db.AcademicYears.Where(i => i.AcademicYearId == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult acdyredt(int id, AcademicYear ac ,string update,string delete)
        {


            if (!string.IsNullOrEmpty(update))
            {

                AcademicYear gps = db.AcademicYears.Where(i => i.AcademicYearId == id).FirstOrDefault();

                gps.AcademicStartYear = ac.AcademicStartYear;
                gps.AcademicStartMonth = ac.AcademicStartMonth;
                gps.AcademicEndYear = ac.AcademicEndYear;
                gps.AcademicEndMonth = ac.AcademicEndMonth;

                //db.Groups.Add(gps);
                db.SaveChanges();
                return RedirectToAction("academaicyr");
            }

            else
            {
                AcademicYear gps = db.AcademicYears.Where(i => i.AcademicYearId == id).FirstOrDefault();


                db.AcademicYears.Remove(gps);
                db.SaveChanges();
                return RedirectToAction("academaicyr");
            }




        }

                
        //------------------------list----------------//

     


        //----------------------------   end academaic year------------------------------//


        public ActionResult Setting()
        {
            return View();
        }

        // --------------------user type selection-------------------------------//


          
        [HttpGet]
        public ActionResult usertype(Group gd)
        {
            var getgroup = (db.Groups).GroupBy(p => p.GroupName).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list = new SelectList(getgroup, "Groupid", "GroupName");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.getgroup = list;



            
            //SMSnewEntities entities = new SMSnewEntities();
            //List<Group> userprofile = (from Group in entities.Groups//.Take(15)
            //                           select Group).ToList();
            //var data = (from Group in entities.Groups//.Take(15)
            //            select Group).ToList();
            //Group model = new Group();
            //model.PageSize = 10;


            //List<Group> Groups = userprofile;

            //if (Groups != null)
            //{
            //    // model.TotalCount = Parent.Count();
            //    model.Groups = Groups;
            //}
            //ViewBag.userdetails = data;

            // return View(model);
            return View();
        }
       




        //---------------------userprofile interation----------------------------------------
        [HttpGet]
        public ActionResult userprofile(User ud,string str)
        {
            var getgroup = (db.Groups).GroupBy(p => p.GroupName).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list = new SelectList(getgroup, "GroupName", "GroupName");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.getgroup = list;



            //SMSnewEntities entities = new SMSnewEntities();
            //List<Group> userprofile = (from Group in entities.Groups//.Take(15)
            //                           select Group).ToList();
            //var data = (from Group in entities.Groups//.Take(15)
            //            select Group).ToList();
            //Group model = new Group();
            //model.PageSize = 10;


            //List<Group> Groups = userprofile;

            //if (Groups != null)
            //{
            //    // model.TotalCount = Parent.Count();
            //    model.Groups = Groups;
            //}
            //ViewBag.userdetails = data;

            
            



            //var getgroup1 = db.Groups.ToList();
            //SelectList list = new SelectList(getgroup1, "Groupid", "GroupName");
            //ViewBag.getgroup1 = list;
            //var Viewgroup1 = db.Groups.Find(ud.UserType);
            //ViewData["getgroup1"] = list;

            //return View(model);
            return View();

        }

       
        [HttpPost]
        public ActionResult userprofile(User us, string save, string cancel, string getgroup)
        {
          
            if (!string.IsNullOrEmpty(save))
            {

                using (SMSnewEntities db = new SMSnewEntities())
                {
                    //if (db.Users.Any(o => o.Username == us.Username)) return;

                    bool userExists = db.Users.FirstOrDefault(x => x.Username == us.Username) != null;

                    // and then use the bool to see if you need to return an error
                    if (userExists)
                    {
                        // I'm not 100% sure about this part so double-check this
                        // but I think it's pretty close to this
                        // TempData["alertMessage"] = "userName already Taken";
                        // ModelState.AddModelError("UserName", "UserName taken");
                        ViewBag.result = "userName already Taken";
                        return View();
                    }


                    User uts = new User();
                    uts.Status = 1;
                    uts.Username = us.Username;
                                        
                    uts.UserType = getgroup;

                    
                    uts.Mailid = us.Mailid;


                    //--------------auto generte password---------------///


                    string allowedChars = "";
                    allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";

                    allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
                    allowedChars += "1,2,3,4,5,6,7,8,9,0";
                    char[] sep = { ',' };
                    string[] arr = allowedChars.Split(sep);
                    string passwordString = "";
                    string temp = "";
                    Random rand = new Random();
                    for (int i = 0; i < 8; i++)
                    {
                        temp = arr[rand.Next(0, arr.Length)];
                        passwordString += temp;
                    }

                    byte[] encode = new byte[passwordString.Length];
                    encode = Encoding.UTF8.GetBytes(passwordString);
                    uts.Password = Convert.ToBase64String(encode);
                    //uts.Password = passwordString;



                    //-------------end autogenerate password--------------------//                                  

                    db.Users.Add(uts);
                    db.SaveChanges();


                    //----------------------Mail sernding------------------------//

                    // MailMessage mm = new MailMessage("nivyavinu9496@gmail.com", us.Mailid);
                    // mm.Subject = "Password ";
                    // mm.Body = string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", passwordString, us.Username);
                    // mm.IsBodyHtml = true;
                    // SmtpClient smtp = new SmtpClient();
                    // smtp.Host = "smtp.gmail.com";
                    // smtp.EnableSsl = true;
                    // NetworkCredential NetworkCred = new NetworkCredential();
                    // NetworkCred.UserName = "nivyavinu9496@gmail.com";
                    // NetworkCred.Password = "password";
                    // smtp.UseDefaultCredentials = true;
                    // smtp.Credentials = NetworkCred;
                    // smtp.Port = 587;
                    // smtp.Send(mm);







                    //ViewBag.result = "Password has been sent to your email address.";


                    //----------------------------end----------------------------------//

                    SMSnewEntities entities = new SMSnewEntities();
                    List<Group> userprofile = (from Group in entities.Groups//.Take(15)
                                                     select Group).ToList();
                    var data = (from Group in entities.Groups//.Take(15)
                                select Group).ToList();
                    Group model = new Group();
                   // model.PageSize = 10;

                    List<Group> Groups = userprofile;

                    if (Groups != null)
                    {
                        // model.TotalCount = Parent.Count();
                        //model.Group = Groups;
                    }
                    ViewBag.userdetails = data;
                                                                        
                                     
                        if (getgroup == "Mange")

                    {
                       

                        TempData["ID"] = us.Username;
                        // redirect to your application home page or other page
                        return RedirectToAction("employeereg", "Employee");
                    }
                    else if (getgroup == "Student")
                    {
                        return RedirectToAction("studentsreg", "Student");
                    }

                    else if (getgroup == "Teacher")

                    {
                        return RedirectToAction("studentsreg", "Student");
                    }
                    else if (getgroup == "Parent")
                    {
                        TempData["ID"] = us.Username;
                        return RedirectToAction("parentreg", "Parent");
                    }
                    else
                    {
                        return RedirectToAction("employeereg", "Employee");
                    }


                }

            }

            else
            {
                ViewBag.Message = "The operation was cancelled!";

            }
            return View();
        }

        //<----------------------------------------end of user profile insteration------------------------------------->


        //<--------------------------  Start  List of user profile--------------------------------------------------->
        [HttpGet]
            public ActionResult userlist()
      {
            SMSnewEntities db = new SMSnewEntities();
            List<User> userprofile = (from user in db.Users//.Take(15)
                                      where user.Status == 1
                                      select user).ToList();

            //var entities = new SMSnewEntities();

            return View(userprofile);

        }

        public ActionResult useredt2(string fname,string City)
        {
            int ids = int.Parse(fname);
            var getgroup = (db.Groups).GroupBy(p => p.GroupName).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list = new SelectList(getgroup, "GroupName", "GroupName");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.getgroup = list;
            return View(db.Users.Where(i => i.Userid == ids).FirstOrDefault());
        }
        [HttpGet]
      
        public ActionResult useredt(int? id)
        {
       
            var getgroup = (db.Groups).GroupBy(p => p.GroupName).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list = new SelectList(getgroup, "GroupName", "GroupName");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.getgroup = list;
            return View(db.Users.Where(i => i.Userid == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult useredt(int id, User us,string getgroup,string save,string cancel)
        {
            if (!string.IsNullOrEmpty(save))
            {
                User usd = db.Users.Where(i => i.Userid == id).FirstOrDefault();

                usd.Mailid = us.Mailid;
                usd.UserType = getgroup;


                //db.Groups.Add(gps);
                db.SaveChanges();
                return RedirectToAction("userlist");
            }

            else
            {
                return RedirectToAction("userlist", "Admin");
            }
        }

                       
              
        public ActionResult usdlt(int id, User usd)
        {
            
                User uf = db.Users.Where(i => i.Userid == id).FirstOrDefault();

                uf.Status = 0;


                db.SaveChanges();
                return RedirectToAction("userlist");
           

            

        }
                

        //<--------------------------End  List of user profile--------------------------------------------------->

            
            

        //----------------------------admin details-------------------------------------//
        [HttpGet]
        public ActionResult adminprofile0(string fname, string JoiningDate, string Address, string Address1, string City, string State, string PINcode, string Country, string ContactNumber, string TotalExperience , string ExperienceInfo, string Qualification,string Department,string Gender,string username, string Mailid)
        {
            User usr = new User();
            Admin amn = new Admin();
            amn.Address = Address;
            amn.Address1 = Address1;
            amn.JoiningDate =  Convert.ToDateTime(JoiningDate);;
            amn.Qualification = Qualification;
            amn.State = amn.State;
            int parse = int.Parse(TotalExperience);
            amn.TotalExperience = parse;
            amn.Country = Country;
            amn.ExperienceInfo = ExperienceInfo;
            amn.Department = Department;
            amn.AdminFullname = fname;
            amn.City = City;
            amn.PINcode = PINcode;
            amn.Status = 1;
            amn.State = State;
            //int cnt = Convert.ToInt32(ContactNumber);
            amn.ContactNumber = Convert.ToInt32(ContactNumber);
            amn.Gender = Gender;
            string imagetype = null;
            if (amn.Gender=="Male")
            {
                imagetype = "male-avatar.jpg";
            }
            else
            {
                imagetype = "female-avatar.jpg";
            }
            amn.Photo = imagetype;
           
            var k = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);
          amn.AdminRegId = "A" + k;
           
            db.Admins.Add(amn);
            db.SaveChanges();
            SMSnew.Models.passwordgen p = new SMSnew.Models.passwordgen();
            var tuple = p.password();
            string pas = tuple.Item1;
            string enpas = tuple.Item2;
                        
            usr.Password = enpas;
            usr.Username = amn.AdminRegId;
            usr.UserType = "Admin";
            usr.Status = 1;
            usr.LastLoginDate = DateTime.Now;
            usr.RegId = amn.AdminRegId;
            usr.Mailid = Mailid;
            db.Users.Add(usr);
            db.SaveChanges();
            SMSnew.Models.Emailuserdetails sendmail = new SMSnew.Models.Emailuserdetails();
            string msg = sendmail.emailgen(amn.AdminRegId, pas, Mailid, fname);
            return RedirectToAction("adminprofile", "Admin");
        }

      

        [HttpGet]
        public ActionResult adminprofile()
        {
            
            return View();
            
        }



        // -----------------------------------end admin profile---------------------------//


        // -----------------------------------Edit admin profile---------------------------//

            public  ActionResult adminprofileedit(int id=2)
        {
      
            return View(db.Admins.Where(i => i.AdminId == id).FirstOrDefault());

        }

        public ActionResult adminprofileedit1(string fname ,string JoiningDate, string Address, string Address1, string City, string State, string PINcode, string Country, string ContactNumber, string TotalExperience, string ExperienceInfo, string Qualification, string Department, string Gender, int id = 2 )
        {

           Admin ad = db.Admins.Where(i => i.AdminId == id).FirstOrDefault();



            ad.Address = Address;
            ad.Address1 = Address1;
            ad.JoiningDate = Convert.ToDateTime(JoiningDate); ;
            ad.Qualification = Qualification;
            ad.State = State;
            int parse = int.Parse(TotalExperience);
            ad.TotalExperience = parse;
            ad.Country = Country;
            ad.ExperienceInfo = ExperienceInfo;
            ad.Department = Department;
            ad.AdminFullname = fname;
            ad.City = City;
             ad.State = State;
            int cnt = int.Parse(ContactNumber);
            ad.ContactNumber = cnt;
            ad.Gender = Gender;
           
            db.SaveChanges();

            return RedirectToAction("adminprofileedit", "Admin");
         

        }





        // ----------------------------------- Edit admin profile---------------------------//



        //--------------------Start-admission request------------------------//
        [HttpGet]
        public ActionResult admissionrequest()
        {
            var getclass = (db.ClassRooms).GroupBy(p => p.Class).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list = new SelectList(getclass, "Class", "Class");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.getclass = list;



            return View();
        }

        [HttpPost]
        public ActionResult admissionrequest(Admission ads,string save,string cancel,int year,string getclass)
        {
            if (!string.IsNullOrEmpty(save))
            {

                Admission ad = new Admission();
                ad.AcademicYear = year;
                ad.StudentName = ads.StudentName;
                ad.GuardianName = ads.GuardianName;
                ad.AttachedDoc = ads.AttachedDoc;
                ad.Class = getclass;
                ad.PreviousEduDetails = ads.PreviousEduDetails;
                ad.ContactNo = ads.ContactNo;
                db.Admissions.Add(ad);
                db.SaveChanges();
                              
               return RedirectToAction("admissionrequest");
            }
            else
            {
                return RedirectToAction("admissionrequest");

            }
        }

        [HttpGet]
        public ActionResult requestlist()
        {

            SMSnewEntities db = new SMSnewEntities();
            var entities = new SMSnewEntities();

            return View(entities.Admissions.ToList());



        }

        [HttpGet]

        public ActionResult requestedit(int id)
        {

            Admission gps = db.Admissions.Where(i => i.AdmissionId == id).FirstOrDefault();

            gps.Status = "Active";

            //db.Groups.Add(gps);
            db.SaveChanges();
            return RedirectToAction("requestlist");
        }

       
        public ActionResult requestdlt(int id)
        {
            Admission gps = db.Admissions.Where(i => i.AdmissionId == id).FirstOrDefault();


            db.Admissions.Remove(gps);
            db.SaveChanges();
            return RedirectToAction("requestlist");
        }





        //---------------------end admission request------------------------//

    }
}
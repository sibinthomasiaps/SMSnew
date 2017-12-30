using SMSnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SMSnew.Controllers
{
    public class loginController : Controller
    {
        SMSnewEntities db = new SMSnewEntities();
       
        // GET: login

        [HttpGet]
        public ActionResult login()
        {
            User model = new User(); /*{ Username = userd};*/
            if (Request.Cookies["Login"] != null)
            {
                model.Username = Request.Cookies["Login"].Values["EmailID"];
                model.Password = Request.Cookies["Login"].Values["Password"];
            }
            return View(model);
        }
        
        
        [HttpPost]
        public ActionResult login(User ud, string submit, string Reset,string chk)
        {
            if (!string.IsNullOrEmpty(submit))
            {
                User uts = new User();

                string passwordString = ud.Password;
                byte[] encode = new byte[passwordString.Length];
                encode = System.Text.Encoding.UTF8.GetBytes(passwordString);
                uts.Password = Convert.ToBase64String(encode);
                string passwords = uts.Password;
                if (ModelState.IsValid)
                {
                    using (SMSnewEntities db = new SMSnewEntities())
                    {
                        var obj = db.Users.Where(a => a.Username.Equals(ud.Username)&& a.Password.Equals(uts.Password)).FirstOrDefault();
                        FormsAuthentication.SetAuthCookie(ud.Username, true);
                        if (obj != null)
                        {

                            var user = (from us in db.Users
                                     where us.Username == ud.Username
                                      select us.Userid).Single();
                            var grouptype = (from us in db.Users
                                             where us.Username == ud.Username
                                             select us.UserType).Single();

                            Session["UserID"] = user;
                            Session["UserName"] = ud.Username.ToString();
                            Session["usertype"] = grouptype;
                            if (grouptype == "Admin")
                            {
                                return RedirectToAction("changepassword", "login");
                            }
                            else
                            {
                                return RedirectToAction("mvmnt_book", "Library");
                            }
                            
                        }
                    }
                }
            }
            return View();
        }

        [HttpGet]

        public ActionResult forgetpassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult forgetpassword(User ud)
        {
            if (ModelState.IsValid)
            {
                using ( SMSnewEntities db = new  SMSnewEntities())
                {
                    User ut = new User();

                    //var obj = db.Users.Where(a => a.Mailid == ud.Mailid);
                    User obj = db.Users.Where(i => i.Mailid == ud.Mailid).FirstOrDefault();
                    if (obj != null)
                    {
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
                        ut.Password = Convert.ToBase64String(encode);

                        User pass = db.Users.Where(i => i.Mailid == ud.Mailid).FirstOrDefault();
                        pass.Password = ut.Password;
                        
                        db.Users.Add(ut);
                        db.SaveChanges();
                        
                        Session["UserID"] = ud.Userid.ToString();
                        //Session["UserName"] = ud.Username.ToString();
                         return RedirectToAction("login", "login");
                    }
                    else
                    {
                        ViewBag.Message = "The operation was cancelled!";
                    }
                }
            }
            return View();
        }

        
        public ActionResult logout()
        {

            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Expires = -1500;
            Response.CacheControl = "no-cache";
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            FormsAuthentication.SignOut();

            this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.Response.Cache.SetNoStore();
            Response.ExpiresAbsolute = DateTime.Now;
            Response.Expires = 0;
            Response.CacheControl = "no-cache";            
                return RedirectToAction("login", "login");            
        }
        [HttpGet]
        public ActionResult changepassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult changepassword(FormCollection collection,string submit,string cancel)
        {
            if (!string.IsNullOrEmpty(submit))
            {
                string userid = Session["UserID"].ToString();
                int id = Convert.ToInt32(userid);
                
                User usd = new User();
                string password = collection["Password"];
                byte[] encode = new byte[password.Length];
                encode = System.Text.Encoding.UTF8.GetBytes(password);
                string enpas = Convert.ToBase64String(encode);
               
                if (ModelState.IsValid)
                {
                    using (SMSnewEntities db = new SMSnewEntities())
                    {
                        var obj = db.Users.Where(a => a.Userid.Equals(id) && a.Password.Equals(enpas)).FirstOrDefault();
                        FormsAuthentication.SetAuthCookie(enpas, true);
                        if (obj != null)
                        {
                            User ad = db.Users.Where(i => i.Userid == id).FirstOrDefault();

                            string newpassword = collection["newpassword"];
                            byte[] encodes = new byte[newpassword.Length];
                            encodes = System.Text.Encoding.UTF8.GetBytes(password);
                            string enpasw  = Convert.ToBase64String(encodes);
                            ad.Password = enpasw;
                            db.SaveChanges();
                        }
                    }
                }
            }
            return View();
        }
    }
}
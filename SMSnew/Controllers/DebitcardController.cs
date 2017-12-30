using SMSnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSnew.Controllers
{
    public class DebitcardController : Controller
    {
        SMSnewEntities db = new SMSnewEntities();

        // GET: Debit
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDivisionList(string getclass)
        {

            //var division = (en.ClassRooms.Where(x => x.Class == SubAlClass).GroupBy(p => p.ClassRoomDivision).Select(grp => grp.FirstOrDefault()));
            //var div = en.ClassRooms.Where(x => x.Class == SubAlClass).Select(x => x.ClassRoomDivision).Distinct().ToList();
            //return Json(division, JsonRequestBehavior.AllowGet);
            //List<ClassRoom> DivisionList = div;
            db.Configuration.ProxyCreationEnabled = false;
            List<ClassRoom> DivisionList = null;
            DivisionList = db.ClassRooms.Where(x => x.Class == getclass).ToList();
            return Json(DivisionList, JsonRequestBehavior.AllowGet);


        }
        [HttpGet]
        public ActionResult debitcardreg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult debitcardreg(FormCollection collection)
        {

            DebitCard rech = new DebitCard();
            rech.DebitCard1 = collection["DebitCard1"];
            string cardno = collection["DebitCard1"];
            rech.Amount = 0;
            rech.TotalAmount = Convert.ToDouble(collection["TotalAmount"]);
            double tamnt = Convert.ToDouble(collection["TotalAmount"]);
            rech.SwipeDateTime = DateTime.Now;
            String username = collection["username"];
            var userid = db.Users.Where(i => i.Username == username).Select(i => i.RegId).FirstOrDefault();
            string uid = Convert.ToString(userid);
            rech.UserId = uid;
            rech.ModifiedBy = Convert.ToInt32(collection["ModifiedBy"]);
            // rech.UserType = collection["UserType"];
            rech.RechargeType = "Recharge";
            var previousdate = db.DebitCards.OrderByDescending(d => d.SwipeDateTime).Select(d => d.SwipeDateTime).FirstOrDefault();
            DateTime previous = Convert.ToDateTime(previousdate);
            var balanceamnt = (db.DebitCards.Where(i => i.SwipeDateTime == previous && i.DebitCard1 == cardno).Select(i => i.BalanceAmount).FirstOrDefault());
            double bamnt = Convert.ToDouble(balanceamnt);
            rech.BalanceAmount = bamnt + tamnt;

            var usertype = db.Users.Where(i => i.Username == username).Select(i => i.UserType).FirstOrDefault();
            rech.UserType = usertype;
            rech.PINnumber = collection["PINnumber"];
            db.DebitCards.Add(rech);
            db.SaveChanges();
            return View();

        }


        [HttpGet]
        public ActionResult debitcardinsert(string save)
        {

            return View();
        }
        [HttpPost]
        public ActionResult debitcardinsert(FormCollection collection, string save, string send)
        {
            if (!string.IsNullOrEmpty(save))
            {
                try
                {
                    DebitCard card = new DebitCard();
                    card.DebitCard1 = collection["DebitCard1"];
                    string cardno = collection["DebitCard1"];
                    card.SwipeDateTime = DateTime.Now;
                    TempData["date"] = card.SwipeDateTime;
                    card.Amount = Convert.ToDouble(collection["Amount"]);
                    double amnot = Convert.ToDouble(collection["Amount"]);
                    TempData["amnt"] = Convert.ToDouble(collection["Amount"]);
                    //    int now_amount = Convert.ToInt32(collection["Amount"]);
                    card.PINnumber = collection["PINnumber"];
                    var pinno = collection["PINnumber"];
                    var cardid = collection["DebitCard1"];
                    card.ModifiedBy = 1;
                    card.RechargeType = "Deduction";
                    var previousdate = db.DebitCards.OrderByDescending(d => d.SwipeDateTime).Where(d => d.PINnumber == pinno && d.DebitCard1 == cardid).Select(d => d.SwipeDateTime).FirstOrDefault();
                    DateTime previous = Convert.ToDateTime(previousdate);
                    var tamount = db.DebitCards.Where(i => i.PINnumber == pinno && i.DebitCard1 == cardid && i.SwipeDateTime == previous).Select(i => i.BalanceAmount).FirstOrDefault();
                    double toatalamount = Convert.ToDouble(tamount);
                    card.TotalAmount = toatalamount;

                    card.BalanceAmount = toatalamount - amnot;
                    double balance = toatalamount - amnot;
                    if (amnot <= toatalamount || amnot <= balance)
                    {
                        TempData["total"] = card.TotalAmount;
                        var data11 = (from DebitCard in
                                          db.DebitCards
                                      where DebitCard.DebitCard1 == cardid && DebitCard.PINnumber == pinno
                                      select DebitCard).ToList();
                        foreach (var item in data11)
                        {

                            string usertype = item.UserType;
                            TempData["utype"] = usertype;
                            card.UserType = item.UserType;
                            card.UserId = item.UserId;
                            TempData["UserId"] = item.UserId;

                        }
                        string utype = Convert.ToString(TempData["utype"]);


                        db.DebitCards.Add(card);
                        db.SaveChanges();
                        string amnt1 = Convert.ToString(TempData["amnt"]);
                        double amnt = Convert.ToDouble(amnt1);
                        string total = Convert.ToString(TempData["total"]);
                        double totalamnt = Convert.ToDouble(total);
                        if (utype == "Student")
                        {

                            String studid = Convert.ToString(TempData["UserId"]);

                            var studentid1 = db.Students.Where(i => i.StudRegId == studid).Select(i => i.StudentID).FirstOrDefault();
                            int studentid = Convert.ToInt32(studentid1);
                            var ParentName = (db.Parents.Where(i => i.ParentStudID == studentid).Select(i => i.ParentName).FirstOrDefault());
                            string name = Convert.ToString(ParentName);
                            var mail1 = (db.Parents.Where(i => i.ParentStudID == studentid).Select(i => i.ParentEmail).FirstOrDefault());
                            string mail = Convert.ToString(mail1);
                            models.emailpurchase sendmail = new models.emailpurchase();
                            string msg = sendmail.emailgen(amnt, balance, name, mail);
                        }
                        if (utype == "Teacher")
                        {
                            String Tid = Convert.ToString(TempData["UserId"]);
                            var teachername = db.Teachers.Where(i => i.TcrRegId == Tid).Select(i => i.TeacherFirstName + i.TeacherLastName).FirstOrDefault();
                            string name = Convert.ToString(teachername);
                            var mail1 = (db.Teachers.Where(i => i.TcrRegId == Tid).Select(i => i.TeacherEmail).FirstOrDefault());
                            string mail = Convert.ToString(mail1);
                            models.emailpurchase sendmail = new models.emailpurchase();
                            string msg = sendmail.emailgen(amnt, balance, name, mail);
                        }
                        if (utype == "Employee")
                        {
                            String Eid = Convert.ToString(TempData["UserId"]);
                            var teachername = db.Employees.Where(i => i.EmpRegId == Eid).Select(i => i.EmpFirstName + i.EmpLastName).FirstOrDefault();
                            string name = Convert.ToString(teachername);
                            var mail1 = (db.Employees.Where(i => i.EmpRegId == Eid).Select(i => i.EmpEmail).FirstOrDefault());
                            string mail = Convert.ToString(mail1);
                            models.emailpurchase sendmail = new models.emailpurchase();
                            string msg = sendmail.emailgen(amnt, balance, name, mail);
                        }
                        //if(utype=="Admin")
                        // {
                        //String Aid = Convert.ToString(TempData["UserId"]);
                        //var teachername = db.Admins.Where(i => i.AdminRegId == Aid).Select(i => i.AdminFullname ).FirstOrDefault();
                        //string name = Convert.ToString(teachername);
                        //var mail1 = (db.Admins.Where(i => i.AdminRegId == Aid).Select(i => i.).FirstOrDefault());
                        //string mail = Convert.ToString(mail1);
                        // }
                        //string dt1 = Convert.ToString(TempData["date"]);
                        //DateTime dt = Convert.ToDateTime(dt1);
                        //models.emailpurchase sendmail = new models.emailpurchase();
                        //string msg = sendmail.emailgen(amnt, totalamnt, name, mail, dt);

                        return RedirectToAction("debitcardlist");

                    }

                    else
                    {
                        ViewBag.msg = "Amount is not available";
                        return View();
                    }





                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        public ActionResult debitcardlist()
        {
            ViewBag.debit = db.DebitCards.ToList();
            ViewBag.Encoded = new Func<string, string>(encodecode.Encode);
            return View();

        }
        public ActionResult debitcarddelete(int id)
        {
            DebitCard deb = db.DebitCards.Where(i => i.DebitCardId == id).FirstOrDefault();
            db.DebitCards.Remove(deb);
            int j = db.SaveChanges();
            return RedirectToAction("debitcardlist");
        }
    }
}
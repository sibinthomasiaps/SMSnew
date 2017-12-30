using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSnew.Models;

namespace SMSnew.Controllers
{
    public class LibraryController : Controller
    {
        SMSnewEntities db = new SMSnewEntities();
        // GET: Library
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult catg_reg()
        {
            List<LibraryBookCatagory> BookCatagory = db.LibraryBookCatagories
      .OrderByDescending(x => x.LibraryBookCatagoryId)
      .ToList<LibraryBookCatagory>();

            return View(BookCatagory);
        }
        [HttpPost]
        public ActionResult catg_reg(LibraryBookCatagory lbc, string save)
        {
            try
            {


                if (!string.IsNullOrEmpty(save))
                {
                    LibraryBookCatagory ctg = new LibraryBookCatagory();
                    ctg.LibraryBookCatagoryName = lbc.LibraryBookCatagoryName;
                    ctg.LibraryBookCatagoryDescription = lbc.LibraryBookCatagoryDescription;
                    db.LibraryBookCatagories.Add(ctg);
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        return RedirectToAction("catg_reg");
                    }
                }

            }
            catch
            {
                return RedirectToAction("catg_reg");
            }

            return View();


        }
        [HttpGet]
        public ActionResult catg_upd(int id)
        {

            List<LibraryBookCatagory> library = db.LibraryBookCatagories.Where(i => i.LibraryBookCatagoryId == id).OrderByDescending(x => x.LibraryBookCatagoryId).ToList<LibraryBookCatagory>();
            ViewBag.edit = library;

            List<LibraryBookCatagory> BookCatagory = db.LibraryBookCatagories
          .OrderByDescending(x => x.LibraryBookCatagoryId)
          .ToList<LibraryBookCatagory>();
            return View(BookCatagory);

        }
        [HttpPost]
        public ActionResult catg_upd(int id, string save, LibraryBookCatagory lct)
        {
            try
            {
                LibraryBookCatagory ctg = db.LibraryBookCatagories.Where(i => i.LibraryBookCatagoryId == id).FirstOrDefault();
                ctg.LibraryBookCatagoryName = lct.LibraryBookCatagoryName;
                ctg.LibraryBookCatagoryDescription = lct.LibraryBookCatagoryDescription;
                int q = db.SaveChanges();
                if (q > 0)
                {
                    return RedirectToAction("catg_reg");
                }
            }
            catch
            {

            }
            return RedirectToAction("catg_reg");

        }



        public ActionResult catg_del(int id)
        {
            try
            {
                LibraryBookCatagory ctg = db.LibraryBookCatagories.Where(i => i.LibraryBookCatagoryId == id).FirstOrDefault();
                db.LibraryBookCatagories.Remove(ctg);
                int j = db.SaveChanges();
                if (j > 0)
                {

                    return RedirectToAction("catg_reg");
                }
            }
            catch
            {
                return RedirectToAction("catg_reg");
            }
            return RedirectToAction("catg_reg");
        }


          [HttpGet]
           public ActionResult bk_reg()
             {
                 var ClassLastStudied = (db.LibraryBookCatagories).GroupBy(p => p.LibraryBookCatagoryName).Select(grp => grp.FirstOrDefault());
                 SelectList list = new SelectList(ClassLastStudied, "LibraryBookCatagoryid", "LibraryBookCatagoryName");
                 ViewBag.category = list;
                 return View();

     
            }
         [HttpPost]
          public ActionResult bk_reg(LibraryBookAvailability lba)
             {
                 try
                 {
                     LibraryBookAvailability lb = new LibraryBookAvailability();
                     lb.LibraryBookAuthor = lba.LibraryBookAuthor;
                     lb.LibraryBookCatagoryid = lba.LibraryBookCatagoryid;
                     lb.LibraryBookCost = lba.LibraryBookCost;
                     lb.LibraryBookNo = lba.LibraryBookNo;
                     lb.LibraryBookTitle = lba.LibraryBookTitle;
                     lb.LibraryBookPublisher = lba.LibraryBookPublisher;
                     lb.LibraryBookNoCopies = 0;
                     lb.LibraryBookAvailablity = 0;
                     db.LibraryBookAvailabilities.Add(lba);
                     int i = db.SaveChanges();
                     if (i > 0)
                     {
                         return RedirectToAction("bk_reg");

                     }
                 }
                 catch
                 {

                 }
            
                 return View();
             }

        public ActionResult bk_details()
         {

             var tc = new List<vw_BookCategoryAvailability>();
             tc = db.vw_BookCategoryAvailability.OrderByDescending(x=>x.LibraryBookReg).ToList();
             return View(tc);


         }

        [HttpGet]
        public ActionResult bk_updt(int id)
        {
            var ClassLastStudied = (db.LibraryBookCatagories).GroupBy(p => p.LibraryBookCatagoryName).Select(grp => grp.FirstOrDefault());
            SelectList list = new SelectList(ClassLastStudied, "LibraryBookCatagoryid", "LibraryBookCatagoryName");
            ViewBag.category = list;
           
            return View(db.LibraryBookAvailabilities.Where(i=>i.LibraryBookReg==id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult bk_updt(LibraryBookAvailability lib,int id)
        {
            LibraryBookAvailability lb = db.LibraryBookAvailabilities.Where(i=>i.LibraryBookReg==id).FirstOrDefault();
            lb.LibraryBookAuthor = lib.LibraryBookAuthor;
            lb.LibraryBookCatagoryid = lib.LibraryBookCatagoryid;
            lb.LibraryBookCost = lib.LibraryBookCost;
            lb.LibraryBookNo = lib.LibraryBookNo;
            lb.LibraryBookTitle = lib.LibraryBookTitle;
            lb.LibraryBookPublisher = lib.LibraryBookPublisher;
            int u=db.SaveChanges();
            if (u > 0)
            {
                return RedirectToAction("bk_details");
            }
            return View();
        }
        public ActionResult bk_dlt(int id)
        {
            LibraryBookAvailability lb = db.LibraryBookAvailabilities.Where(i => i.LibraryBookReg == id).FirstOrDefault();
            db.LibraryBookAvailabilities.Remove(lb);
            int k= db.SaveChanges();
            if (k > 0)
            {
                return RedirectToAction("bk_details");
            }
            return View();
        }



        [HttpGet]
        public ActionResult book_reg()
        {
            var Author = (db.LibraryBookAvailabilities).GroupBy(p => p.LibraryBookAuthor).Select(grp => grp.FirstOrDefault());
            SelectList list = new SelectList(Author, "LibraryBookAuthor", "LibraryBookAuthor");
            ViewBag.author = list;


            return View();
        }
        [HttpPost]
        public ActionResult book_reg(LibraryBook lb)
        {
            LibraryBook bk = new LibraryBook();
            bk.LibraryBookRegId = lb.LibraryBookRegId;
            int s = Convert.ToInt32(Session["UserID"]);

            int k = Convert.ToInt32(bk.LibraryBookRegId);
            bk.LibraryBookCondition = lb.LibraryBookCondition;
            bk.LibraryBookLanguage = lb.LibraryBookLanguage;
            bk.LibraryBookShelfNo = lb.LibraryBookShelfNo;
            bk.LibraryBookStatus = "Available";
            bk.Librarian = s;
            bk.LibraryISBN = lb.LibraryISBN;

            db.LibraryBooks.Add(bk);
           int i= db.SaveChanges();
           if (i > 0)
           {
              
             var number=  db.LibraryBookAvailabilities.Where(p => p.LibraryBookReg == k).Select(f=>f.LibraryBookNoCopies).FirstOrDefault();
             var avail = db.LibraryBookAvailabilities.Where(q => q.LibraryBookReg == k).Select(g => g.LibraryBookAvailablity).FirstOrDefault();
             int no = Convert.ToInt32(number) + 1;
             int availno = Convert.ToInt32(avail) + 1;
             db.LibraryBookAvailabilities.Single(x => x.LibraryBookReg == k).LibraryBookNoCopies = no;
             db.LibraryBookAvailabilities.Single(c => c.LibraryBookReg == k).LibraryBookAvailablity = availno;
                 int a = db.SaveChanges();

                 if (a > 0)
                 {

                     return RedirectToAction("book_reg");
                 }
                        return RedirectToAction("book_reg");
           }
            return View();
        }

        public JsonResult GetISBNDetail(string Isbn_no)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var names = db.LibraryBooks.Where(x => x.LibraryISBN == Isbn_no).Select(col => col.LibraryId).FirstOrDefault();
            return Json(names, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetTitleList(string author)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var names = db.LibraryBookAvailabilities.Where(x => x.LibraryBookAuthor == author).GroupBy(q => q.LibraryBookTitle).Select(group => group.FirstOrDefault());           
            return Json(names, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetpublisherList(string author, string booktitle)
        {


            db.Configuration.ProxyCreationEnabled = false;
            var names = db.LibraryBookAvailabilities.Where(x => x.LibraryBookAuthor == author&&x.LibraryBookTitle==booktitle).GroupBy(q => q.LibraryBookPublisher).Select(group => group.FirstOrDefault());
            return Json(names, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBookDetail(string Isbn_no)
        {


            db.Configuration.ProxyCreationEnabled = false;
    
            var names = db.vw_BooksDetails.Where(x => x.LibraryISBN == Isbn_no).FirstOrDefault();
        
            return Json(names, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckAllocation(string Isbn_no)
        {

            var names = db.LibraryBooks.Where(x => x.LibraryISBN == Isbn_no).FirstOrDefault();
            if (names != null)
            {
                var issuests = db.LibraryBooks.Where(i => i.LibraryBookStatus == "Issued" && i.LibraryISBN == Isbn_no).FirstOrDefault();
                if(issuests!=null)
                {
                    var result1 = new { Success = "True", Message = "This book is issued" };
                    return Json(result1, JsonRequestBehavior.AllowGet);
                }

                var result = new { Success = "False", Message = "This book is available" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }


            else
            {
                var result = new { Success = "True", Message = "This book is not available" };

                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult CheckStatus(string Isbn_no)
        {
      
            var names = db.LibraryBooks.Where(x => x.LibraryISBN == Isbn_no).Select(x=>x.LibraryBookStatus).FirstOrDefault();
            if (names != null)
            {
                     if (names == "Available")
                {
                    var result1 = new { Success = "False", Message = "This book is Available" };
                    return Json(result1, JsonRequestBehavior.AllowGet);
                }
                else if (names == "Requested")
                {
                        var result1 = new { Success = "true", Message = "This book is requsted" };
                        return Json(result1, JsonRequestBehavior.AllowGet);
                 
                 
                }
                else {
                    var result1 = new { Success = "True", Message = "This book is issued" };
                    return Json(result1, JsonRequestBehavior.AllowGet);
                
                }

               
            }


            else
            {
                var result = new { Success = "True", Message = "This book is not available" };

                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult CheckAllocation1(string Isbn_no)
        {

            var names = db.LibraryBooks.Where(x => x.LibraryISBN == Isbn_no).FirstOrDefault();
            if (names != null)
            {
                var issuests = db.LibraryBooks.Where(i => i.LibraryBookStatus == "Issued" && i.LibraryISBN == Isbn_no).FirstOrDefault();
                if (issuests != null)
                {
                    var result1 = new { Success = "True", Message = "This book is issued" };
                    return Json(result1, JsonRequestBehavior.AllowGet);
                }

                var result = new { Success = "False", Message = "This book is returned" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }


            else
            {
                var result = new { Success = "False", Message = "This book is not available" };

                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GetRequestPerson(string regid, string Isbn_no)
        {

            var regid_tb = db.LibraryBookRequests.Where(x => x.LibraryISBN == Isbn_no && x.LibraryBookRequestStatus=="0").Select(x=>x.LibraryRequestUserRegId).FirstOrDefault();
          string reg=Convert.ToString(regid_tb);
            if (regid_tb != null)
            {
               if (reg == regid)
                {
                        var result = new { Success = "False", Message = "This book is  Requested by this person" };
                        return Json(result, JsonRequestBehavior.AllowGet);
                }
                   else
               {
               
               var result = new { Success = "True", Message = "This book is  Requested by other Person" };

              return Json(result, JsonRequestBehavior.AllowGet);
               }
            }


            else
            {
                var result = new { Success = "False", Message = "This book is not Requested by any person" };

              return Json(result, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult GetIssueDetail(string Isbn_no)
        {


            db.Configuration.ProxyCreationEnabled = false;

            var names = db.vw_BookIssueAvail.Where(x => x.LibraryISBN == Isbn_no).FirstOrDefault();
          if(names != null)
            {
                return Json(names, JsonRequestBehavior.AllowGet);
            }
          else
          {
              var detal = db.vw_BooksDetails.Where(x => x.LibraryISBN == Isbn_no).FirstOrDefault();
              if (detal != null)
              {
                  return Json(detal, JsonRequestBehavior.AllowGet);
              }
              else {

                  var detail = "Empty";
                  return Json(detail, JsonRequestBehavior.AllowGet);

              }
            
          }

           
        } 

        public ActionResult book_details()
        {
            var tc = new List<vw_BooksDetails>();
            tc = db.vw_BooksDetails.OrderByDescending(x => x.LibraryId).ToList();
            return View(tc);

           
        }
        [HttpGet]
        public ActionResult book_updt(int id)
        {
            var Author = (db.LibraryBookAvailabilities).GroupBy(p => p.LibraryBookAuthor).Select(grp => grp.FirstOrDefault());
            SelectList list = new SelectList(Author, "LibraryBookAuthor", "LibraryBookAuthor");
            ViewBag.writer = list;
            return View(db.LibraryBooks.Where(i => i.LibraryId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult book_updt(LibraryBook lb,int id)
        {
            LibraryBook bk = db.LibraryBooks.Where(i => i.LibraryId == id).FirstOrDefault();

            bk.LibraryBookCondition = lb.LibraryBookCondition;
            bk.LibraryBookLanguage = lb.LibraryBookLanguage;
            bk.LibraryBookShelfNo = lb.LibraryBookShelfNo;
        

            int y = db.SaveChanges();
            if (y > 0)
            {

             
                return RedirectToAction("book_details");
            }
            return View();
        }
        public ActionResult book_del(int id)
        {
          LibraryBook lb=  db.LibraryBooks.Where(i => i.LibraryId == id).FirstOrDefault();
          db.LibraryBooks.Remove(lb);
        int k=  db.SaveChanges();
            if(k>0)
            {
                return RedirectToAction("book_details");
            }

            return RedirectToAction("book_details");
        }



        public JsonResult GetUsername(string usertype)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (usertype == "Student")
            {
                var DivisionList = db.Students.Where(x => x.StudActive == 1).ToList();
            
                return Json(DivisionList, JsonRequestBehavior.AllowGet);
                        }
            else if (usertype == "Employee")
            {
                var DivisionList = db.Employees.Where(x => x.EmpActive == 1).ToList();
                return Json(DivisionList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var DivisionList = db.Teachers.Where(x => x.TeacherActive == 1).ToList();
                return Json(DivisionList, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
     public ActionResult  mvmnt_book()
        {

            return View();
        }
        [HttpPost]


        public ActionResult mvmnt_book(FormCollection collection, string date, string isbn, string username,string usertype)
           {

        
             LibraryBookIssue lb = new LibraryBookIssue();
             lb.LibraryISBNNo = isbn;
             lb.LibraryISBNNo = collection["LibraryISBNNo"];
             var k = lb.LibraryISBNNo;
            

     
             lb.LibraryBookIssueDate = DateTime.Now;

             lb.LibraryBookIssueRequestDate = Convert.ToDateTime(collection["LibraryBookIssueRequestDate"]);

             lb.LibraryBookIssueUserName = collection["LibraryBookIssueUserType"];
             lb.LibraryBookIssueUserType = collection["LibraryBookIssueUserName"];
          
             
             lb.LibraryBookIssueStatus = 1;
             db.LibraryBookIssues.Add(lb);
             int i=db.SaveChanges();
            if(i>0)
            {

                var number = db.LibraryBooks.Where(p => p.LibraryISBN == k).Select(f => f.LibraryBookRegId).FirstOrDefault();
                var avail = db.LibraryBookAvailabilities.Where(d => d.LibraryBookReg == number).Select(l => l.LibraryBookAvailablity).FirstOrDefault();
              
                int availno = Convert.ToInt32(avail) - 1;
                if (availno != null && availno>=0)
                {
                    db.LibraryBookAvailabilities.Single(c => c.LibraryBookReg == number).LibraryBookAvailablity = availno;
                   
                    db.LibraryBooks.Single(c => c.LibraryISBN == k).LibraryBookStatus = "Issued";
                }
                int a = db.SaveChanges();

              
  
        }  
            
            return View();
     }


        public JsonResult GetFine(string Isbn_no, string fine_date)
        {


            db.Configuration.ProxyCreationEnabled = false;
            int id = Convert.ToInt32(Isbn_no);
            var amt = db.Fines.Where(x => x.FineId == id).Select(column => column.FineAmtDaily).SingleOrDefault();
            var amount = Convert.ToInt32(amt);
            if (fine_date != "")
            {
                int fdate = Convert.ToInt32(fine_date);
                int total = amount * fdate;
                return Json(total, JsonRequestBehavior.AllowGet);
            }
            else {


                int total = 0;
                return Json(total, JsonRequestBehavior.AllowGet);
            }
           

           
        }

        public JsonResult GetUpdateFine(string Isbn_no, string issue_id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            int id = Convert.ToInt32(Isbn_no);
            var amt = db.Fines.Where(x => x.FineId == id).Select(column => column.FineAmtDaily).SingleOrDefault();
            var amount = Convert.ToInt32(amt);


            var idd = Convert.ToInt32(issue_id);
           
         
          
            var request = db.LibraryBookIssues.Where(x => x.LibraryBookIssueId == idd).Select(column => column.LibraryBookIssueRequestDate).SingleOrDefault();
            var ret = db.LibraryBookIssues.Where(x => x.LibraryBookIssueId == idd).Select(column => column.LibraryBookReturnDate).SingleOrDefault();
          
            

            DateTime dt1 = Convert.ToDateTime(request);
            DateTime dt2 = Convert.ToDateTime(ret);
            if (dt2 > dt1)
            {
                var days = dt2.Subtract(dt1).TotalDays;
                var total = amount * days;
                return Json(total, JsonRequestBehavior.AllowGet);
            }
            else {
                var total = 0;
                return Json(total, JsonRequestBehavior.AllowGet);
            }
           

          
        }
            
        
        
        
        [HttpGet]
                 public ActionResult mvmt()
               {
                   var usertype = db.Groups.GroupBy(x => x.GroupName).Select(grp => grp.FirstOrDefault());
                   ViewBag.usertype = new SelectList(usertype, "GroupName", "GroupName");
                     return View();
               }
        [HttpPost]
        public ActionResult mvmt(LibraryBookIssue bk)
               {
                   return View();
               }

       
    

        public ActionResult mvmt_detail()
        {
            var tc = new List<LibraryBookIssue>();
            tc = db.LibraryBookIssues.OrderByDescending(x => x.LibraryBookIssueId).Where(x => x.LibraryBookIssueStatus == 1).ToList();
            return View(tc);
        }
        [HttpGet]
        public ActionResult mvmt_update(int id)
        {

           return View(db.vw_BookIssueAvail.Where(x=>x.LibraryBookIssueId==id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult mvmt_update(LibraryBookIssue bk)
        {
            return View();
        }
        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            SMSnewEntities entities = new SMSnewEntities();
            var customers = (from emp in entities.vw_BooksDetails
                             where emp.LibraryBookAuthor.StartsWith(prefix) || emp.LibraryBookPublisher.StartsWith(prefix) || emp.LibraryBookTitle.StartsWith(prefix) || emp.LibraryISBN.StartsWith(prefix) && emp.LibraryBookStatus == "Available"
                             select new
                             {
                                 label = emp.LibraryISBN+"-"+emp.LibraryBookTitle,
                                 val = emp.LibraryISBN
                             }).ToList();

            return Json(customers);
        }
        [HttpGet]
        public ActionResult return_book()
        {
            var fineamt = db.Fines.GroupBy(x => x.FineName).Select(grp => grp.FirstOrDefault());
            ViewBag.fineamt = new SelectList(fineamt, "FineId", "FineName");
            return View();
        }
        [HttpPost]
        public ActionResult return_book(FormCollection collection)
        {
            
           string s= collection["LibraryISBNNo"];

           LibraryBookIssue lb = db.LibraryBookIssues.Where(v => v.LibraryISBNNo == s&&v.LibraryBookIssueStatus==1).FirstOrDefault();
          var data = db.LibraryBookIssues.Where(v => v.LibraryISBNNo == s && v.LibraryBookIssueStatus == 1).FirstOrDefault();
          if (data != null)
          {

    
              if (collection["LibraryBookIssueUserType"] == "renewal")
              {

                  if (collection["LibraryBookIssueRequestDate"] != "")
                  {

                      lb.LibraryBookIssueRequestDate = Convert.ToDateTime(collection["LibraryBookIssueRequestDate"]);
                      db.LibraryBookIssues.Single(g => g.LibraryISBNNo == s).LibraryBookIssueRequestDate = lb.LibraryBookIssueRequestDate;
                      int j = db.SaveChanges();
                      if (j > 0)
                      {
                          return RedirectToAction("return_book");
                      }
                  }


              }
              lb.LibraryBookIssueStatus = 0;
              lb.FineName = collection["FineName"];
              if (collection["amount"] != "")
              {
                  lb.FineAmount = Convert.ToInt32(collection["amount"]);
              }
              lb.LibraryBookReturnDate = DateTime.Now;

              db.LibraryBooks.Single(g => g.LibraryISBN == s).LibraryBookStatus = "Available";
              int k = db.SaveChanges();
              if (k > 0)
              {




                  var number = db.LibraryBooks.Where(p => p.LibraryISBN == s).Select(f => f.LibraryBookRegId).FirstOrDefault();
                  var avail = db.LibraryBookAvailabilities.Where(d => d.LibraryBookReg == number).Select(l => l.LibraryBookAvailablity).FirstOrDefault();
            
                  int availno = Convert.ToInt32(avail) + 1;
                  db.LibraryBookAvailabilities.Single(c => c.LibraryBookReg == number).LibraryBookAvailablity = availno;
                  db.SaveChanges();

                  return RedirectToAction("return_book");
              }

          }
          else
          {

              ViewBag.message = "This book is already return";
         
   
          }
          return RedirectToAction("return_book");
        }
        

        public ActionResult return_details()
        {
            var tc = new List<LibraryBookIssue>();
            tc = db.LibraryBookIssues.OrderByDescending(x => x.LibraryBookIssueId).Where(x=>x.LibraryBookIssueStatus==0).ToList();
            return View(tc);

        }
        public ActionResult return_delete(int id)
        {
            LibraryBookIssue lb = db.LibraryBookIssues.Where(x => x.LibraryBookIssueId == id).FirstOrDefault();
            db.LibraryBookIssues.Remove(lb);
            db.SaveChanges();
            return View();

        }
        [HttpGet]
        public ActionResult return_Update(int id)
        {
            var fineamt = db.Fines.GroupBy(x => x.FineName).Select(grp => grp.FirstOrDefault());
            ViewBag.fineamt = new SelectList(fineamt, "FineId", "FineName");
            return View(db.LibraryBookIssues.Where(x=>x.LibraryBookIssueId==id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult return_update(LibraryBookIssue lb,int id)
        {
            LibraryBookIssue ll = db.LibraryBookIssues.Where(x => x.LibraryBookIssueId == id).FirstOrDefault();
            ll.FineName = lb.FineName;
            ll.FineAmount = lb.FineAmount;
            int i= db.SaveChanges();
            if(i>0)
            {
                return RedirectToAction("return_details");
            }
            return RedirectToAction("return_details");
        }
        [HttpGet]
        public ActionResult request_book()
        {

            return View();
        
        }
        [HttpPost]
        public ActionResult request_book(FormCollection collection)
      {
     
 
         string usertype=Convert.ToString( Session["usertype"]);
         string regid = Convert.ToString(Session["UserName"]);
          LibraryBookRequest lbr = new LibraryBookRequest();
          lbr.LibraryISBN = collection["sname"];
          lbr.LibraryRequestDate = DateTime.Now;
          lbr.LibraryRequestUserRegId = regid;
          lbr.LibraryRequestUserType = usertype;
          lbr.LibraryBookRequestStatus = "1";
          db.LibraryBookRequests.Add(lbr);
          int u= db.SaveChanges();
          if (u > 0)
          { 
          
          }

        return View();
      }
       
        public ActionResult request_details()
        {
            List<LibraryBookRequest> BookCatagory = db.LibraryBookRequests.Where(b=>b.LibraryBookRequestStatus=="1").OrderBy(x => x.LibraryRequestId)
   .ToList<LibraryBookRequest>();

            return View(BookCatagory);
        }
        public ActionResult reject_request(int id)
        {
            LibraryBookRequest req = db.LibraryBookRequests.Where(i => i.LibraryRequestId == id).FirstOrDefault();
            db.LibraryBookRequests.Remove(req);
           int k= db.SaveChanges();
           if (k > 0)
           {
               return RedirectToAction("request_details");
           }
        return RedirectToAction("request_details");
        
        }
        public ActionResult Accept_request(int id, string isbn)
        {
            var status = db.LibraryBooks.Where(x => x.LibraryISBN == isbn).Select(x => x.LibraryBookStatus).FirstOrDefault();
            if (status != "Issued")
            {
                LibraryBookRequest lb = db.LibraryBookRequests.Where(i => i.LibraryRequestId == id).FirstOrDefault();
                lb.LibraryBookRequestStatus = "0";
                int r = db.SaveChanges();


                if (r > 0)
                {

             
                    db.LibraryBooks.Single(c => c.LibraryISBN == isbn).LibraryBookStatus = "Requested";

                    int a = db.SaveChanges();
                    if (a > 0)
                    {

                        return RedirectToAction("request_details");
                    }

                }
            }
            else {
                ViewBag.DataExists = true;
               
                TempData["Message"] = "This Book is issued Please reject the request.";
                return RedirectToAction("request_details");
                           }
           return RedirectToAction("request_details");
        }

    }
}
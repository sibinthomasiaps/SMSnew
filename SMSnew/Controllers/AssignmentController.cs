using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using SMSnew.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
namespace SMSnew.Controllers
{
    public class AssignmentController : Controller
    {
        SMSnewEntities db = new SMSnewEntities();
        // GET: Assignment
        [HttpGet]
        public ActionResult createassignment()
        {
            
            var classname = (db.Students).GroupBy(p => p.StudClass).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list1 = new SelectList(classname, "StudClass", "StudClass");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.classname = list1;
            return View();
            
        }

        [HttpPost]

        public ActionResult createassignment(FormCollection collection, string Save, string Cancel, string AssignmentClass, string AssignmentDivision, string AssignmentSubject, HttpPostedFileBase file, string classname)
        {
            SMSnewEntities db = new SMSnewEntities();
            Assignment a = new Assignment();

            var allowedExtensions = new[] {
            ".docx", ".xlsx", ".txt",".pdf",".docm",".xlsm"
        };
            try
            {
                if (!string.IsNullOrEmpty(Save))
                {

                    string folderPath = Server.MapPath("~/uploads/");
                    var ext = Path.GetExtension(file.FileName);





                    if (allowedExtensions.Contains(ext))
                    {
                        if (!Directory.Exists(folderPath))
                        {
                            //If Directory (Folder) does not exists. Create it.
                            Directory.CreateDirectory(folderPath);
                        }



                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("/uploads"), fileName);
                        file.SaveAs(path);

                        //a.AssignmentAttachment = Convert.ToString(path);
                        // a.AssignmentAttachment = Convert.ToString(file.FileName);

                        a.AssignmentAttachment = fileName;
                        a.AssignmentTitle = collection["AssignmentTitle"];
                        a.AssignmentDescription = collection["AssignmentDescription"];


                        a.AssignmentClass = collection["AssignmentClass"];

                        a.AssignmentDivision = collection["AssignmentDivision"];
                        a.AssignmentSubject = collection["AssignmentSubject"];
                        a.AssignmentDateOfSubmit = Convert.ToDateTime(collection["AssignmentDateOfSubmit"]);
                        db.Assignments.Add(a);

                    }







                    int j = db.SaveChanges();




                    if (j > 0)
                    {
                        return RedirectToAction("createassignment");

                    }
                }

                else
                {
                    return RedirectToAction("createassignment");
                }
            }



            catch
            {
                return View();
            }
            return RedirectToAction("createassignment");
        }





        public JsonResult GetDivisionList1(string Class1)
        {


            db.Configuration.ProxyCreationEnabled = false;

            //List<Student> DivisionList = db.Students.Where(x => x.StudClass == AssignmentClass).ToList();
            var DivisionList1 = db.Students.Where(x => x.StudClass == Class1).GroupBy(q => q.StudDivision).Select(group => group.FirstOrDefault());

            return Json(DivisionList1, JsonRequestBehavior.AllowGet);

        }



        public JsonResult GetSubjectList1(string Class1)
        {



            db.Configuration.ProxyCreationEnabled = false;



            List<Subject> SubjectList = db.Subjects.Where(x => x.SubjectClass == Class1).ToList();

            return Json(SubjectList, JsonRequestBehavior.AllowGet);

        }




        public ActionResult listassignment()
        {
            return View(db.Assignments.ToList());
        }

        public ActionResult updateassignment(int id)
        {


            var classname = (db.Students).GroupBy(p => p.StudClass).Select(grp => grp.FirstOrDefault());//.ToList(); 
            SelectList list1 = new SelectList(classname, "StudClass", "StudClass");//// "ClassRoomID", "ClassRoomDivision", "Class"
            ViewBag.classname = list1;




            return View(db.Assignments.Where(i => i.AssignmentId == id).FirstOrDefault());
        }

        // POST: smsnew/Edit/5
        [HttpPost]
        public ActionResult updateassignment(FormCollection collection, string Save, string Cancel, string classname, int id, string AssignmentClass, HttpPostedFileBase file, string AssignmentDivision, string AssignmentSubject)
        {
            try
            {

                SMSnewEntities db = new SMSnewEntities();
                //        var allowedExtensions = new[] {  
                //    ".docx", ".xlsx", ".txt",".pdf",".docm",".xlsm"
                //};

                Assignment a = db.Assignments.Where(i => i.AssignmentId == id).FirstOrDefault();
                if (!string.IsNullOrEmpty(Save))
                {



                    a.AssignmentTitle = collection["AssignmentTitle"];
                    a.AssignmentDescription = collection["AssignmentDescription"];


                    a.AssignmentClass = collection["AssignmentClass"];

                    a.AssignmentDivision = collection["AssignmentDivision1"];
                    a.AssignmentSubject = collection["AssignmentSubject1"];
                    a.AssignmentDateOfSubmit = Convert.ToDateTime(collection["AssignmentDateOfSubmit"]);
                    //db.SaveChanges();


                    if (file != null)
                    {
                        var allowedExtensions = new[] {
                        ".docx", ".xlsx", ".txt",".pdf",".docm",".xlsm"
                    };
                        string folderPath = Server.MapPath("~/uploads/");
                        var ext = Path.GetExtension(file.FileName);
                        if (allowedExtensions.Contains(ext))
                        {
                            if (!Directory.Exists(folderPath))
                            {
                                //If Directory (Folder) does not exists. Create it.
                                Directory.CreateDirectory(folderPath);
                            }

                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("/uploads"), fileName);
                            file.SaveAs(path);
                            // a.AssignmentAttachment = Convert.ToString(path);
                            a.AssignmentAttachment = fileName;
                        }


                    }


                    db.SaveChanges();

                }

                else
                {
                    return RedirectToAction("createassignment");
                }

                return RedirectToAction("listassignment");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult deleteassignment(int id)
        {
            try
            {
                Assignment dep = db.Assignments.Where(i => i.AssignmentId == id).FirstOrDefault();
                db.Assignments.Remove(dep);
                int j = db.SaveChanges();
                if (j > 0)
                {
                    //  ViewBag.msg = "success";
                    return RedirectToAction("listassignment");
                }
                else
                {
                    ViewBag.msg = "failed";
                }
                return RedirectToAction("listassignment");

            }


            catch
            {
                return RedirectToAction("listassignment");
            }

        }



    }
}
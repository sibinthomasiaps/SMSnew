using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using SMSnew.Models;
using System.Diagnostics;

namespace SMSnew.Controllers
{
    public class ImportStudentController : Controller
    {
        SMSnewEntities ent = new SMSnewEntities();
        // GET: Student
        public ActionResult ImportFromExcel()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ImportFromExcel(HttpPostedFileBase file)
        {
            Student st = new Student();
            Excel.Application xlApp;
            Excel.Range range;
            object misValue = System.Reflection.Missing.Value;
            string str;
            int rCnt;
            int cCnt;
            int rw = 0;
            int cl = 0;



            if (file != null)
            {
                if (!Directory.Exists(Server.MapPath("~/uploads/TempExcel")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/uploads/TempExcel"));

                }
                string FileName = Path.GetFileName(file.FileName);
                string FilePath = Path.Combine(Server.MapPath("~/uploads/TempExcel"), FileName);
                file.SaveAs(FilePath);

                xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add() as Excel.Workbook;
                Excel.Worksheet xlWorkSheet = xlWorkBook.Sheets[1] as Excel.Worksheet;


                xlWorkBook = xlApp.Workbooks.Open(FilePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                range = xlWorkSheet.UsedRange;
                rw = range.Rows.Count;
                cl = range.Columns.Count;

                string strRecord, strDOB, strJoinDate;
                for (rCnt = 2; rCnt <= rw; rCnt++)
                {
                    strRecord = string.Empty;
                    st.StudRollNumber = Convert.ToString((range.Cells[rCnt, 1] as Excel.Range).Text);
                    strRecord = Convert.ToString((range.Cells[rCnt, 1] as Excel.Range).Text);

                    st.StudFirstName = Convert.ToString((range.Cells[rCnt, 2] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 2] as Excel.Range).Text);

                    st.StudLastName = Convert.ToString((range.Cells[rCnt, 3] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 3] as Excel.Range).Text);

                    st.StudAddress1 = Convert.ToString((range.Cells[rCnt, 4] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 4] as Excel.Range).Text);

                    st.Caste = Convert.ToString((range.Cells[rCnt, 5] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 5] as Excel.Range).Text);

                    st.StudCity = Convert.ToString((range.Cells[rCnt, 6] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 6] as Excel.Range).Text);

                    st.StudPINcode = Convert.ToString((range.Cells[rCnt, 7] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 7] as Excel.Range).Text);

                    st.StudState = Convert.ToString((range.Cells[rCnt, 8] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 8] as Excel.Range).Text);

                    st.StudCountry = Convert.ToString((range.Cells[rCnt, 9] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 9] as Excel.Range).Text);

                    st.StudGender = Convert.ToString((range.Cells[rCnt, 10] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 10] as Excel.Range).Text);

                    string strGender = Convert.ToString(st.StudGender).ToUpper();
                    if (strGender == "MALE")
                    {
                        st.StudPhoto = "male-avatar.jpg";
                    }
                    else if (strGender == "FEMALE")
                    {
                        st.StudPhoto = "female-avatar.jpg";
                    }

                    st.StudEmail = Convert.ToString((range.Cells[rCnt, 11] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 11] as Excel.Range).Text);


                    strDOB = (range.Cells[rCnt, 12] as Excel.Range).Text;
                    if (string.IsNullOrWhiteSpace(strDOB))
                    {
                        strDOB = DateTime.Now.ToShortDateString();
                        st.StudDOB = Convert.ToDateTime(strDOB);
                    }
                    else
                    {
                        st.StudDOB = Convert.ToDateTime((range.Cells[rCnt, 12] as Excel.Range).Text);
                    }
                    

                    strJoinDate = (range.Cells[rCnt, 13] as Excel.Range).Text;
                    if (string.IsNullOrWhiteSpace(strJoinDate))
                    {
                        strJoinDate = DateTime.Now.ToShortDateString();
                        st.StudJoinDate = Convert.ToDateTime(strJoinDate);
                    }
                    else
                    {
                        st.StudJoinDate = Convert.ToDateTime((range.Cells[rCnt, 13] as Excel.Range).Text);
                    }

                    st.StudDivision = Convert.ToString((range.Cells[rCnt, 14] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 14] as Excel.Range).Text);

                    st.StudClass = Convert.ToString((range.Cells[rCnt, 15] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 15] as Excel.Range).Text);

                    st.StudBloodGroup = Convert.ToString((range.Cells[rCnt, 16] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 16] as Excel.Range).Text);

                    st.StudContactNumber = Convert.ToString((range.Cells[rCnt, 17] as Excel.Range).Text);
                    strRecord += Convert.ToString((range.Cells[rCnt, 17] as Excel.Range).Text);

                    if (!string.IsNullOrWhiteSpace(strRecord.Trim()))
                    {
                        ent.Students.Add(st);
                        ent.SaveChanges();
                    }
                   
                }

                
                xlWorkBook.Close(false, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
                System.IO.File.Delete(FilePath);
            
            }
            return View();
        }
    }
}
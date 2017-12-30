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
namespace SMSnew.models
{
    public class emailpurchase
    {

        public string emailgen(double amnt, double balance, string pname, string mail)
        {
            MailMessage mm = new MailMessage("anikayajsms@gmail.com", mail);
            mm.Subject = "Debited Details";

            mm.Body = string.Format("Hi {0},<br /><br /> Debited Rs <strong>{1}</strong>.<br/><br /> Avail Balance is Rs<strong>{2}</strong>.<br /><br />Thank You.", pname, amnt, balance);
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = "anikayajsms@gmail.com";
            NetworkCred.Password = "anikayaj123";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
            string message = "successfully send email";
            return message;
        }
    }
}
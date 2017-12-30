using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace SMSnew.Models
{
    public class Emailuserdetails
    {
        public string emailgen(string uname, string pword, string email, string fname)
        {
            MailMessage mm = new MailMessage("anikayajsms@gmail.com", email);
            mm.Subject = "Password ";
            mm.Body = string.Format("Hi {0},<br /><br />Your Username is <strong>{1}</strong>.<br /><br />Your password is <strong>{2}</strong>.<br /><br />Thank You.", fname, uname, pword);
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
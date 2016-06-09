using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;
using ActionMailer.Net.Mvc4;

namespace Library.Helpers
{
    public class EmailHelper : MailerBase
    {
        public EmailResult SendEmailRes(string to, string bookName)
        {
            EmailModel model = new EmailModel();
            model.To = to;
            To.Add(to);
            model.From = to;
            From = @"library91app@gmail.com";
            model.Subject = "Mail From Library";
            Subject = "Mail From Library";

            model.Body = String.Format("You took book {0} in our library at {1} don't foget to return it!!!", bookName, DateTime.Now.ToString());

            return Email("EmailBody", model);
        }

        public void SendMail(string to, string bookName)
        {
            if (ModelState.IsValid)
            {
               SendEmailRes(to, bookName).Deliver();
            }
            
        }
    }
    
}
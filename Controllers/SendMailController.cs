using Microsoft.AspNetCore.Mvc;
using SendMailThroughMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SendMailThroughMVC.Controllers
{
    public class SendMailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SendMailModel _objectModel)
        {
            if (ModelState.IsValid)
            {
                MailMessage message = new MailMessage();
                message.To.Add(_objectModel.To);
                message.From = new MailAddress(_objectModel.From);
                message.Subject = _objectModel.Subject;
                string Body = _objectModel.Body;
                message.Body = Body;
                message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("Username", "Password"); // Enter senders User name and password       
                smtp.EnableSsl = true;
                smtp.Send(message);

                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }
        }
    }
}

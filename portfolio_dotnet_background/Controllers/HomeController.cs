using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using portfolio_dotnet_background.Models;

namespace portfolio_dotnet_background.Controllers
{
    public class HomeController : Controller
    {
         private EmailAdress FromAndToEmailAddress;
        private IEmailService EmailService;
        public HomeController(EmailAdress _fromAddress, 
            IEmailService _emailService)
        {
            FromAndToEmailAddress = _fromAddress;
            EmailService = _emailService;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Krystian Tokarczyk software and web developer - Home page";
            ViewData["Description"] = "Krystian Tokarczyk - Software developer: csharp, dotnet, cplusplus, devexpress. Web developer: html, css, javascript, asp";
            return View();
        }

        public IActionResult Portfolio()
        {
            ViewData["Title"] =  "Krystian Tokarczyk Software/Web Developer - Portfolio";
            ViewData["Description"]= "Krystian Tokarczyk - Portfolio, projects of software and web development";
            return View();
        }

        [HttpGet]
        public ViewResult Contact()
        {
            ViewData["Title"] =  "Krystian Tokarczyk Software/Web Developer - Contact";
            ViewData["Description"]= "Contact form for more information about a work and cooperation.";
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                EmailMessage msgToSend = new EmailMessage
                {
                    FromAdresses = new List<EmailAdress> { FromAndToEmailAddress  },
                    ToAddresses = new List<EmailAdress> { FromAndToEmailAddress  },
                    Content = $"Here is your message: \rName: {model.Name}, " +
                        $"Email: {model.Email}, \rMessage: {model.Message}",
                    Subject = "Contact Form - This is a message from website."
                };

                EmailService.Send(msgToSend);
                return RedirectToAction("Contact");
            }
            else
            {
                return Contact();
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}

using BuggyBits.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuggyBits.Controllers
{
    public class CompanyInformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            BuggyMail mail = new BuggyMail();
            mail.SendEmail(model.Message, "whocares-at-buggymail");
            return View("Index");
        }
    }
}

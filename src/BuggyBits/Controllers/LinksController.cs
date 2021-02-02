using BuggyBits.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuggyBits.Controllers
{
    public class LinksController : Controller
    {
        private readonly DataLayer dataLayer;
        public LinksController(DataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }
        public IActionResult Index()
        {
            return View(dataLayer.GetAllLinks());
        }
    }
}

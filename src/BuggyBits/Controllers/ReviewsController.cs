using BuggyBits.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BuggyBits.Controllers
{
    public class ReviewsController : Controller
    {
        // GET: Reviews/1
        [Route("Reviews/{refresh?}")]
        public IActionResult Index(int? refresh)
        {
            if(refresh != null)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            var review1 = new Review(1);
            ViewData["Review1_Quote"] = review1.Quote;
            ViewData["Review1_Source"] = review1.Source;
            review1.Clear();

            var review2 = new Review(2);
            ViewData["Review2_Quote"] = review2.Quote;
            ViewData["Review2_Source"] = review2.Source;
            review2.Clear();

            return View();
        }
    }
}

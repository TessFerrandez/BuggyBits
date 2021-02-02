using BuggyBits.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BuggyBits.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataLayer dataLayer;

        public ProductsController(DataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        // GET: Products
        public IActionResult Index()
        {
            var products = dataLayer.GetAllProducts();
            var productsTable = "<tr><th>Product Name</th><th>Description</th><th>Price</th></tr>";
            foreach(var product in products)
            {
                productsTable += $"<tr><td>{product.ProductName}</td><td>{product.Description}</td><td>{product.Price}</td>";
            }
            ViewData["ProductsTable"] = productsTable;
            return View();
        }

        // GET: Products/Details/BugSpray
        [Route("Products/Details/{productName}")]
        public IActionResult Details(string productName)
        {
            var model = dataLayer.GetProductInfo(productName);
            return View(model);
        }

        // GET: Products/Featured
        public IActionResult Featured() {
            DateTime start = DateTime.Now;
            var model = dataLayer.GetFeaturedProducts();
            DateTime end = DateTime.Now;

            ViewData["StartTime"] = start.ToLongTimeString();
            ViewData["ExecutionTime"] = end.Subtract(start).Seconds + "." + end.Subtract(start).Milliseconds;

            return View(model);
        }
    }
}

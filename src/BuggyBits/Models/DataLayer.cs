using BuggyBits.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace BuggyBits.Models
{
    public class DataLayer
    {
        private object syncobj = new object();

        public List<Product> GetFeaturedProducts()
        {
            lock (syncobj)
            {
                Thread.Sleep(5000);

                var featuredProducts = new List<Product>();
                featuredProducts.Add(new Product { ProductName = "Get out of meeting free card", Description = "May be kept until needed or sold", Price = "$500" });
                featuredProducts.Add(new Product { ProductName = "Solitaire cheat kit", Description = "Tired of not being able to finish your spider solitaire? this is the kit for you", Price = "$4999" });
                featuredProducts.Add(new Product { ProductName = "Bugspray", Description = "Why use a debugger when you can use bugspray?", Price = "$250.99" });
                featuredProducts.Add(new Product { ProductName = "In case of emergency push button", Description = "Excellent for any type of emergency", Price = "$1" });
                featuredProducts.Add(new Product { ProductName = "Vanity plate", Description = "Now available in 3 different colors and 5 different shapes", Price = "$33" });
                featuredProducts.Add(new Product { ProductName = "w00t baseball cap", Description = "Nothing will scare the other team as much as a w00t cap", Price = "$345" });
                featuredProducts.Add(new Product { ProductName = "Extra base", Description = "Are all your base belong to us? Purchase extra base upgrade", Price = "$22" });

                return featuredProducts;
            }
        }

        public ProductDetails GetProductInfo(string productName)
        {
            ProductDetails product = new ProductDetails();
            ShippingInfo shipping = new ShippingInfo();
            product.ProductName = productName;
            shipping.Distributor = "Buggy Bits";
            shipping.DaysToShip = 5;
            product.ShippingInfo = shipping;

            Type[] extraTypes = new Type[1];
            extraTypes[0] = typeof(ShippingInfo);

            MemoryStream stream = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(typeof(ProductDetails), extraTypes);
            serializer.Serialize(stream, product);

            // TODO: save off the data to an xml file or pass it as a string somewhere
            
            stream.Close();

            return product;
        }

        public List<Product> GetAllProducts()
        {
            var allProducts = new List<Product>();
            for (int i = 0; i < 10000; i++)
                allProducts.Add(new Product { ProductName = "Product" + i, Description = "Description for product" + i, Price = "$100" });
            return allProducts;
        }

        public List<Link> GetAllLinks()
        {
            var links = new List<Link>()
            {
                new Link("If broken it is, fix it you should", "http://blogs.msdn.com/Tess"),
                new Link("Speaking of which...", "http://blogs.msdn.com/johan"),
                new Link("A developers stayings", "http://blogs.msdn.com/carloc"),
                new Link("Notes from a dark corner", "http://blogs.msdn.com/dougste"),
                new Link("Cheshire's blog", "http://blogs.msdn.com/jamesche"),
                new Link("ASP.NET debugging", "http://blogs.msdn.com/tom"),
                new Link("Nico's weblog", "http://blogs.msdn.com/nicd"),
                new Link("Todd Carter's weblog", "http://blogs.msdn.com/toddca")
            };
            return links;
        }
    }
}

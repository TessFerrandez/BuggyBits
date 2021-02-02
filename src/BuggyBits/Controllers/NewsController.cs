using BuggyBits.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace BuggyBits.Controllers
{
    public class NewsController : Controller
    {
        int[] bits = new int[100000];
        private IMemoryCache cache;

        public NewsController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public IActionResult Index()
        {
            string key = Guid.NewGuid().ToString();
            var cachedResult = cache.GetOrCreate(key, cacheEntry => {
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(5);
                cacheEntry.RegisterPostEvictionCallback(CacheRemovedCallback);
                cacheEntry.Priority = CacheItemPriority.NeverRemove;

                return new string("New site launched 2008-02-02");
            });

            var news = new List<News>
            {
                new News() { Title = cachedResult }
            };
            return View(news);
        }

        private void CacheRemovedCallback(object key, object value, EvictionReason reason, object state)
        {
            throw new NotImplementedException();
        }
    }
}

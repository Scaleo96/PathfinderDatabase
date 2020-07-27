using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PathfinderHomebrew.Models;

namespace PathfinderHomebrew.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FeatDataContext _dbFeat;
        private readonly ItemDataContext _dbItem;

        public HomeController(ILogger<HomeController> logger, FeatDataContext dbFeat, ItemDataContext dbItem)
        {
            _logger = logger;
            _dbFeat = dbFeat;
            _dbItem = dbItem;
        }

        public IActionResult Index()
        {
            List<Post> posts = new List<Post>();

            var Items =
            _dbItem.Items
            .OrderByDescending(x => x.PostedDate)
            .ToArray();

            for (int i = 0; i < Items.Length; i++)
            {
                posts.Add(new Post
                {
                    date = Items[i].PostedDate,
                    type = "item",
                });
            }

            var feats =
            _dbFeat.Feats
            .OrderByDescending(x => x.PostedDate)
            .ToArray();

            for (int i = 0; i < feats.Length; i++)
            {
                posts.Add(new Post
                {
                    date = feats[i].PostedDate,
                    type = "feat",
                });
            }

            var postArray = posts
                .OrderByDescending(x => x.date)
                .ToArray();

            if (postArray.Length > 0)
                ViewBag.Type = postArray[0].type;

            return View();
        }

        //public PartialViewResult NewFeat()
        //{
        //    var feats =
        //    _dbFeat.Feats
        //    .OrderByDescending(x => x.PostedDate)
        //    .ToArray();

        //    return PartialView("__Feat", feats[0]);
        //}

        //public PartialViewResult NewItem()
        //{
        //    var items =
        //    _dbItem.Items
        //    .OrderByDescending(x => x.PostedDate)
        //    .ToArray();

        //    return PartialView("_Item", items[0]);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public struct Post
    {
        public DateTime date;
        public string type;
    }
}

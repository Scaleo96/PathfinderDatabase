using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PathfinderHomebrew.Models;

namespace PathfinderHomebrew.Controllers
{
    [Route("item")]
    public class ItemController : Controller
    {
        private readonly ItemDataContext _db;

        public ItemController(ItemDataContext db)
        {
            _db = db;
        }

        [Route("{type}")]
        public IActionResult Index(string type, int page = 0)
        {
            var pageSize = 2;
            var totalPosts = _db.Items.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            ViewBag.Type = type;

            var posts =
                        _db.Items
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();

            switch (type)
            {
                case "Weapons":
                    posts =
                        _db.Items
                        .Where(x => x.Type == ItemType.Weapon)
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();
                    break;

                case "Armor":
                    posts =
                        _db.Items
                        .Where(x => x.Type == ItemType.Armor)
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();
                    break;

                case "Rings":
                    posts =
                        _db.Items
                        .Where(x => x.Type == ItemType.Ring)
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();
                    break;

                case "Staves":
                    posts =
                        _db.Items
                        .Where(x => x.Type == ItemType.Staff)
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();
                    break;

                case "WondrousItems":
                    posts =
                        _db.Items
                        .Where(x => x.Type == ItemType.Wondrous_Item)
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();
                    break;
            }


            //if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            //{
            //    return PartialView(posts);
            //}

            return View(posts);
        }

        [Route("detect/{key}")]
        public IActionResult Item(string key)
        {
            var item = _db.Items.FirstOrDefault(x => x.Key == key);
            return View(item);
        }

        [HttpGet, Route("create")]
        public IActionResult Create(string type, int page = 0)
        {
            ViewBag.Type = type;

            return View();
        }


        [HttpPost, Route("create")]
        public IActionResult Create(Item item, string type, int page = 0)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string key = item.Key;

            _db.Items.Add(item);
            _db.SaveChanges();

            return RedirectToAction("Item", "Item", new
            {
                key
            });
        }
    }
}

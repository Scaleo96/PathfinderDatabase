using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Index(string type = "All", int page = 0)
        {
            var pageSize = 2;
            var previousPage = page - 1;
            var nextPage = page + 1;

            var totalItems = _db.Items.ToArray();
            var posts =
                        _db.Items
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();

            switch (type)
            {
                case "Weapons":
                    totalItems = _db.Items.Where(x => x.Type == ItemType.Weapon).ToArray();
                    posts =
                        totalItems
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();
                    break;

                case "Armor":
                    totalItems = _db.Items.Where(x => x.Type == ItemType.Armor).ToArray();
                    posts =
                        totalItems
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();
                    break;

                case "Rings":
                    totalItems = _db.Items.Where(x => x.Type == ItemType.Ring).ToArray();
                    posts =
                        totalItems
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();
                    break;

                case "Staves":
                    totalItems = _db.Items.Where(x => x.Type == ItemType.Staff).ToArray();
                    posts =
                        totalItems
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();
                    break;

                case "WondrousItems":
                    totalItems = _db.Items.Where(x => x.Type == ItemType.Wondrous_Item).ToArray();
                    posts =
                        totalItems
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();
                    break;
            }


            var totalPosts = totalItems.Count();
            var totalPages = (int)MathF.Ceiling((float)totalPosts / pageSize);

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            ViewBag.Type = type;

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
            string[] auras = item.AuraTypeString.Split('?');
            item.AuraTypes = new List<AuraTypeM>();
            foreach(string s in auras)
            {
                item.AuraTypes.Add(new AuraTypeM(item.Id, (AuraType)Int32.Parse(s)));
            }
            return View(item);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet, Route("create")]
        public IActionResult Create(string type, int page = 0)
        {
            ViewBag.Type = type;

            return View();
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpPost, Route("create")]
        public IActionResult Create(Item item, AuraType[] AuraTypes, string type, int page = 0)
        {
            item.AuraTypes = new List<AuraTypeM>();
            string auraString = "";

            for (int i = 0; i < AuraTypes.Length; i++)
            {
                item.AuraTypes.Add(new AuraTypeM(item.Id, AuraTypes[i]));
                //item.AuraTypes[i].AuraType = AuraTypes[i];
                //item.Id = item.Id;
                auraString += i < AuraTypes.Length - 1 ? ((int)AuraTypes[i]).ToString() + "?" : ((int)AuraTypes[i]).ToString();
            }

            item.AuraTypeString = auraString;

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

        [Authorize(Policy = "AdminOnly")]
        [Route("remove")]
        public IActionResult Remove(string key)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            _db.Items.Remove(_db.Items.FirstOrDefault(x => x.Key == key));
            _db.SaveChanges();

            return RedirectToAction("Index", "Items", new
            {
                type = "all",
                page = 0
            });
        }
    }
}

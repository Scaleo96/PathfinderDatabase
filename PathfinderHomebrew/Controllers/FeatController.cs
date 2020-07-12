using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PathfinderHomebrew.Models;

namespace PathfinderHomebrew.Controllers
{
    [Route("feat")]
    public class FeatController : Controller
    {
        private readonly FeatDataContext _db;

        public FeatController(FeatDataContext db)
        {
            _db = db;
        }

        [Route("")]
        public IActionResult Index(int page = 0, FeatType featType = FeatType.Misc)
        {
            var pageSize = 2;
            var totalPosts = _db.Feats.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var posts =
                        _db.Feats
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();

            switch (featType)
            {
                case FeatType.Misc:
                    break;

                case FeatType.General:
                    posts =
                        _db.Feats
                        .Where(x => x.Type == FeatType.General)
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();
                    break;

                case FeatType.Combat:
                    posts =
                        _db.Feats
                        .Where(x => x.Type == FeatType.Combat)
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();
                    break;

                case FeatType.Metamagic:
                    posts =
                        _db.Feats
                        .Where(x => x.Type == FeatType.Metamagic)
                        .Skip(pageSize * page)
                        .Take(pageSize)
                        .ToArray();
                    break;

                case FeatType.Story:
                    posts =
                        _db.Feats
                        .Where(x => x.Type == FeatType.Story)
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

        [Route("{key}")]
        public IActionResult Feat(string key)
        {
            var feat = _db.Feats.FirstOrDefault(x => x.Key == key);
            return View(feat);
        }

        [Authorize]
        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost, Route("create")]
        public IActionResult Create(Feat feat)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string key = feat.Key;

            _db.Feats.Add(feat);
            _db.SaveChanges();

            return RedirectToAction("Feat", "Feat", new
            {
                key
            });
        }

        //[HttpGet, Route("remove")]
        //public IActionResult Remove()
        //{
        //    return View("Index");
        //}

        [Authorize]
        [Route("remove")]
        public IActionResult Remove(string key)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            _db.Feats.Remove(_db.Feats.FirstOrDefault(x => x.Key == key));
            _db.SaveChanges();

            return RedirectToAction("Index", "Feat", new
            {
                page = 0, feattype = FeatType.Misc
            });
        }
    }
}

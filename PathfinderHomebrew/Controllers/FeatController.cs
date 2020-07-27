using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using PathfinderHomebrew.Models;

namespace PathfinderHomebrew.Controllers
{
    [Route("feat")]
    public class FeatController : Controller
    {
        private readonly FeatDataContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationService _authorizationService;

        public FeatController(FeatDataContext db, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
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
        public async Task<IActionResult> Create()
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, userId, Operations.Create);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return View();
        }


        [HttpPost, Route("create")]
        public async Task<IActionResult> Create(Feat feat)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string key = feat.Key;
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            feat.OwnerID = userId;
            feat.PostedDate = DateTime.Now;

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, userId, Operations.Create);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

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

        [Route("Edit")]
        public async Task<IActionResult> Edit(string key)
        {
            var feat = _db.Feats.FirstOrDefault(x => x.Key == key);

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, userId, Operations.Create);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return View(feat);
        }

        [HttpPost, Route("Edit"), ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(string? key)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, userId, Operations.Update);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            var feat = _db.Feats.FirstOrDefault(x => x.Key == key);

            if (await TryUpdateModelAsync<Feat>(
                feat,
                "",
                x => x.Name, x => x.Type, x => x.Benefits,
                x => x.Special, x => x.Normal, x => x.Prerequisites,
                x => x.FlavorText, x => x.BenefitAbridged))
            {
                try
                {
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Feat", "Feat", new
                    {
                        key
                    });
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + "Try again, and see if the problem persists, " +
                        "see your systam administrator.");
                }
            }

            return View(feat);
        }

        [Route("remove")]
        public async Task<IActionResult> Remove(string key)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, userId, Operations.Create);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
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

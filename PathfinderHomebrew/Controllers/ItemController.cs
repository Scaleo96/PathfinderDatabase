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
    [Route("item")]
    public class ItemController : Controller
    {
        private readonly ItemDataContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationService _authorizationService;

        public ItemController(ItemDataContext db, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
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

        [Route("detectmagic/{key}")]
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

        //[Authorize(Roles = "Administrator")]
        [HttpGet, Route("create")]
        public async Task<IActionResult> Create(string type, int page = 0)
        {
            ViewBag.Type = type;

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, userId, Operations.Create);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return View();
        }


        //[Authorize(Roles = "Administrator")]
        [HttpPost, Route("create")]
        public async Task<IActionResult> Create([Bind("Type, ItemSlot, Name, AuraStrength, CasterLevel, Weight," +
            " Price, Description, Artifact, ConstructionRequirements, Destruction, Intelligent, Alignment," +
            " Ego, Senses, Int, Wis, Cha, Communication, SpecialPurpose, DedicatedPower, CasterLevelI, Concentration," +
            " spellLikeAbilities, DestructionKnown")] Item item, AuraType[] AuraTypes, string type, int page = 0)
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
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            item.OwnerID = userId;
            item.PostedDate = DateTime.Now;

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, userId, Operations.Create);

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            _db.Items.Add(item);
            _db.SaveChanges();

            return RedirectToAction("Item", "Item", new
            {
                key
            });
        }

        [Route("Edit")]
        public async Task<IActionResult> Edit(string key, string type)
        {
            var item = _db.Items.FirstOrDefault(x => x.Key == key);

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, userId, Operations.Create);

            ViewBag.Type = type;

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return View(item);
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

            var item = _db.Items.FirstOrDefault(x => x.Key == key);

            if (await TryUpdateModelAsync<Item>(
                item,
                "",
                x => x.Name, x => x.Type, x => x.ItemSlot,
                x => x.AuraTypes, x => x.AuraStrength, x => x.CasterLevel,
                x => x.Weight, x => x.Price, x => x.Description,
                x => x.ConstructionRequirements))
            {
                try
                {
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Item", "Item", new
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

            return View(item);
        }

        //[Authorize(Roles = "Administrator")]
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

            _db.Items.Remove(_db.Items.FirstOrDefault(x => x.Key == key));
            _db.SaveChanges();

            //return RedirectToAction("Index", "Item", new
            //{
            //    page = 0
            //});

            return RedirectToAction("Index", "Item", new Microsoft.AspNetCore.Routing.RouteValueDictionary(new { type = "All"}));

            //return RedirectToRoute("Item_Index", new { controller = "Item", action = "Index", type = "All"});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AddSpellLikeAbility")]
        public ActionResult AddSpellLikeAbility([Bind("spellLikeAbilities")] Item item)
        {
            item.spellLikeAbilities.Add(new SpellLikeAbility());
            return PartialView("SpellLikeAbilities", item);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PathfinderHomebrew.Models;

namespace PathfinderHomebrew.ViewComponents
{
    public class NewItemViewComponent : ViewComponent
    {
        private readonly ItemDataContext _dbItem;

        public NewItemViewComponent(ItemDataContext dbItem)
        {
            _dbItem = dbItem;
        }

        public IViewComponentResult Invoke()
        {
            var items =
            _dbItem.Items
            .Include(i => i.spellLikeAbilities)
            .OrderByDescending(x => x.PostedDate)
            .ToArray();

            string[] auras = items[0].AuraTypeString.Split('?');
            items[0].AuraTypes = new List<AuraTypeM>();
            foreach (string s in auras)
            {
                items[0].AuraTypes.Add(new AuraTypeM(items[0].Id, (AuraType)Int32.Parse(s)));
            }

            return View(items[0]);
        }
    }
}

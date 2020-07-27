using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PathfinderHomebrew.Models;

namespace PathfinderHomebrew.ViewComponents
{
    public class NewFeatViewComponent : ViewComponent
    {
        private readonly FeatDataContext _dbFeat;

        public NewFeatViewComponent(FeatDataContext dbFeat)
        {
            _dbFeat = dbFeat;
        }

        public IViewComponentResult Invoke()
        {
            var feats =
            _dbFeat.Feats
            .OrderByDescending(x => x.PostedDate)
            .ToArray();

            return View(feats[0]);
        }
    }
}

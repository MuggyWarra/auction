using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly SlotServes slotServes;
        public SearchController(SlotServes slotServes)
        {
            this.slotServes = slotServes;
        }
        public IActionResult Index(string query)
        {
            var slots = slotServes.GetAllByQuery(query);

            return View(slots);
        }
    }
}

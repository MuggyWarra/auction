using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Web.Controllers
{
    public class SerchController : Controller
    {
        private readonly ISlotRepos slotRepos;
        public SerchController(ISlotRepos slotRepos)
        {
            this.slotRepos = slotRepos;
        }
        public IActionResult Index(string query)
        {
            var slots = slotRepos.GetAllByTitle(query);
            return View(slots);
        }
    }
}

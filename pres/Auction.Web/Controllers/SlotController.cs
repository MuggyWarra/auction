using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Web.Controllers
{
    public class SlotController : Controller
    {
        private readonly ISlotRepos slotRepos;
        public SlotController (ISlotRepos slotRepos)
        {
            this.slotRepos = slotRepos;
        }
        public IActionResult Index(int id)
        {
            Slot slot = slotRepos.GetById(id);
            return View(slot);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
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
            if (string.IsNullOrEmpty(query))
            {
                var slots1 = slotServes.GetAllByQuery(null);
                return View(slots1);
            }
            var slots = slotServes.GetAllByQuery(query);
            return View(slots);
        }
    }
}

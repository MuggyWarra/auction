using Microsoft.AspNetCore.Mvc;
namespace Auction.Web.Controllers
{
    public class SlotController : Controller
    {
        private readonly ISlotRepos slotRepos;
        private readonly IAuthServise _authServise;
        public SlotController(ISlotRepos slotRepos, IAuthServise authServise)
        {
            this.slotRepos = slotRepos;
            _authServise = authServise;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            Slot slot = slotRepos.GetById(id);
            return View(slot);
        }
    }
    public enum SlotStatus
    {
        Active,
        Reserved
    }
}

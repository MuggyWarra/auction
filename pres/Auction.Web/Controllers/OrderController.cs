using Auction.Memory;
using Auction.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace Auction.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly SlotRepos slotRepos;
        private readonly OrderRepos orderRepos;
        public OrderController(SlotRepos slotRepos,OrderRepos orderRepos)
        {
            this.slotRepos = slotRepos;
            this.orderRepos = orderRepos;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out var cart))
            {
                var order = orderRepos.GetById(cart.OrderId);
                var model = Map(order);
                return View(model);
            }
            return View("Index");
        }
        private OrderModel Map(Order order)
        {
            var slotIds = order.Items.Select(item => item.SlotId);
            var slots = slotRepos.GetAllByIds(slotIds);
            var itemModels = from item in order.Items
                             join slot in slots on item.SlotId equals slot.Id
                             select new OrderItemModel(slot);
            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
            };
        }
        public IActionResult CreateSlot(int id)
        {
            var slot = slotRepos.CreateSlot(id, "New Slot", "newTegs", "New Description", 10m, 1m);
            return RedirectToAction("Index", "Slot", new { id });
        }
        public IActionResult AddItem(int id)
        {
            Order order;
            Cart cart;
            if (HttpContext.Session.TryGetCart(out cart))
            {
                order = orderRepos.GetById(cart.OrderId);
            }
            else
            {
                order = orderRepos.Create();
                cart = new Cart(order.Id);
            }
            var slot = slotRepos.GetById(id);
            order.AddItem(slot, 1);
            orderRepos.Update(order);
            HttpContext.Session.Set(cart);
            return RedirectToAction("Index", "Slot", new { id });
        }
    }
}

using Auction.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Auction.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISlotRepos slotRepos;
        private readonly IOrderRepos orderRepos;
        public OrderController(ISlotRepos slotRepos,IOrderRepos orderRepos)
        {
            this.slotRepos = slotRepos;
            this.orderRepos = orderRepos;
        }
        public IActionResult Index()
        {
            if(HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = orderRepos.GetById(cart.OrderId);
                OrderModel model = Map(order);
                return View(model);
            }
            return View("Empty");
        }
        private OrderModel Map(Order order)
        {
            var slotIds = order.Items.Select(item => item.SlotId);
            var slots = slotRepos.GetAllByIds(slotIds);
            var itemModels = from item in order.Items
                             join slot in slots on item.SlotId equals slot.Id
                            select new OrderItemModel
                            {
                                SlotId = slot.Id,
                                Title = slot.Title,
                                Tegs = slot.Tegs,
                                MinBet = slot.MinBet,
                                InitialPrice = slot.InitialPrice,
                            };
            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount=order.TotalCount,
                TotalPrice=order.TotalPrice,
            };
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
            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;
            HttpContext.Session.Set(cart);
            return RedirectToAction("Index", "Slot", new { id });
        }
    }
}

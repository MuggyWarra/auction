using Auction.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Auction.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ISlotRepos slotRepos;
        private readonly IOrderRepos orderRepos;
        public CartController(ISlotRepos slotRepos,IOrderRepos orderRepos)
        {
            this.slotRepos = slotRepos;
            this.orderRepos = orderRepos;
        }
        public IActionResult Add(int id)
        {
            Order order;
            Cart cart;
            if (HttpContext.Session.TryGetCart(out cart))
                order = orderRepos.GetById(cart.OrderId);
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

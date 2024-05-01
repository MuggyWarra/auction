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
        public CartController(ISlotRepos slotRepos)
        {
            this.slotRepos = slotRepos;
        }
        public IActionResult Add(int id)
        {
            var slot = slotRepos.GetById(id);
            Cart cart;
            if (!HttpContext.Session.TryGetCart(out cart))
                cart = new Cart();

            if (cart.Items.ContainsKey(id))
                cart.Items[id]++;
            else
                cart.Items[id] = 1;
            cart.Amount += slot.InitialPrice;
            HttpContext.Session.Set(cart);
            return RedirectToAction("Index", "Slot", new { id });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction
{
    public class Order
    {
        public int Id { get; }
        private List<OrderItem> items;
        public IReadOnlyCollection<OrderItem> Items
        {
            get { return items; }
        }
        public int TotalCount
        {
            get { return items.Sum(items => items.Count); }
        }
        public decimal TotalPrice
        {
            get { return items.Sum(items => items.Price*items.Count); }
        }

        public Order(int id, IEnumerable<OrderItem> items)
        {
            if(items==null)
                throw new ArgumentNullException(nameof(items));
            Id = id;
            this.items = new List<OrderItem>(items);
        }
        public void AddItem(Slot slot,int count) 
        {
            if (slot == null)
                throw new ArgumentNullException(nameof(slot));
            var item = items.SingleOrDefault(x => x.SlotId == slot.Id);
            if (item == null)
            {
                items.Add(new OrderItem(slot.Id, count, slot.InitialPrice));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(slot.Id, item.Count + count, slot.InitialPrice));
            }

        }
    }       
}

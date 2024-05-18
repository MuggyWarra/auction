using System.Collections.Generic;
using System.Linq;
namespace Auction
{
    public class Order
    {
        public int Id { get; }
        private List<OrderItem> items;
        public IReadOnlyCollection<OrderItem> Items { get { return items; } }
        public Order(int id, IEnumerable<OrderItem> items)
        {
            Id = id;
            this.items = new List<OrderItem>(items);
        }
        public void AddItem(Slot slot, int count)
        {
            var item = items.SingleOrDefault(x => x.SlotId == slot.Id);
            if (item == null)
            {
                items.Add(new OrderItem(slot.Id, count, slot.InitialPrice));
            }
            else
            {
                items.Remove(item);
            }
        }
    }       
}

using System;
namespace Auction
{
    public class OrderItem
    {
        public int SlotId { get; }
        public OrderItem(int slotId,int count,decimal price)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be great that zero.");
            SlotId = slotId;
        }
    }
}

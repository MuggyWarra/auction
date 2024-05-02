using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Auction.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void Order_Zero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = 0;
            new OrderItem(1, count, 0m); 
            });
        }
        [Fact]
        public void Order_Zero_1()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = -1;
                new OrderItem(1, count, 0m);
            });
        }
        [Fact]
        public void Order_1()
        {
            var orderItem = new OrderItem(1, 2, 3m);
            Assert.Equal(1, orderItem.SlotId);
            Assert.Equal(2, orderItem.Count);
            Assert.Equal(3m, orderItem.Price);

        }
    }
}

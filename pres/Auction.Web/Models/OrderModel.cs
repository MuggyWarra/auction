namespace Auction.Web.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public OrderItemModel[] Items { get; set; } = new OrderItemModel[0];
        public decimal TotalPrice { get; set; }
        public int TotalCount { get; set; }
    }
}

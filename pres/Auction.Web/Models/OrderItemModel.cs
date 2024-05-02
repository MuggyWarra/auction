namespace Auction.Web.Models
{
    public class OrderItemModel
    {
        public int SlotId { get; set; }
        public string Title { get; set; }
        public string Tegs { get; set; }
        public decimal MinBet { get; set; }
        public decimal InitialPrice { get; set; }
    }
}

namespace Auction.Memory
{
    public class AuctionSlot:Slot
    {
        public AuctionSlot(int id, string title, string tegs, string description, decimal initialPrice, decimal minBet)
        : base(id, title, tegs, description, initialPrice, minBet)
        {
        }
    }
}

namespace Auction
{
    public interface IOrderRepos
    {
        Order Create();
        Order GetById(int id);
        void Update(Order order);
    }
}

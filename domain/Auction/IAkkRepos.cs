using System.Collections.Generic;
namespace Auction
{
    public interface IAkkRepos
    {
        Akk GetUserByLogin(string login);
        List<Akk> GetAllAkks();
    }
}

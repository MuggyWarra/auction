using System.Collections.Generic;
namespace Auction
{
    public interface IAkkRepos
    {
        Akk GetAkk(int id);
        Akk GetUserByLogin(string login);
        void UpdateAkk(Akk akk);
        void DeleteAkk(int id);
        bool ValidateAkk(Akk akk);
        bool RegisterUser(string name, string login, string password);
        void AddAkk(Akk akk);
        List<Akk> GetAllAkks();
    }
}

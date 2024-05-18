using Auction;
using System;
using System.Collections.Generic;
public class AuthServise : IAuthServise
{
    private readonly IAkkRepos _akkRepos;
    public AuthServise(IAkkRepos akkRepos)
    {
        _akkRepos = akkRepos;
    }
    public List<Akk> GetAllAkks()
    {
        return _akkRepos.GetAllAkks();
    }
    public bool Login(string login, string password)
    {
        var akk = _akkRepos.GetUserByLogin(login);
        if (akk != null && akk.Password == password)
        {
            return true;
        }
        return false;
    }
    public bool Register(string name, string login, string password)
    {
        return RegisterUser(name, login, password);
    }
    Akk IAuthServise.GetUserByLogin(string login)
    {
        var user = _akkRepos.GetUserByLogin(login);
        if (user == null)
        {
            throw new UnauthorizedAccessException("User not found");
        }
        return user;
    }
}
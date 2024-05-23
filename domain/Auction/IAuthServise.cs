﻿using System.Collections.Generic;
namespace Auction
{
    public interface IAuthServise
    {
        bool Login(string login, string password);
        List<Akk> GetAllAkks();
        Akk GetUserByLogin(string login);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction
{
    public class Akk
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public decimal Bulance { get; set; }
        public Akk(int id,string name,string login,string password,decimal bulance)
        {
            Id = id;
            Name = name;
            Login = login;
            Password = password;
            Bulance = bulance;
        }
    }
}

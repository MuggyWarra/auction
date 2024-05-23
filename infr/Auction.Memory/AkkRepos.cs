using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace Auction.Memory
{
    public class AkkRepos:IAkkRepos
    {
        private readonly List<Akk> akks = new List<Akk>()
        {
            new Akk(1,"urus","trevisscot","12345678",100000m),
            new Akk(2,"resist","turboone","23456789",100000m),
            new Akk(3,"curt","cruciatus","34567890",100000m),
        };
        public Akk GetUserByLogin(string login)
        {
            return akks.FirstOrDefault(a => a.Login == login);
        }
        public void UpdateAkk(Akk akk)
        {
            var existingAkk = akks.FirstOrDefault(a => a.Id == akk.Id);
            if (existingAkk != null)
            {
                existingAkk.Name = akk.Name;
                existingAkk.Login = akk.Login;
                existingAkk.Password = akk.Password; 
                existingAkk.Bulance = akk.Bulance; 
            }
        }
        public bool ValidateAkk(Akk akk)
        {
            if (string.IsNullOrEmpty(akk.Name) || string.IsNullOrEmpty(akk.Login) || string.IsNullOrEmpty(akk.Password))
            {
                return false;
            }
            if (!Regex.IsMatch(akk.Login, @"^[a-zA-Z0-9_]{6,14}$"))
            {
                return false;
            }
            if (!Regex.IsMatch(akk.Password, @"^[0-9]{8,14}$"))
            {
                return false;
            }
            return true;
        }
        public Akk GetAkk(int id)
        {
            return akks.FirstOrDefault(a => a.Id == id);
        }      
        public List<Akk> GetAllAkks()
        {
            if (akks.Count == 0)
            {
                throw new ArgumentException("Никаких учетных записей найдено не было");
            }
            return akks.ToList();
        }
    }
}

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
        public void AddAkk(Akk akk)
        {
            if (!ValidateAkk(akk))
            {
                throw new ArgumentException("Invalid akk");
            }
            akks.Add(akk);
        }
        public bool RegisterUser(string name, string login, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Invalid registration data");
            }
            if (!Regex.IsMatch(login, @"^[a-zA-Z0-9_]{6,14}$"))
            {
                throw new ArgumentException("Invalid login");
            }
            if (!Regex.IsMatch(password, @"^[0-9]{8,14}$"))
            {
                throw new ArgumentException("Invalid password");
            }
            var existingAkk = akks.FirstOrDefault(a => a.Login == login);
            if (existingAkk != null)
            {
                throw new ArgumentException("Login already exists");
            }
            var akk = new Akk(akks.Count + 1, name, login, password, 100000m);
            AddAkk(akk);
            return true;
        }
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
        public void DeleteAkk(int id)
        {
            var akk = akks.FirstOrDefault(a => a.Id == id);
            if (akk != null)
            {
                akks.Remove(akk);
            }
        }
        public List<Akk> GetAllAkks()
        {
            return akks.ToList();
        }
    }
}

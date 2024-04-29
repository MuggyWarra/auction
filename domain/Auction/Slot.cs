using System;
using System.Text.RegularExpressions;

namespace Auction
{
    public class Slot
    {
        public int Id { get; }
        public string Title { get; }
        public string Tegs { get; }
        public int InitialPrice{get;}
        public Slot(int id,string title,string tegs,int inpr)
        {
            Id = id;
            Tegs = tegs;
            InitialPrice = inpr;
            Title = title;
        }
        internal static bool IsTegs(string s)
        {
            if (s == null) return false;
            s = s.Replace("-", "")
                .Replace(" ", "")
                .ToUpper();
            return Regex.IsMatch(s, @"^#");

        }
    }
}

using System;
using System.Text.RegularExpressions;

namespace Auction
{
    public class Slot
    {
        public int Id { get; }
        public string Title { get; }
        public string Tegs { get; }
        public decimal MinBet { get; }
        public decimal InitialPrice{get;}
        public string Description { get; }
        public Slot(int id,string title,string tegs,string descr,decimal inpr,decimal minbet)
        {
            Id = id;
            Description = descr;
            MinBet = minbet;
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

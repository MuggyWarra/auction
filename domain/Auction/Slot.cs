using System;

namespace Auction
{
    public class Slot
    {
        public int Id { get; }
        public string Title { get; }
        public Slot(int id,string title)
        {
            Id = id;
            Title = title;
        }
    }
}

using System;
using System.Linq;

namespace Auction.Memory
{
    public class SlotRepos : ISlotRepos
    {
        private readonly Slot[] slots = new[]
        {
            new Slot(1,"cro co","#play",15),
            new Slot(2,"croco dil","#perfume",46),
            new Slot(3,"croco dil dil dil","#music",3),
        };

        public Slot[] GetAllByTeg(string tegs)
        {
            return slots.Where(slot => slot.Tegs == tegs)
                .ToArray();
        }

        public Slot[] GetAllByTitle(string titlePart)
        {
            return slots.Where(slot => slot.Title.Contains(titlePart))
                .ToArray();
        }
    }
}

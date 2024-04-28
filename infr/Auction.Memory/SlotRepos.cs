using System;
using System.Linq;

namespace Auction.Memory
{
    public class SlotRepos : ISlotRepos
    {
        private readonly Slot[] slots = new[]
        {
            new Slot(1,"cro co"),
            new Slot(2,"croco dil"),
            new Slot(3,"croco dil dil dil"),
        };
        public Slot[] GetAllByTitle(string titlePart)
        {
            return slots.Where(slot => slot.Title.Contains(titlePart))
                .ToArray();
        }
    }
}

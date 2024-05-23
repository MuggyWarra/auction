using System;
using System.Collections.Generic;
using System.Linq;
namespace Auction.Memory
{
    public class SlotRepos : ISlotRepos
    {
        private readonly List<AuctionSlot> slots = new List<AuctionSlot>();
        public Slot[] GetAllByIds(IEnumerable<int> slotIds)
        {
            return slots.Where(slot => slotIds.Contains(slot.Id)).OrderBy(slot => slot.Id).ToArray();
        }
        public Slot[] GetAllByTeg(string tegs)
        {
            return slots.Where(slot => slot.Tegs == tegs && Slot.IsTegs(tegs)).ToArray();
        }
        public Slot[] GetAllByTitle(string titlePart)
        {
            return slots.Where(slot => slot.Title.Contains(titlePart)).ToArray();
        }
        public Slot GetById(int id)
        {
            return slots.Single(slot => slot.Id == id);
        }
    }
}

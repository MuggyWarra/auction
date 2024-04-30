using System;
using System.Linq;

namespace Auction.Memory
{
    public class SlotRepos : ISlotRepos
    {
        private readonly Slot[] slots = new[]
        {
            new Slot(1,"cro co","#play","Настольная игра на 4 человек",15m,5m),
            new Slot(2,"croco dil","#perfume","Прекрасный аромат из эксклюзивной колекции",46m,8m),
            new Slot(3,"croco dil dil dil","#music","Альбом детских песен",3m,1m),
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

        public Slot GetById(int id)
        {
            return slots.Single(slot => slot.Id == id);
        }
    }
}

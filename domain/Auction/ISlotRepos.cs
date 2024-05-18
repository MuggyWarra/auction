using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction
{
    public interface ISlotRepos
    {
        Slot CreateSlot(int id, string title, string tegs, string description, decimal initialPrice, decimal minBet);
        Slot[] GetAllByTeg(string tegs);
        Slot[] GetAllByTitle(string titlePart);
        Slot GetById(int id);
        Slot[] GetAllByIds(IEnumerable<int> slotIds);
    }
}

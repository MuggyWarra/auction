using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction
{
    public interface ISlotRepos
    {
        Slot[] GetAllByTeg(string tegs);
        Slot[] GetAllByTitle(string titlePart);
        Slot GetById(int id);
        Slot[] GetAllByIds(IEnumerable<int> slotIds);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction
{
    public class SlotServes
    {
        private readonly ISlotRepos slotRepos;
        public SlotServes(ISlotRepos slotRepos)
        {
            this.slotRepos = slotRepos;
        }
        public Slot[] GetAllByQuery(string query)
        {
            if (Slot.IsTegs(query))
                return slotRepos.GetAllByTeg(query);
            return slotRepos.GetAllByTitle(query);
        }
    }
}

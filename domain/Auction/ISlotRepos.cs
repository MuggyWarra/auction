using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction
{
    public interface ISlotRepos
    {
        Slot[] GetAllByTitle(string titlePart);
    }
}

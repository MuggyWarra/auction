using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction
{
    public interface IOrderRepos
    {
        Order Create();
        Order GetById(int id);
        void Update(Order order);
    }
}

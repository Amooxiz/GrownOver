using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.Interfaces
{
    public interface IHideOutService
    {
        public void AddItem(int hideOutId, int itemId, string type);
        public void RemoveItem(int hideOutId, int itemId, string type);
    }
}

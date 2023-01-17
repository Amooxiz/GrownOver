using GrownOver.Application.ViewModels;
using GrownOver.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrownOver.Application.Interfaces
{
    public interface IHideOutRepository
    {
        public dynamic AddItem(int hideOutId, int itemId, string type, string customName);
        public dynamic RemoveItem(int hideOutId, int itemId, string type);
        public ItemsVM GetItemsByHideoutId(int hideoutId);
    }
}
